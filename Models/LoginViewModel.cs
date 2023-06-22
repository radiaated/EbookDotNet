using System;
// using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Ebook.Models {
    public class LoginViewModel  {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}