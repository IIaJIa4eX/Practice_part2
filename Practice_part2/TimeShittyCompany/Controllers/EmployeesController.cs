using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TimeShittyCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("def id");
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] string value)
        {
            return Ok("reg ок");
        }


        [HttpPut("update/{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok("updated");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("deleted");
        }
    }
}
