using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Client.Models;
using Client.Utils;
using Consul;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this._logger.LogWarning("first Run!");
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                foreach (var keyValuePair in dictionary)
                {
                    AgentService agentService = keyValuePair.Value;
                    this._logger.LogWarning($"{agentService.Address}:{agentService.Port} {agentService.ID} {agentService.Service}");

                }
            }
//            base.ViewBag.Students = new List<string>()
//            {
//                "AAA", "BBB", "CCC"
//            };
            string url = "http://localhost:22221/api/students";
//            string url = "http://localhost:22221/api/students";
//            string url = "http://localhost:22221/api/students";
            string content = WebAPIHelper.InvokeAPI(url);
            base.ViewBag.Students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(content);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
