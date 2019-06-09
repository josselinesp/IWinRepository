using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Iwin1._2.Domain;
namespace Iwin1._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sancionController : ControllerBase
    {
        // GET: api/sancion
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/sancion/5
        [HttpGet("{id}", Name = "Getfddfdg")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/sancion
        [HttpPost]
        public void Post([FromBody] sancionColectiva sancion)
        {



        }

        // PUT: api/sancion/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
