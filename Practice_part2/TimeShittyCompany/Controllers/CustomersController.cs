﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Controllers
{
    //_for review
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IUsersService _userService;


        public CustomersController(IUsersService userService)
        {
            _userService = userService;
        }


        [HttpGet("search")]
        //https://localhost:5001/api/customers/search/?searchterm=Alexander - для теста
        public IActionResult GetByName([FromQuery] string searchterm)
        {
            var data = _userService.GetByName(searchterm);
            if(data == null || data.Count == 0)
            {
                return BadRequest("Никого нет с таким именем");
            }

            return Ok(data);
        }


        [HttpGet()]
        //https://localhost:5001/api/customers/?skip=0&take=70
        public IActionResult GetPage([FromQuery] int skip, int take)
        {
            var data = _userService.GetPage(skip, take);

            if (data == null || data.Count == 0)
            {
                return BadRequest("Нельзя сделать такой запрос");
            }

            return Ok(data);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {         
           return Ok(_userService.GetById(id));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] User person)
        {
            return Ok(_userService.AddNewUser(person));
        }


        [HttpPut("update")]
        public IActionResult Put([FromBody] User person)
        {
            return Ok(_userService.UpdateUserById(person));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.DeleteUserById(id));
        }
    }
}
