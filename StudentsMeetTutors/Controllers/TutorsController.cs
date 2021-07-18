using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            string Username = TempData["Username"].ToString();
            TempData["Course"] = request.Course;
            TempData["LearningStyle"] = request.LearningStyle;
            TempData["ClassLength"] = request.ClassLength;
            TempData["AssimilationRate"] = request.AssimilationRate;
            TempData["AttentionSpan"] = request.AttentionSpan;
            TempData["Time"] = request.Time;
            TempData["Location"] = request.Location;
            TempData["Username"] = Username;


            string Course = TempData["Course"].ToString();
            string LearningStyle = TempData["LearningStyle"].ToString();
            string ClassLength = TempData["ClassLength"].ToString();
            string Location = TempData["Location"].ToString();
            string AssimilationRate = TempData["AssimilationRate"].ToString();
            string AttentionSpan = TempData["AttentionSpan"].ToString();
            string Time = TempData["Time"].ToString();

            var tutorPreference = _context.Tutors.AsNoTracking().FirstOrDefault(x => x.Username == Username);
            
            int ID = tutorPreference.ID;
            string MatricNumber = tutorPreference.MatricNumber;
            string FirstName = tutorPreference.FirstName;
            string Lastname = tutorPreference.LastName;
            string Password = tutorPreference.Password;
            string Email = tutorPreference.Email;

            TutorRecord preference = new TutorRecord();

                preference.ID = ID;
                preference.Username = Username;
                preference.MatricNumber = MatricNumber;
                preference.FirstName = FirstName;
                preference.LastName = Lastname;
                preference.Password = Password;
                preference.Email = Email;
                preference.Course = Course;
                preference.TeachingStyle = LearningStyle;
                preference.ClassLength = ClassLength;
                preference.Location = Location;
                preference.PatienceLevel = AssimilationRate;
                preference.TeachingLength = AttentionSpan;
                preference.Time = Time;


            _context.Attach(preference);
            _context.Update(preference).Property(p => p.Username).IsModified = true;
            _context.SaveChanges();

          //  var studentList = _context.Students.Where(x => x.Course == Course && x.LearningStyle == LearningStyle && x.ClassLength == ClassLength && x.AssimilationRate == AssimilationRate && x.Time == Time && x.AttentionSpan == AttentionSpan && x.Location == Location).ToList();
            
            return RedirectToAction("Index", "Tutors");
        }

        [HttpGet]
        public IActionResult Index()
        {
            string Username = TempData["Username"].ToString();
            string Course = TempData["Course"].ToString();
            string LearningStyle = TempData["LearningStyle"].ToString();
            string ClassLength = TempData["ClassLength"].ToString();
            string Location = TempData["Location"].ToString();
            string AssimilationRate = TempData["AssimilationRate"].ToString();
            string AttentionSpan = TempData["AttentionSpan"].ToString();
            string Time = TempData["Time"].ToString();


            var studentList = _context.Students.Where(x => x.Course == Course && x.LearningStyle == LearningStyle && x.ClassLength == ClassLength && x.AssimilationRate == AssimilationRate && x.Time == Time && x.AttentionSpan == AttentionSpan && x.Location == Location).ToList();

            return View(studentList);
        }
    }
}
