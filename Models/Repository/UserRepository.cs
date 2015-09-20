using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.Abstract;
using WeedAngel.Models.DB;

namespace WeedAngel.Models.Repo
{
    public class UserRepository : IUserRepository
    {

        WeedAngelEntities db = new WeedAngelEntities();
        public int CheckUserLogin(User usr)
        {
            var GetUser = db.Users.FirstOrDefault(a => a.UserName == usr.UserName && a.Password == usr.Password);
            if (GetUser != null)
            {
                return GetUser.UserId;
            }
            else
            {
                return 0;
            }
        }

        #region SignUP Methods
        public int InsertUserData(User usr)
        {

            db.Users.Add(usr);

            db.SaveChanges();
            return CheckUserLogin(usr);

        }
        public bool IsUserNameAvailabe(User usr)
        {
            var GetUserName = db.Users.FirstOrDefault(a => a.UserName == usr.UserName);
            if (GetUserName == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsEmailAvailabe(User usr)
        {
            var GetEmail = db.Users.FirstOrDefault(a => a.Email == usr.Email);
            if (GetEmail == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Forgot
        public Dictionary<bool, string> GetForgotUserName(User usr)
        {
            Dictionary<bool, string> dctUser = new Dictionary<bool, string>();
            var GetUserName = db.Users.FirstOrDefault(a => a.Email == usr.Email);
            if (GetUserName != null)
            {
                dctUser.Add(true, GetUserName.UserName);
                return dctUser;
            }
            else
            {
                dctUser.Add(false, "Invalid Email");
                return dctUser;
            }
        }
        public List<string> GetForgotPassword(User usr)
        {
            List<string> lstStr = new List<string>();
            var GetUserName = db.Users.FirstOrDefault(a => a.UserName == usr.UserName);
            if (GetUserName != null)
            {
                string ActCode = Guid.NewGuid().ToString();
                GetUserName.ActivationCode = ActCode;
                // GetUserName.RequestedActivationDate = DateTime.Now;
                try
                {
                    db.SaveChanges();
                    lstStr.Add("true");
                    lstStr.Add(ActCode);
                    lstStr.Add(GetUserName.Email);
                    return lstStr;
                }
                catch
                {
                    lstStr = new List<string>();
                    lstStr.Add("false");
                    lstStr.Add("Internal Error.");
                    return lstStr;
                }
            }
            else
            {
                lstStr = new List<string>();
                lstStr.Add("false");
                lstStr.Add("Invalid UserName.");
                return lstStr;
            }
        }
        #endregion

        #region PasswordUpdate

        public Dictionary<bool, int> AuthenticationCheck(string AuthCode)
        {
            Dictionary<bool, int> dctInt = new Dictionary<bool, int>();
            var GetUserFromAct = db.Users.FirstOrDefault(a => a.ActivationCode == AuthCode);
            if (GetUserFromAct != null)
            {
                DateTime dt1 = Convert.ToDateTime(GetUserFromAct.RequestedActivationDate);
                DateTime dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalHours < 24)
                {
                    dctInt.Add(true, GetUserFromAct.UserId);
                    return dctInt;
                }
                else
                {
                    dctInt = new Dictionary<bool, int>();
                    dctInt.Add(false, 0);
                    return dctInt;
                }
            }
            else
            {
                dctInt = new Dictionary<bool, int>();
                dctInt.Add(false, 0);
                return dctInt;
            }
        }

        public bool UpdatePassword(User usr, int Userid)
        {
            var GetUser = db.Users.FirstOrDefault(a => a.UserId == Userid);
            GetUser.Password = usr.Password;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public User GetUserProfile(int userid)
        {
            var GetUser = db.Users.FirstOrDefault(a => a.UserId == userid);
            return GetUser;
        }

        public string UpdateProfile(User usr, int id)
        {
            var GetUser = db.Users.FirstOrDefault(a => a.UserId == id);

            try
            {
                GetUser.FullName = usr.FullName;
                GetUser.Email = usr.Email;
                GetUser.State = usr.State;
                GetUser.AboutMe = usr.AboutMe;
                GetUser.Facebook = usr.Facebook;
                GetUser.FavDispensory = usr.FavDispensory;
                GetUser.FavStrains = usr.FavStrains;
                GetUser.FavWayToGetHigh = usr.FavWayToGetHigh;
                GetUser.Gender = usr.Gender;
                GetUser.Instagram = usr.Instagram;
                GetUser.MaritalStatus = usr.MaritalStatus;
                GetUser.TellForGetHigh = usr.TellForGetHigh;
                GetUser.Twitter = usr.Twitter;
                GetUser.Zipcode = usr.Zipcode;
                if (usr.ProfileImageName != null)
                {
                    GetUser.ProfileImageName = usr.ProfileImageName;
                    GetUser.ProfileImagePath = usr.ProfileImagePath;
                }

                {
                    db.SaveChanges();
                    return "true";
                }
            }
            catch
            {
                return "false";
            }
        }
    }
}