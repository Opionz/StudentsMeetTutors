using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentsMeetTutors.Data;
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
        private readonly StudentsMeetTutorsContext _context;

        public TutorsController(StudentsMeetTutorsContext context)
        {
            _context = context;
        }

        [TempData]
        public string Style { get; set; }

        [TempData]
        public string Course { get; set; }


        [HttpGet]
        public IActionResult TutorLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TutorLogin(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Tutors.FirstOrDefault(e => e.Username == loginRequest.Username && e.Password == loginRequest.Password);
                TempData["Username"] = result.Username;
                Style = result.TeachingStyle;
                Course = result.Course;
                if (result != null)
                {
                    return RedirectToAction("SelectPreference", "Tutors");
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
        public IActionResult TutorSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TutorSignUp(TutorRecord signupRequest)
        {
            try
            {
                int i = 0;
                var user = new TutorRecord
                {
                    ID = i++,
                    Username = signupRequest.Username,
                    Password = signupRequest.Password,
                    MatricNumber = signupRequest.MatricNumber,
                    FirstName = signupRequest.FirstName,
                    LastName = signupRequest.LastName,
                    Email = signupRequest.Email,
                    Course = signupRequest.Course,
                    TeachingStyle = signupRequest.TeachingStyle,
                    ClassLength = signupRequest.ClassLength,
                    Location = signupRequest.Location,
                    PatienceLevel = signupRequest.PatienceLevel,
                    TeachingLength = signupRequest.TeachingLength,
                    Time = signupRequest.Time
                    
                    
                };
                _context.Add(user);
                _context.SaveChanges();
                ViewBag.message = "The user " + user.Username + " is saved successfully";

                RedirectToAction("TutorLogin", "Tutors");
            }
            catch (Exception)
            {

                throw;
            }
            return View("TutorLogin");
        }

        [HttpGet]
        public IActionResult SelectPreference()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SelectPreference(SelectRequest request)
        {
            var studentList = _context.Students.Where(x => x.Course == request.Course && x.LearningStyle == request.TeachingStyle && x.ClassLength == request.ClassLength && x.AssimilationRate == request.PatienceLevel && x.Time == request.Time && x.AttentionSpan == request.TeachingLength && x.Location == request.Location).ToList();
            return RedirectToAction("Index", "Tutors", studentList);
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            //var student = _context.Students.Where(e => e.Course == Course &&  e.LearningStyle == Style).ToList();

            return View();
        }
    }
}
