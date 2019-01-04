using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreCache.UI.ViewModel;

namespace NetCoreCache.UI.Controllers
{
    public class AreaController : Controller
    {
        HttpClient client;
        Uri perguntaUri;
        private static string _urlBase;
        public AreaController()
        {
            #region Recupera as configurações base de url do appSetting
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlBase = config.GetSection("API_Access:UrlBase").Value;
            #endregion

            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public IActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync("area").Result;

            var areas = response.Content.ReadAsAsync<IEnumerable<AreaViewModel>>().Result;
            return View(areas);
        }
        
    }
}