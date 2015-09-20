using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class DispensariesViewModel
    {
        [Required(ErrorMessage = "Please Enter Dispensary Name")]
        public string DispensaryName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter valid ZipCode.")]
        public string ZipCode { get; set; }
        public string Region { get; set; }
        public string TimeZone { get; set; }
        public string AvtarName { get; set; }
        public string AvtarPathName { get; set; }
        public int DispensaryId { get; set; }
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b", ErrorMessage = "Please enter valid Email Address.")]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }
        public string FacebookPage { get; set; }
        public string TwitterPage { get; set; }
        public string InstagramPage { get; set; }
        [StringLength(1000, ErrorMessage = "Message Length is Out of Limit ")]
        public string IntroBody { get; set; }

        [StringLength(10000, ErrorMessage = "Message Length is Out of Limit ")]
        public string Body { get; set; }

        public bool IsHandicapAccess { get; set; }
        public bool IsSecurityGuard { get; set; }
        public bool IsLounge { get; set; }
        public bool IsAcceptCreditCard { get; set; }
        public bool Is18plus { get; set; }
        public bool Is21plus { get; set; }
        public bool IsPicture { get; set; }
        public bool IsVideo { get; set; }


        public string SundayOpen { get; set; }
        public string SundayClose { get; set; }
        public string MondayOpen { get; set; }
        public string MondayClose { get; set; }
        public string TuesdayOpen { get; set; }
        public string TuesdayClose { get; set; }
        public string WednesdayOpen { get; set; }
        public string WednesdayClose { get; set; }
        public string ThursdayOpen { get; set; }
        public string ThursdayClose { get; set; }
        public string FridayOpen { get; set; }
        public string FridayClose { get; set; }
        public string SaturdayOpen { get; set; }
        public string SaturdayClose { get; set; }

        public string UserName { get; set; }
        public string ProfImagePath { get; set; }


        
    }
}