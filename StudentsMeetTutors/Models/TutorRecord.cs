using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Models
{
    public class TutorRecord
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string MatricNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string TeachingStyle { get; set; }
        public ICollection<StudentRecord> Student { get; set; }
    }
}
