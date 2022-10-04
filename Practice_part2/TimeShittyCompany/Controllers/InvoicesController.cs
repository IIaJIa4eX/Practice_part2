using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models;

namespace TimeShittyCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InvoicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpGet("{amount}")]
        public IActionResult Create(int amount)
        {
            Invoice invoice = new Invoice();

            invoice.Create(amount);

            return Ok(invoice);
        }
    }
}
