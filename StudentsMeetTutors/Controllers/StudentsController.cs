using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                var result = _context.Students.FirstOrDefault(e => e.Username == loginRequest.Username && e.Password == loginRequest.Password );
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
            string Username = TempData["Username"].ToString();
            TempData["Course"] = request.Course;
            TempData["TeachingStyle"] = request.TeachingStyle;
            TempData["ClassLength"] = request.ClassLength;
            TempData["Location"] = request.Location;
            TempData["PatienceLevel"] = request.PatienceLevel;
            TempData["TeachingLength"] = request.TeachingLength;
            TempData["Time"] = request.Time;
            TempData["Username"] = Username;
            

            var tutorList = _context.Tutors.Where(x => x.Course == request.Course && x.TeachingStyle == request.TeachingStyle && x.ClassLength == request.ClassLength && x.PatienceLevel == request.PatienceLevel && x.Time == request.Time && x.TeachingLength == request.TeachingLength && x.Location == request.Location).ToList();
            return RedirectToAction("SelectTutor");
        }

        [HttpGet]
        public IActionResult SelectTutor(string Course, string PatienceLevel, string TeachingLength, string ClassLength, string TeachingStyle, string Location, string Time )
        {

            string Username = TempData["Username"].ToString();
            Course = TempData["Course"].ToString();
            TeachingStyle = TempData["TeachingStyle"].ToString();
            ClassLength = TempData["ClassLength"].ToString();
            Location = TempData["Location"].ToString();
            PatienceLevel = TempData["PatienceLevel"].ToString();
            TeachingLength = TempData["TeachingLength"].ToString();
            Time = TempData["Time"].ToString();

            var tutor = _context.Students.AsNoTracking().FirstOrDefault(x => x.Username == Username);
            
            string ID = tutor.ID;
            string MatricNumber = tutor.MatricNumber;
            string FirstName = tutor.FirstName;
            string Lastname = tutor.LastName;
            string Password = tutor.Password;
            string Email = tutor.Email;
            StudentRecord preference = new StudentRecord();
                
                preference.ID = ID;
                preference.Username = Username;
                preference.MatricNumber = MatricNumber;
                preference.FirstName = FirstName;
                preference.LastName = Lastname;
                preference.Password = Password;
                preference.Email = Email;
                preference.Course = Course;
                preference.LearningStyle = TeachingStyle;
                preference.ClassLength = ClassLength;
                preference.Location = Location;
                preference.AssimilationRate = PatienceLevel;
                preference.AttentionSpan = TeachingLength;
                preference.Time = Time;

            
            _context.Attach(preference);
            _context.Update(preference).Property(p => p.Username).IsModified = true;
            _context.SaveChanges();
            var tutorList = _context.Tutors.Where(x => x.Course == Course && x.TeachingStyle == TeachingStyle && x.ClassLength == ClassLength && x.PatienceLevel == PatienceLevel && x.Time == Time && x.TeachingLength == TeachingLength && x.Location == Location).ToList();
            return View(tutorList);

        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            var tutor = _context.Tutors.FirstOrDefault(x => x.ID == Id);
            return View(tutor);
        }
    }
}
