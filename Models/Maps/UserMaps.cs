using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.DB;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Models.Maps
{
    public class UserMaps
    {


        public User MapSignUPVMToUser(SignUpViewModel svm)
        {
            User usr = new User();
            usr.UserName = svm.UserName;
            usr.Password = svm.Password;
            usr.Email = svm.Email;
            return usr;
        }
        public User UserVMtoUser(UserViewModel uvm)
        {
            User usr = new User();
            usr.FullName = uvm.FullName;
            usr.State = uvm.State;
            usr.Status = uvm.Status;
            usr.Zipcode = uvm.ZipCode;
            usr.Email = uvm.Email;
            usr.Gender = uvm.Gender;
            usr.MaritalStatus = uvm.MaritalStatus;

            usr.TellForGetHigh = uvm.TellUsAbtYrFstTimeHigh;
            usr.FavDispensory = uvm.FvrtDispensaries;
            usr.FavStrains = uvm.FvrtStrains;
            usr.FavWayToGetHigh = uvm.FvrtWayToHigh;

            usr.AboutMe = uvm.AboutMe;
            if (uvm.AvtarName != null)
            {
                usr.ProfileImageName = uvm.AvtarName;
                usr.ProfileImagePath = uvm.AvtarPathName;

            }
            usr.RegionId = 1;

            usr.Instagram = uvm.InstagramPage;
            usr.Facebook = uvm.FacebookPage;
            usr.Twitter = uvm.TwitterPage;



            return usr;
        }

        public UserViewModel UserToUserVm(User usr)
        {
            UserViewModel uvm = new UserViewModel();


            uvm.FullName = usr.FullName;
            uvm.UserName = usr.UserName;
            uvm.State = usr.State;
            uvm.Status = usr.Status;
            uvm.ZipCode = usr.Zipcode;
            uvm.Email = usr.Email;
            uvm.Gender = usr.Gender;
            uvm.MaritalStatus = usr.MaritalStatus;
            uvm.TellUsAbtYrFstTimeHigh = usr.TellForGetHigh;
            uvm.FvrtDispensaries = usr.FavDispensory;
            uvm.FvrtStrains = usr.FavStrains;
            uvm.FvrtWayToHigh = usr.FavWayToGetHigh;
            uvm.AboutMe = usr.AboutMe;
            if (usr.ProfileImageName != null)
            {
                uvm.AvtarName = usr.ProfileImageName;
                uvm.AvtarPathName = usr.ProfileImagePath;
            }
            uvm.InstagramPage = usr.Instagram;
            uvm.FacebookPage = usr.Facebook;
            uvm.TwitterPage = usr.Twitter;

            return uvm;

        }


    }
}