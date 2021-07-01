using StudentsMeetTutors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.ViewModel
{
    public class ApplicationUser
    {
        public StudentRecord Students { get; set; }

        public TutorRecord Tutors { get; set; }
    }
}
