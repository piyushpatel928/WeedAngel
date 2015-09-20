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
    public class PropertiesController : Controller
    {
        //
        // GET: /Properties/
        public DispensaryMaps disMaps = new DispensaryMaps();
        public DoctorMaps drmaps = new DoctorMaps();
        public MailVM mvm = new MailVM();
        public IDispensaryRepository _dbds { get; set; }
        public IDoctorRepository _dbdr { get; set; }
        public IUserRepository _db { get; set; }
        public PropertiesController(IDispensaryRepository dbds, IDoctorRepository dbdr, IUserRepository db)
        {
            _dbds = dbds;
            _dbdr = dbdr;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }
        public ActionResult PropertyDetail()
        {
            return View();
        }
        public ActionResult SearchDispensaries()
        {
            if (Session["UserId"] != null)
            {
                int disId = 1;
                int userid = int.Parse(Session["UserId"].ToString());
                return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(disId), _db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult ViewDispensaries(int id)
        {
            if (Session["UserId"] != null)
            {
                //int disId = 1;
                int userid = 1;
                return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(id), _db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult AddDispensaries()
        {
            if (Session["UserId"] != null)
            {
                int userid = 1;
                return View(disMaps.UserToDispenasaryVM(_db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddDispensaries(DispensariesViewModel disvm)
        {
            if (Session["UserId"] != null)
            {
                int userid = int.Parse(Session["UserId"].ToString());
                int dispensaryId = _dbds.insertDispensary(disMaps.DispensaryVMtoDispenary(disvm), userid);
                Session["dispensaryId"] = dispensaryId.ToString();
                return RedirectToAction("AddDispensariesDetail", "Properties");
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult AddDispensariesDetail()
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int disId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(disId), _db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }

        [HttpPost]
        public ActionResult AddDispensariesDetail(DispensariesViewModel disvm, HttpPostedFileBase avtar)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {

                    int dispensaryId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
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
                            var path = Path.Combine(Server.MapPath("~/DispensaryImages/"), fileName);
                            avtar.SaveAs(path);
                            string path1 = "~/DispensaryImages/" + fileName;
                            disvm.AvtarName = avtar.FileName;
                            disvm.AvtarPathName = path1;
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Image.";
                            return View();
                        }
                    }
                    ViewBag.success = "Dispensary Successfully Updated";
                    _dbds.UpadteDispensary(disMaps.DispensaryVMtoDispenary(disvm), dispensaryId);
                   // return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(dispensaryId), _db.GetUserProfile(userid)));
                    return RedirectToAction("Dispensaries", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }


        public ActionResult Pictures()
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenid = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.lstPicturetoLstPictureVM(_dbds.GetListPictureFromDispensary(dispenid), _db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }

        public ActionResult AddNewPictures()
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenid = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.UsertoPivVdVM(_db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }
        [HttpPost]
        public ActionResult AddNewPictures(AddPictureVideoViewModel apvm, HttpPostedFileBase picture)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {

                    int dispenaryid = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    if (picture != null && picture.ContentLength > 0)
                    {
                        string ext = picture.FileName;
                        ext = ext.Substring(ext.LastIndexOf("."));
                        if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                        {
                            var fileName = Path.GetFileName(picture.FileName);
                            string originalpath = picture.FileName;
                            fileName = fileName.Substring(0, fileName.LastIndexOf(".") - 1);
                            fileName = fileName + DateTime.Now.Ticks.ToString() + ext;
                            var path = Path.Combine(Server.MapPath("~/Pictures/"), fileName);
                            picture.SaveAs(path);
                            string path1 = "~/Pictures/" + fileName;
                            apvm.PictureName = picture.FileName;
                            apvm.PictureSource = path1;
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Image.";
                            return View();
                        }
                    }


                    _dbds.InsertPicture(dispenaryid, disMaps.PictureViewModelTopicture(apvm));
                    return RedirectToAction("Pictures", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult Videos()
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.lstVideotoLstVideoVM(_dbds.GetListVideosFromDispensary(dispenId), _db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }

        public ActionResult AddNewVideos()
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.UsertoPivVdVM(_db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }
        [HttpPost]
        public ActionResult AddNewVideos(AddPictureVideoViewModel apvm)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenaryid = int.Parse(Session["dispensaryId"].ToString());
                    string str = apvm.VideoSource.Substring(31).ToString();
                    apvm.VideoImageSrc = "http://i1.ytimg.com/vi/" + str + "/hqdefault.jpg";
                    _dbds.InsertVideos(dispenaryid, disMaps.VideoViewModelToVideo(apvm));
                    return RedirectToAction("Videos", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }
        public ActionResult EditVideo(int id)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    return View(disMaps.VideoEditToVideoVM(_dbds.GetSingleVideo(id), _db.GetUserProfile(userid)));

                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult EditVideo(AddPictureVideoViewModel apvm)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    string str = apvm.VideoSource.Substring(31).ToString();
                    apvm.VideoImageSrc = "http://i1.ytimg.com/vi/" + str + "/hqdefault.jpg";
                    _dbds.UpdateVideo(disMaps.VideoViewModelToVideo(apvm));
                    return RedirectToAction("Videos", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult DeletePicture(int id)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    _dbds.DeletePicture(id);
                    return RedirectToAction("Pictures", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult DeleteVideo(int id)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int dispenId = int.Parse(Session["dispensaryId"].ToString());
                    int userid = int.Parse(Session["UserId"].ToString());
                    _dbds.DeleteVideo(id);
                    return RedirectToAction("Videos", "Properties");
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }


        public ActionResult EditDispensary(int id)
        {
            if (Session["UserId"] != null)
            {
                Session["dispensaryId"] = id.ToString();
                int userid = int.Parse(Session["UserId"].ToString());
                return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(id), _db.GetUserProfile(userid)));

            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult EditDispensary(DispensariesViewModel disvm, HttpPostedFileBase avtar)
        {
            if (Session["UserId"] != null)
            {
                if (Session["dispensaryId"] != null)
                {
                    int userid = int.Parse(Session["UserId"].ToString());
                    int dispensaryId = int.Parse(Session["dispensaryId"].ToString());
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
                            var path = Path.Combine(Server.MapPath("~/DispensaryImages/"), fileName);
                            avtar.SaveAs(path);
                            string path1 = "~/DispensaryImages/" + fileName;
                            disvm.AvtarName = avtar.FileName;
                            disvm.AvtarPathName = path1;
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Image.";
                            return View();
                        }
                    }

                    _dbds.UpadteDispensary(disMaps.DispensaryVMtoDispenary(disvm), dispensaryId);
                    ViewBag.success = "Dispensary Successfully Updated";
                    return View(disMaps.DispenaryToDispenaryVM(_dbds.GetDispensaryData(dispensaryId), _db.GetUserProfile(userid)));
                }
                else
                {
                    return RedirectToAction("AddDispensaries", "Properties");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult Dispensaries()
        {
            if (Session["UserId"] != null)
            {

                int userid = int.Parse(Session["UserId"].ToString());
                return View(disMaps.listDspNUserProfileToLisDisVM(_dbds.GetListDispensary(userid), _db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }


        public ActionResult AddDoctor()
        {
            if (Session["UserId"] != null)
            {

                int userid = int.Parse(Session["UserId"].ToString());
                return View(drmaps.DoctorUsertoDoctorVM(_db.GetUserProfile(userid)));
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddDoctor(DoctorViewModel docvm, HttpPostedFileBase avtar)
        {
            if (Session["UserId"] != null)
            {

                if (avtar != null && avtar.ContentLength > 0)
                {
                    string ext = avtar.FileName;
                    ext = ext.Substring(ext.LastIndexOf("."));
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                    {
                        var fileName = Path.GetFileName(avtar.FileName);
                        string originalpath = avtar.FileName;
                        fileName = fileName.Substring(0, fileName.LastIndexOf(".") - 1);
                        fileName = fileName + DateTime.Now.Ticks.ToString() + ext;
                        var path = Path.Combine(Server.MapPath("~/DoctorsAvtars/"), fileName);
                        avtar.SaveAs(path);
                        string path1 = "~/DoctorsAvtars/" + fileName;
                        docvm.AvtarName = avtar.FileName;
                        docvm.AvtarPathName = path1;
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Image.";
                        return View();
                    }
                }
                ViewBag.success = "Doctor Added Successfully ";
                int i = _dbdr.InsertDoctor(drmaps.DoctorVMtoDoctor(docvm));
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }

        }
    }
}
