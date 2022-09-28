using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LitJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestApplication.Controllers
{
    [Route("[controller]/{action}")]
    [ApiController]
    public class swapiController : ControllerBase
    {
    private JsonData data =new JsonData();

    [HttpGet]
    public async Task<string> People()
    {
      string Baseurl = "https://swapi.dev/api/people/";
     string result = string.Empty;
      using (var client = new HttpClient())
      {
        
        client.BaseAddress = new Uri(Baseurl);
        client.DefaultRequestHeaders.Clear();
      
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       
        HttpResponseMessage Res = await client.GetAsync(string.Empty);
       
        if (Res.IsSuccessStatusCode)
        {
          var Response = Res.Content.ReadAsStringAsync().Result;
           data = JsonMapper.ToObject(Response);
          result = data.ToJson();
          ///  result = data["results"].ToJson();

        }
       
        return result;
      }
    }
  }
}