using System;
using System.ComponentModel.DataAnnotations;

namespace MVCwithSimpleIdentity.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not the same!!!" )]
        public string PasswordConfirm { get; set; }

    }
}