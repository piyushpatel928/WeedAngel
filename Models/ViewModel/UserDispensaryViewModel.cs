using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class UserDispensaryViewModel
    {
        public string AvtarPathName { get; set; }
        public string UserName { get; set; }
        public List<DispensariesViewModel> lstdvm { get; set; }
    }
}