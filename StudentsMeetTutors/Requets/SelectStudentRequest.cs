using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Requets
{
    public class SelectRequest
    {
        public string Course { get; set; }
        [Required]
        public string TeachingStyle { get; set; }
        [Required]
        public string ClassLength { get; set; }
        [Required]
        public string PatienceLevel { get; set; }
        [Required]
        public string TeachingLength { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
