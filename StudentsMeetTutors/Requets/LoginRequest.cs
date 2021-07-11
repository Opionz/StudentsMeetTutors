using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Requets
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string LearningStyle { get; set; }

        public string TeachingStyle { get; set; }
    }
}
