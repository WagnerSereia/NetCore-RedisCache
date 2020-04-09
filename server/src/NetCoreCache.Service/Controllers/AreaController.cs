using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using NetCoreCache.Configurations.CacheRedis;
using NetCoreCache.Domain.Interfaces.Repositories;
using NetCoreCache.Service.ViewModel;
using Newtonsoft.Json;

namespace NetCoreCache.Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [EnableCors("Default")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly IConfigurationRedis _configurationRedis;
        public AreaController(
                            IAreaRepository areaRepository,
                            IMapper mapper,
                            IDistributedCache distributedCache,
                            IConfigurationRedis configurationRedis)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
            _configurationRedis = configurationRedis;
        }

        [HttpGet]
        public ActionResult<List<AreaViewModel>> Get()
        {
            var cacheKey = "areas";
            var cacheAreas = _distributedCache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(cacheAreas))
            {
                var areas = JsonConvert.DeserializeObject<List<AreaViewModel>>(cacheAreas);
                var distributedCacheOption = new DistributedCacheEntryOptions();                
                return areas;
            }
            else
            {
                var areas = _mapper.Map<List<AreaViewModel>>(_areaRepository.ListarTodos().ToList());

                var distributedCacheOption = new DistributedCacheEntryOptions();
                distributedCacheOption.SetAbsoluteExpiration(TimeSpan.FromMinutes(_configurationRedis.getConfiguration().tempoCacheMinutos));                
                _distributedCache.SetString(cacheKey, JsonConvert.SerializeObject(areas), distributedCacheOption);
                return areas;
            }
        }

        [HttpGet]
        [Route("criar")]
        public ActionResult Criar()
        {
            if (ModelState.IsValid)
            {
                var cacheKey = "areas";
                var cacheAreas = _distributedCache.GetString(cacheKey);

                var areas = _mapper.Map<List<AreaViewModel>>(_areaRepository.ListarTodos().ToList());
                if (!string.IsNullOrEmpty(cacheAreas))
                    areas = JsonConvert.DeserializeObject<List<AreaViewModel>>(cacheAreas);

                var novaArea = new AreaViewModel()
                {
                    IdArea = areas.Max(x => x.IdArea) + 1,
                    Descricao = "area " + (areas.Max(x => x.IdArea) + 1),
                    Status = ViewModel.Enum.StatusViewModel.statusAtual.ATIVADO
                };

                areas.Add(novaArea);

                var distributedCacheOption = new DistributedCacheEntryOptions();
                distributedCacheOption.SetAbsoluteExpiration(TimeSpan.FromMinutes(_configurationRedis.getConfiguration().tempoCacheMinutos));
                _distributedCache.SetString(cacheKey, JsonConvert.SerializeObject(areas), distributedCacheOption);

                Console.WriteLine("Adicionado nova area");

                return Ok();
            }
            Console.WriteLine("Erro ao adicionar area");
            return BadRequest(ModelState);
        }
    }
}