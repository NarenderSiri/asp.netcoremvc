using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class SampleModel
    {
        [Key]
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Age")]
        [Required]
        //[StringLength(maximumLength: 0, ErrorMessage = "The Age length should be between 1 and 100.", MinimumLength = 2)]
        public int age { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        
        public long phno { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string email { get; set; }
    }
}
