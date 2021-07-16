using Microsoft.AspNetCore.Authorization;
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

        [TempData]
        public string Style { get; set; }

        [TempData]
        public string Course { get; set; }

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
                var result = _context.Students.FirstOrDefault(e => e.Username == loginRequest.Username && e.Password == loginRequest.Password );
                //Style = result.LearningStyle;
                ////Course = result.Course;
                TempData["Username"] = result.Username;
                if (result != null)
                {
                    return RedirectToAction("SelectPreference", "Students");
                }
                else
                {
                    ModelState.AddModelError("Error", "Invalid login attempt");
                    return View(loginRequest);
                }  

            }

            ModelState.AddModelError("Error", "Invalid login attempt");
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
                    Course = signupRequest.Course,
                    LearningStyle = signupRequest.LearningStyle,
                    ClassLength = signupRequest.ClassLength,
                    AssimilationRate = signupRequest.AssimilationRate,
                    AttentionSpan = signupRequest.AttentionSpan,
                    Time = signupRequest.Time,
                    Location = signupRequest.Location
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
        public IActionResult SelectPreference()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult SelectPreference(SelectStudentRequest request)
        {
            var tutorList = _context.Tutors.Where(x => x.Course == request.Course && x.TeachingStyle == request.LearningStyle && x.ClassLength == request.ClassLength && x.PatienceLevel == request.AssimilationRate && x.Time == request.Time && x.TeachingLength == request.AttentionSpan && x.Location == request.Location).ToList();
            return RedirectToAction("SelectTutor", "Students", tutorList);
        }

        [HttpGet]
        public IActionResult SelectTutor(SelectStudentRequest request)
        {
            //var course = Course;
            //var style = Style;
            //var tutors = _context.Tutors.Where(x => x.Course == Course && x.TeachingStyle == style).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            var course = Course;
            var tutor = _context.Tutors.FirstOrDefault(x => x.ID == Id);
            return View(tutor);
        }
    }
}
