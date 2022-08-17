using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private IEmployeesService _employeeService;


        public EmployeesController(IEmployeesService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("search")]
        //https://localhost:5001/api/employees/search/?searchterm=a - для теста
        public IActionResult GetByName([FromQuery] string searchterm)
        {
            var data = _employeeService.GetByName(searchterm);
            if (data == null || data.Count == 0)
            {
                return BadRequest("Никого нет с таким именем");
            }

            return Ok(data);
        }


        [HttpGet()]
        //https://localhost:5001/api/employees/?skip=0&take=70
        public IActionResult GetPage([FromQuery] int skip, int take)
        {
            var data = _employeeService.GetPage(skip, take);

            if (data == null || data.Count == 0)
            {
                return BadRequest("Нельзя сделать такой запрос");
            }

            return Ok(data);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_employeeService.GetById(id));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] Employee person)
        {
            return Ok(_employeeService.AddNewEmployee(person));
        }


        [HttpPut("update")]
        public IActionResult Put([FromBody] Employee person)
        {
            return Ok(_employeeService.UpdateEmployeeById(person));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_employeeService.DeleteEmployeeById(id));
        }
    }
}
