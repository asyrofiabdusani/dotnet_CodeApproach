using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "username can't be blank")]
        [Column(TypeName ="User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password can't be blank")]
        [Column(TypeName ="Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm password can't be blank")]
        [Compare("Password", ErrorMessage = "confirm password must be same with password")]
        [Column(TypeName ="Confirm password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "email password can't be blank")]
        [EmailAddress(ErrorMessage = "format email not correct")]
        public string Email { get; set; }

        public string Sex { get; set; }

    }
}