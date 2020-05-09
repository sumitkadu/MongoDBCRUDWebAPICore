using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LiveCovidTrackerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveCovidTrackerWebApp.Controllers
{
    public class CovidTrackerController : Controller
    {
        public IActionResult Index()
        {
            return View(GetData().Result.Data);
        }

        private async Task<CovidData> GetData()
        {            
            HttpClient client = new HttpClient();            
            client.BaseAddress = new Uri("https://api.rootnet.in/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(@"covid19-in/unofficial/covid19india.org/statewise");
            var data = await response.Content.ReadAsAsync<CovidData>();
            return data;
        }
    }
}