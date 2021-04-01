using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoogleCaptchaV3.Models
{
    public class LogInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }
        public string CaptchaToken { get; set; }
    }


}