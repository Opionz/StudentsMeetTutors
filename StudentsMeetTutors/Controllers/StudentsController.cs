using Microsoft.AspNetCore.Mvc;
using StudentsMeetTutors.Models;
using StudentsMeetTutors.Requets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentLogin(LoginRequest loginRequest)
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentSignUp(StudentRecord signupRequest)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
