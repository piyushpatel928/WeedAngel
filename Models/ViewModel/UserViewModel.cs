using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class UserViewModel
    {
        
        [Required(ErrorMessage = "Please Enter Full Name")]
        [StringLength(20, ErrorMessage = "Length must be less than 20.")]
        public string FullName { get; set; }

        
        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "User Name")]
        [StringLength(20, ErrorMessage = "Length must be less than 20.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = "Length must be less than 20.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Re-Enter Password")]
        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = "Length must be less than 20.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = "Length must be less than 20.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Email Id")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b", ErrorMessage = "Please enter valid Email Address.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
       
        [StringLength(10, ErrorMessage = "Length must be 10.")]
        [RegularExpression(@"^[0-9]{10}", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        public string AvtarName { get; set; }
        public string AvtarPathName { get; set; }

    
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter valid ZipCode.")]
        public string ZipCode { get; set; }
        public string Region { get; set; }
        public string FacebookPage { get; set; }
        public string TwitterPage { get; set; }
        public string InstagramPage { get; set; }

        public string Gender { get; set; }      
        public string MaritalStatus { get; set; }
        public string Status { get; set; }

        public string FvrtWayToHigh { get; set; }
        public string FvrtDispensaries { get; set; }
        public string FvrtStrains { get; set; }

        public string AboutMe { get; set; }
        public string TellUsAbtYrFstTimeHigh { get; set; }
        
    }
}