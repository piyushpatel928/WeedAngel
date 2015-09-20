using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeedAngel.Models.Abstract;
using WeedAngel.Models.Maps;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public UserMaps usrMaps = new UserMaps();
        public MailVM mvm = new MailVM();
        public IUserRepository _db { get; set; }
        public HomeController(IUserRepository db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            return RedirectToAction("LogIn", "Home");
        }
        [HttpPost]
        public ActionResult LogIn(SignUpViewModel uvm)
        {
            int i = _db.CheckUserLogin(usrMaps.MapSignUPVMToUser(uvm));
            if (i != 0)
            {
                Session["UserId"] = i.ToString();
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid UserName / Password.";
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel uvm)
        {
            if (_db.IsUserNameAvailabe(usrMaps.MapSignUPVMToUser(uvm)))
            {
                if (_db.IsEmailAvailabe(usrMaps.MapSignUPVMToUser(uvm)))
                {
                    if (uvm.Password == uvm.ConfirmPassword)
                    {
                        int i = _db.InsertUserData(usrMaps.MapSignUPVMToUser(uvm));
                        if (i != 0)
                        {
                            Session["UserId"] = i.ToString();
                            // mvm.WelcomeMail(uvm.UserName, uvm.Email);
                            return RedirectToAction("Profile", "Home");

                            //return change
                        }
                        else
                        {
                            ViewBag.Message = "Error in Register User.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Password Does Not Match.";
                        return View();
                    }

                }
                else
                {
                    ViewBag.Message = "Email already registered.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "User Name already registered.";
                return View();
            }
        }
        public ActionResult Profile()
        {
            if (Session["UserId"] != null)
            {
                int userid = int.Parse(Session["UserId"].ToString());
                return View(usrMaps.UserToUserVm(_db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult UpdateProfile()
        {
            if (Session["UserId"] != null)
            {
                int userid = int.Parse(Session["UserId"].ToString());
                return View(usrMaps.UserToUserVm(_db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }
        [HttpPost]
        public ActionResult UpdateProfile(UserViewModel uvm, HttpPostedFileBase avtar)
        {
            if (Session["UserId"] != null)
            {
                int id = int.Parse(Session["UserId"].ToString());
                if (avtar != null && avtar.ContentLength > 0)
                {
                    string ext = avtar.FileName;
                    ext = ext.Substring(ext.LastIndexOf("."));
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        var fileName = Path.GetFileName(avtar.FileName);
                        string originalpath = avtar.FileName;
                        fileName = fileName.Substring(0, fileName.LastIndexOf(".") - 1);
                        fileName = fileName + DateTime.Now.Ticks.ToString() + ext;
                        var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                        avtar.SaveAs(path);
                        string path1 = "~/UploadedImages/" + fileName;
                        uvm.AvtarName = avtar.FileName;
                        uvm.AvtarPathName = path1;
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Image.";
                        return View();
                    }
                }

                _db.UpdateProfile(usrMaps.UserVMtoUser(uvm), id);
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult ChangePassword()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(UserViewModel uvm)
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult ForgotPassword()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult ForgotPassword(UserViewModel uvm)
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
    }
}
