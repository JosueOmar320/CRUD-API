using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var listClient = new List<Client>
            {
                new Client { ClientId = 1, Name = "John Doe", Email = "johndoe@example.com" },
                new Client { ClientId = 2, Name = "Mariana", Email = "Mariana@example.com" },
                new Client { ClientId = 3, Name = "Julio", Email = "Julio@example.com" },
            };
            return listClient;
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var listClient = new List<Client>
            {
                new Client { ClientId = 1, Name = "John Doe", Email = "johndoe@example.com" },
                new Client { ClientId = 2, Name = "Mariana", Email = "Mariana@example.com" },
                new Client { ClientId = 3, Name = "Julio", Email = "Julio@example.com" },
            };

            var FoundValue = listClient.FirstOrDefault(x => x.ClientId == id);

            if (FoundValue != null)
            {
                return Ok(FoundValue);
            }
            else 
            {
                return NotFound();
            }
            
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
