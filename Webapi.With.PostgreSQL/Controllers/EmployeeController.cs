using Microsoft.AspNetCore.Mvc;
using Webapi.With.PostgreSQL.Models.Data.ApiModel;
using Webapi.With.PostgreSQL.Models.Data.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapi.With.PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _EmployeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var model = await _EmployeeService.GetEmployees();
            if(model is null)
            {
                return NoContent();
            }
            return Ok(model);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var model = await _EmployeeService.GetEmployee(id);
            if (model is null)
            {
                return NoContent();
            }
            return Ok(model);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddEmployeeModel model)
        {
            bool result = await _EmployeeService.AddEmployee(model);
            if (result)
            {
                return Ok("Employee successfully added!");
            }

            return BadRequest();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EmployeeModel model)
        {
            bool result = await _EmployeeService.UpdateEmployee(model);
            if (result)
            {
                return Ok("Employee details successfully updated!");
            }

            return BadRequest();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _EmployeeService.DeletEmployee(id);
            if (result)
            {
                return Ok("Employee successfully deleted!");
            }

            return BadRequest();
        }
    }
}
