﻿using Microsoft.AspNetCore.Identity;
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
                    return RedirectToAction("Index", "Tutors");
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
                    //ID = Guid.NewGuid().ToString(),
                    ID = i++,
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

                RedirectToAction("TutorLogin", "Tutors");
            }
            catch (Exception)
            {

                throw;
            }
            return View("TutorLogin");
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var student = _context.Students.ToList();

            return View(student);
        }
    }
}
