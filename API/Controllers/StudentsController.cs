using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private List<string> _StudentList = new List<string>()
        {
            "AAA", "BBB", "CCC"
        };

        // GET: api/Students
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return this._StudentList;
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return this._StudentList[id];
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Students/5
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
