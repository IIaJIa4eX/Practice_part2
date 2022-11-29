using final_project.DAL.Entities;
using final_project.Models;
using final_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    //for_review
    public class UsersController : Controller
    {
        private readonly IUserServiceRepository _rep;

        public UsersController(IUserServiceRepository rep)
        {
            _rep = rep;
        }

        public IActionResult Index()
        {
            return View(_rep.GetAll());
        }

        public IActionResult ShowInfo(int id)
        {
            var usInf0 = _rep.GetUser(id);
            if(usInf0 == null)
            {
                return NotFound();
            }
            return View(usInf0);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAddRequestViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var resp = _rep.Add(user);
            if(resp.Message != "Success")
            {
                ViewData["Message"] = resp.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bool success = _rep.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
