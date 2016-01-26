using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebDbIntegration.Data;

namespace WebDbIntegration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private MyDbContext _context;

        public ValuesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public Person Get(string name)
        {
            Person person = _context.People.FirstOrDefault(x => x.FirstName == name);
            //return View(person);
            return person;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            // Let db assign id
            person.Id = Guid.Empty;
            _context.Add(person);
            _context.SaveChanges();
            //return person.Id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
