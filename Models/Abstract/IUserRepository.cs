using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedAngel.Models.DB;

namespace WeedAngel.Models.Abstract
{
    public interface IUserRepository
    {
        bool IsUserNameAvailabe(User usr);
        bool IsEmailAvailabe(User usr);
        int InsertUserData(User usr);
        int CheckUserLogin(User usr);
        string UpdateProfile(User usr, int id);
        User GetUserProfile(int userid);
    }
}
