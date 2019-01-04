using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
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
        public AreaController(
                            IAreaRepository areaRepository,
                            IMapper mapper,
                            IDistributedCache distributedCache)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public ActionResult<List<AreaViewModel>> Get()
        {
            var cacheKey = "areas";
            var cacheAreas = _distributedCache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(cacheAreas))
            {
                var areas = JsonConvert.DeserializeObject<List<AreaViewModel>>(cacheAreas);
                return areas;
            }
            else
            {
                var areas = _mapper.Map<List<AreaViewModel>>(_areaRepository.ListarTodos().ToList());

                var distributedCacheOption = new DistributedCacheEntryOptions();
                distributedCacheOption.SetAbsoluteExpiration(TimeSpan.FromSeconds(10));
                _distributedCache.SetString(cacheKey, JsonConvert.SerializeObject(areas), distributedCacheOption);                
                return areas;
            }
        }
    }
}