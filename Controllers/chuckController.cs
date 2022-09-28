using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestApplication.Controllers
{


  public class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
  }
  [ApiController]
  [Route("[controller]/{action}")]
  public class chuckController : ControllerBase
  {
   

    private readonly ILogger<string> _logger;

    public chuckController(ILogger<string> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> categories()
    {
     
      string Baseurl = "Https://api.chucknorris.io/jokes/";
      List<string> Info = new List<string>();
      using (var client = new HttpClient())
      {
        //Passing service base url
        client.BaseAddress = new Uri(Baseurl);
        client.DefaultRequestHeaders.Clear();
        //Define request data format
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        HttpResponseMessage Res = await client.GetAsync("categories");
        //Checking the response is successful or not which is sent using HttpClient
        if (Res.IsSuccessStatusCode)
        {
          //Storing the response details recieved from web api
          var Response = Res.Content.ReadAsStringAsync().Result;
          //Deserializing the response recieved from web api and storing into the Employee list
          Info = JsonConvert.DeserializeObject<List<string>>(Response);
        }
        //returning the employee list to view
        return Info;
      }
    }
  }
}
