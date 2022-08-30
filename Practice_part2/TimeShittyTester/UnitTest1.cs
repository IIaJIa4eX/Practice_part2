using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using TimeShittyCompany.Controllers;
using TimeShittyCompany.Models.Authorization;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;
using Xunit;

namespace TimeShittyTester
{

    public class UnitTest1
    {

        private CustomersController _controller;

        private Mock<IUsersService> _userServiceMock;
        private Mock<IAuthService> _authServiceMock;
        private AuthController __controllerAuth;
        private Mock<HttpContext> _httpContext;

        public UnitTest1()
        {

            _userServiceMock = new Mock<IUsersService>();
            _authServiceMock = new Mock<IAuthService>();
            _httpContext = new Mock<HttpContext>();
            _controller = new CustomersController(_userServiceMock.Object, _authServiceMock.Object)
            {
                ControllerContext = { HttpContext = _httpContext.Object }
            };
            __controllerAuth = new AuthController(_authServiceMock.Object);
        }

        
        //ѕришлось создавать метод Authenticate_ForTesting дл€ теста (без записи токенов в Cookie)
        //Ќе разобралс€ как создать Response.Cookie в AuthConroller'e, через тесты
        [Fact]
        public void Auth_Tester_Ok_Result()
        {
            string testName = "testName";
            string testPass = "testPassword";

            _authServiceMock.Setup(mock => mock.Authenticate_TokenResp(testName, testPass)).
                Returns(new JwtTokenResponse() { Token = "Barer asdasdsad",
                    RefreshToken = "asdadsadasdasdasd"
                });

            var result = __controllerAuth.Authenticate_ForTesting(testName, testPass);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        //ѕришлось содавать метод Authenticate_ForTesting дл€ теста (без записи токенов в Cookie)
        [Fact]                                                                
        public void Auth_Tester_BadRequest_Result()
        {
            string testName = "";
            string testPass = null;
            _authServiceMock.Setup(mock => mock.Authenticate_TokenResp(testName, testPass));

            var result = __controllerAuth.Authenticate_ForTesting(testName, testPass);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }


        [Fact]
        public void Add_New_Customer()
        {

            _userServiceMock.Setup(mock => mock.GetByName("Alex")).Returns(new List<User>()
            {
                new User()
                {
                Age = 27,
                isDeleted = false,
                Company = "FakeCompany",
                FirstName = "Alex",
                Email = "alex@fakemai.com",
                LastName = "Empty",
                Expires = DateTime.Today,
                Id = 13,
                Password = "admin",
                Token = "adsasdasasdasdsad"
                }
            });

            var result = _controller.GetByName("Alex");

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IActionResult>(result);


        }
    }
}
