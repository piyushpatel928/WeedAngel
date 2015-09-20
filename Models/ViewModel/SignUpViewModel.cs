using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "User Name")]
        [MaxLength(30, ErrorMessage = "Length must be less than 30.")]
        [MinLength(4, ErrorMessage = "Length must be more than 4.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [MaxLength(30, ErrorMessage = "Length must be less than 30.")]
        [MinLength(4, ErrorMessage = "Length must be more than 4.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [MaxLength(30, ErrorMessage = "Length must be less than 30.")]
        [MinLength(4, ErrorMessage = "Length must be more than 4.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b", ErrorMessage = "Please enter valid Email Address.")]
        public string Email { get; set; }
    }
}