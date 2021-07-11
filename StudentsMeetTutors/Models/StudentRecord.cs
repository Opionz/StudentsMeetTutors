using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Models
{
    public class StudentRecord
    {
        [Required]
        public string ID { get; set; }
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
        public string LearningStyle { get; set; }
        public ICollection<TutorRecord> Tutor { get; set; }
    }
}
