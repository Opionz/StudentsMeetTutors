using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Requets
{
    public class SelectStudentRequest
    {
        public string Course { get; set; }
        [Required]
        public string LearningStyle { get; set; }
        [Required]
        public string TeachingStyle { get; set; }
        [Required]
        public string ClassLength { get; set; }
        [Required]
        public string AssimilationRate { get; set; }
        [Required]
        public string AttentionSpan { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
