using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMongoDBBench.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
      
        // GET: api/companies/20
        [HttpGet("{number}", Name = "Get")]
        public string Get(int number)
        {
            Models.MongoDataService model= new Models.MongoDataService(Environment.GetEnvironmentVariable("MONGOURI"), 
                Environment.GetEnvironmentVariable("MONGODB"), 
                Environment.GetEnvironmentVariable("MONGOCOLLECTION"));
            Console.WriteLine("---");
            return model.find(number);
        
        }

      
    }
}
