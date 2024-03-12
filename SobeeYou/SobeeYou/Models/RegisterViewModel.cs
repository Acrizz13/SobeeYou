using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SobeeYou.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string strFirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string strLastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string strEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string strPassword
        {
            get; set;

        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword
        {
            get; set;

        }

    }
}
