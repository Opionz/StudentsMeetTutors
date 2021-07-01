using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsMeetTutors.Data;
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
        private readonly StudentsMeetTutorsContext _context;
        public StudentsController(StudentsMeetTutorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentLogin(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Students.FirstOrDefault(e => e.Username == loginRequest.Username && e.Password == loginRequest.Password);
                TempData["Username"] = result.Username;
                if (result != null)
                {
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(loginRequest);
                }  

            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(loginRequest);
        }

        [HttpGet]
        public IActionResult StudentSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentSignUp(StudentRecord signupRequest)
        {
            try
            {
                var user = new StudentRecord
                {
                    ID = Guid.NewGuid().ToString(),
                    Username = signupRequest.Username,
                    Password = signupRequest.Password,
                    MatricNumber = signupRequest.MatricNumber,
                    FirstName = signupRequest.FirstName,
                    LastName = signupRequest.LastName,
                    Email = signupRequest.Email,
                    Course = signupRequest.Course
                };

                _context.Add(user);
                _context.SaveChanges();
                ViewBag.message = "The user " + user.Username + " is saved successfully";
                RedirectToAction("StudentLogin", "Students");
            }
            catch (Exception)
            {

                throw;
            }
            return View("StudentLogin");
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tutor = _context.Tutors.Where(x => x.Course == "CSC 421").ToList();
            return View(tutor);
        }
    }
}
