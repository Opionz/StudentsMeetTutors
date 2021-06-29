using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Models
{
    public class TutorRecord
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public string MatricNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public ICollection<StudentRecord> Student { get; set; }
    }
}
