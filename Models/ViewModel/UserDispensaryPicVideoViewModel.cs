using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class UserDispensaryPicVideoViewModel
    {
        public string UserName { get; set; }
        public string Profilepath { get; set; }
        public List<AddPictureVideoViewModel> lstPivVdVM { get; set; }
    }
}