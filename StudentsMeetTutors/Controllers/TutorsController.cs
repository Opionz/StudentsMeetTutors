using Microsoft.AspNetCore.Mvc;
using StudentsMeetTutors.Models;
using StudentsMeetTutors.Requets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Controllers
{
    public class TutorsController : Controller
    {
        
        [HttpGet]
        public IActionResult TutorLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TutorLogin(LoginRequest loginRequest)
        {
            return View();
        }

        [HttpGet]
        public IActionResult TutorSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TutorSignUp(TutorRecord loginRequest)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
