using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.DB;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Models.Maps
{
    public class DoctorMaps
    {
        public string GetStringFromNull(string Value)
        {
            return (Value == null) ? "" : Value;

        }


        public Doctor DoctorVMtoDoctor(DoctorViewModel drvm)
        {
            Doctor dr = new Doctor();
            if (dr != null)
            {
                if (drvm.AvtarName != null)
                {
                    dr.AvatarName = drvm.AvtarName;
                    dr.AvatarPath = drvm.AvtarPathName;
                }
                dr.Body = drvm.Body;
                dr.City = drvm.City;
                dr.Country = drvm.Country;
                dr.DoctorName = drvm.DoctorName;
                dr.Email = drvm.Email;
                dr.IntroBody = drvm.IntroBody;
                if (drvm.Is21plus != null)
                {
                    dr.Is21 = drvm.Is21plus;
                }
                else
                {
                    dr.Is21 = false;
                }
                if (drvm.Is18plus != null)
                {
                    dr.Is18 = drvm.Is18plus;
                }
                else
                {
                    dr.Is18 = false;
                }
                if (drvm.IsAcceptCreditCard != null)
                {
                    dr.IsCreditCards = drvm.IsAcceptCreditCard;
                }
                else
                {
                    dr.IsCreditCards = false;
                }
                if (drvm.IsHandicapAccess != null)
                {
                    dr.IsHandicap = drvm.IsHandicapAccess;
                }
                else
                {
                    dr.IsHandicap = false;
                }

                if (drvm.IsSecurityGuard != null)
                {
                    dr.IsSecurityGuard = drvm.IsSecurityGuard;
                }
                else
                {
                    dr.IsSecurityGuard = false;
                }
                
               
                
               
                dr.PhoneNo = drvm.MobileNo;
                dr.RegionId = int.Parse(drvm.Region);
                dr.State = drvm.State;
                dr.Street = drvm.Street;
                dr.TimeZoneId = 1;
                dr.Website = drvm.Website;
                dr.Zipcode = drvm.ZipCode;
            }

            return dr;

        }
        public DoctorViewModel DoctorUsertoDoctorVM(User usr)
        {
            DoctorViewModel dvm = new DoctorViewModel();
            if (dvm != null)
            {
                dvm.UserName = GetStringFromNull(usr.UserName);
                dvm.ProfilePath = GetStringFromNull(usr.ProfileImagePath);
            }
            return dvm;
        }
        public DoctorViewModel DoctortoDoctorVM(Doctor dcr)
        {
            DoctorViewModel dvm = new DoctorViewModel();
            if (dvm != null)
            {
                if (dcr.AvatarName != null)
                {
                    dvm.AvtarName = dcr.AvatarName;
                    dvm.AvtarPathName = dcr.AvatarPath;
                }
                dvm.Body = GetStringFromNull(dcr.Body);
                dvm.City = GetStringFromNull(dcr.City);
                dvm.Country = GetStringFromNull(dcr.Country);
                dvm.DoctorName = GetStringFromNull(dcr.DoctorName);
                dvm.Email = GetStringFromNull(dcr.Email);
                dvm.IntroBody = GetStringFromNull(dcr.IntroBody);

                dvm.Is18plus = (bool)dcr.Is18;
                dvm.Is21plus = (bool)dcr.Is21;
                dvm.IsAcceptCreditCard = (bool)dcr.IsCreditCards;
                dvm.IsHandicapAccess = (bool)dcr.IsHandicap;
                dvm.IsSecurityGuard = (bool)dcr.IsSecurityGuard;
                dvm.MobileNo = GetStringFromNull(dcr.PhoneNo);
                dvm.State = GetStringFromNull(dcr.State);
                dvm.Street = GetStringFromNull(dcr.Street);
                dvm.Website = GetStringFromNull(dcr.Website);
                dvm.ZipCode = GetStringFromNull(dcr.Zipcode);
            }
            return dvm;
        }

    }
}