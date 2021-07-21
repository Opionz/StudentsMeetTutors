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
            TempData["ID"] = ID;
            TempData["MatricNumber"] = MatricNumber;
            TempData["FirstName"] = FirstName;
            TempData["LastName"] = Lastname;
            TempData["Password"] = Password;
            TempData["Email"] = Email;
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

            TempData["Location"] = preference.Location;
            //  var studentList = _context.Students.Where(x => x.Course == Course && x.LearningStyle == LearningStyle && x.ClassLength == ClassLength && x.AssimilationRate == AssimilationRate && x.Time == Time && x.AttentionSpan == AttentionSpan && x.Location == Location).ToList();

            return RedirectToAction("AppointSchedule", "Tutors");
        }

        [HttpGet]
        public IActionResult AppointSchedule(string Location)
        {
            Location = TempData["Location"].ToString();
            TempData["Location"] = Location;
            return View();
        }

        [HttpPost]
        public IActionResult AppointSchedule(TutorRecord schedule)
        {
            TutorRecord tutorData = new TutorRecord();
            tutorData.Username = TempData["Username"].ToString();
            //tutorData.Location = TempData["Location"].ToString();


            TutorRecord tutorPreference = _context.Tutors.AsNoTracking().FirstOrDefault(x => x.Username == tutorData.Username);

            tutorData.ID = tutorPreference.ID;

            tutorData.MatricNumber = TempData["MatricNumber"].ToString();
            tutorData.FirstName = TempData["FirstName"].ToString();
            tutorData.LastName = TempData["LastName"].ToString();
            tutorData.Password = TempData["Password"].ToString();
            tutorData.Email = TempData["Email"].ToString();
            tutorData.Course = TempData["Course"].ToString();
            tutorData.TeachingStyle = TempData["LearningStyle"].ToString();
            tutorData.ClassLength = TempData["ClassLength"].ToString();
            tutorData.PatienceLevel = TempData["AssimilationRate"].ToString();
           // tutorData.Location = TempData["Location"].ToString();
            tutorData.TeachingLength = TempData["AttentionSpan"].ToString();
            tutorData.Time = TempData["Time"].ToString();
            tutorData.Location = schedule.Location;
            tutorData.TutorRating = schedule.TutorRating ;
            tutorData.LectureTime = schedule.LectureTime ;
            tutorData.LectureDate = schedule.LectureDate ;
            tutorData.Venue =  schedule.Venue ;
            //tutorData.ID = (int)TempData["Username"];
            TempData["Location"] = tutorData.Location  ;
            //schedule.TutorRating = TempData["TutorRating"].ToString();
            TempData["LectureTime"] = schedule.LectureTime  ;
            TempData["LectureDate"] = schedule.LectureDate ;
            TempData["Venue"] = schedule.Venue ;

            _context.Attach(tutorData);
            _context.Update(tutorData).Property(p => p.Username).IsModified = true;
            _context.SaveChanges();

            return RedirectToAction("Index", "Tutors");
        }

        [HttpGet]
        public IActionResult Index()
        {
            string Username = TempData["Username"].ToString();
            var tutorPreference = _context.Tutors.AsNoTracking().FirstOrDefault(x => x.Username == Username);

            int ID = tutorPreference.ID;
            //string Username = TempData["Username"].ToString();
            string MatricNumber = TempData["MatricNumber"].ToString();
            string FirstName = TempData["FirstName"].ToString();
            string Lastname = TempData["LastName"].ToString();
            string Password = TempData["Password"].ToString();
            string Email = TempData["Email"].ToString();
            string Course = TempData["Course"].ToString();
            string TeachingStyle = TempData["LearningStyle"].ToString();
            string ClassLength = TempData["ClassLength"].ToString();
            string PatienceLevel = TempData["AssimilationRate"].ToString();
            string Location = TempData["Location"].ToString();
            string TeachingLength = TempData["AttentionSpan"].ToString();
            string Time = TempData["Time"].ToString();
            //string TutorRating = TempData["TutorRating"].ToString();
            string LectureTime = TempData["LectureTime"].ToString();
            string LectureDate = TempData["LectureDate"].ToString();
            string Venue = TempData["Venue"].ToString();


            //TempData["TutorRating"].ToString();
            TempData["LectureTime"].ToString();
            TempData["LectureDate"].ToString();
            TempData["Venue"].ToString();
            //string Username = TempData["Username"].ToString();
            //string Course = TempData["Course"].ToString();
            //string LearningStyle = TempData["LearningStyle"].ToString();
            //string ClassLength = TempData["ClassLength"].ToString();
            //string Location = TempData["Location"].ToString();
            //string AssimilationRate = TempData["AssimilationRate"].ToString();
            //string AttentionSpan = TempData["AttentionSpan"].ToString();
            //string Time = TempData["Time"].ToString();


            var studentList = _context.Students.Where(x => x.Course == Course && x.LearningStyle == TeachingStyle && x.ClassLength == ClassLength && x.AssimilationRate == PatienceLevel && x.Time == Time && x.AttentionSpan == TeachingLength && x.Location == Location).ToList();

            return View(studentList);
        }
    }
}
