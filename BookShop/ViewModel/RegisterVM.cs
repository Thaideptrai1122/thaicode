using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BookShop.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage="Username cannot be blank.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Pass cannot be blank.")]
        [Compare("Password", ErrorMessage ="Password is not match")]
        public string ConfirmPasswword { get; set; }
        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

    }
}
