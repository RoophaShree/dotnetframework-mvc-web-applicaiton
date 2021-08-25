using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roopa.Employee.Rest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        Employee.Repository.EmpRepository empRepository = null;
        IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            var str = _configuration.GetConnectionString("getconn");
            empRepository = new Repository.EmpRepository(str);

        }

        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<Roopa.Repository.Model.EmpModel> Get()
        {
            
          var allemployees =   empRepository.GetAllEmployees();

            return allemployees;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public Roopa.Repository.Model.EmpModel Get(int id)
        {

            var allemployees = empRepository.GetAllEmployees();

            var employee= allemployees.Where(employee => employee.Empid == id).FirstOrDefault();

            return employee;

        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
