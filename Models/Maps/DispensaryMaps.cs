using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.DB;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Models.Maps
{
    public class DispensaryMaps
    {

        public string GetStringFromNull(string Value)
        {
            return (Value == null) ? "" : Value;

        }

        public bool GetboolFromNull(bool Value)
        {
            return (Value == false) ? false : true;

        }
        public Dispensary DispensaryVMtoDispenary(DispensariesViewModel dsvm)
        {
            Dispensary ds = new Dispensary();
            if (dsvm != null)
            {
                ds.Body = dsvm.Body;
                ds.City = dsvm.City;
                ds.Country = dsvm.Country;
                ds.DispensaryName = dsvm.DispensaryName;
                ds.Email = dsvm.Email;
                ds.State = dsvm.State;
                ds.Street = dsvm.Street;
                ds.Facebook = dsvm.FacebookPage;
                ds.Instagram = dsvm.InstagramPage;
                ds.Twitter = dsvm.TwitterPage;
                ds.IntroBody = dsvm.IntroBody;
                if (dsvm.Is18plus != null)
                {
                    ds.Is18 = dsvm.Is18plus;
                }
                else
                {
                    ds.Is18 = false;
                }
                if (dsvm.Is21plus != null)
                {
                    ds.Is21 = dsvm.Is21plus;
                }
                else
                {
                    ds.Is21 = false;
                }
                if (dsvm.IsAcceptCreditCard != null)
                {
                    ds.IsCreditCards = dsvm.IsAcceptCreditCard;
                }
                else
                {
                    ds.IsCreditCards = false;
                }
                if (dsvm.IsSecurityGuard != null)
                {
                    ds.IsSecurityGuard = dsvm.IsSecurityGuard;
                }
                else
                {
                    ds.IsSecurityGuard = false;
                }
                if (dsvm.IsPicture != null)
                {
                    ds.IsPictures = dsvm.IsPicture;
                }
                else
                {
                    ds.IsPictures = false;
                }
                if (dsvm.IsLounge != null)
                {
                    ds.IsLounge = dsvm.IsLounge;
                }
                else
                {
                    ds.IsLounge = false;
                }
                if (dsvm.IsHandicapAccess != null)
                {
                    ds.IsHandicap = dsvm.IsHandicapAccess;
                }
                else
                {
                    ds.IsHandicap = false;
                }
                if (dsvm.IsVideo != null)
                {
                    ds.IsVideos = dsvm.IsVideo;
                }
                else
                {
                    ds.IsVideos = false;
                }
                ds.PhoneNo = dsvm.MobileNo;
                ds.SunDayClose = dsvm.SundayClose;
                ds.SunDayOpen = dsvm.SundayOpen;
                ds.MonDayClose = dsvm.MondayClose;
                ds.MonDayOpen = dsvm.MondayOpen;
                ds.TuesDayClose = dsvm.TuesdayClose;
                ds.TuesDayOpen = dsvm.TuesdayOpen;
                ds.WednesDayClose = dsvm.WednesdayClose;
                ds.WednesDayOpen = dsvm.WednesdayOpen;
                ds.ThursDayClose = dsvm.ThursdayClose;
                ds.ThursDayOpen = dsvm.ThursdayOpen;
                ds.FriDayClose = dsvm.FridayClose;
                ds.FriDayOpen = dsvm.FridayOpen;
                ds.SaturDayClose = dsvm.SaturdayClose;
                ds.SaturDayOpen = dsvm.SaturdayOpen;
                ds.RegionId = 1;
                ds.Website = dsvm.Website;
                ds.Zipcode = dsvm.ZipCode;
                ds.TimeZoneId = 1;
                if (dsvm.AvtarName != null)
                {
                    ds.AvatarName = dsvm.AvtarName;
                    ds.AvatarPath = dsvm.AvtarPathName;
                }
            }
            return ds;

        }
        public DispensariesViewModel DispenaryToDispenaryVM(Dispensary dsp, User usr)
        {
            DispensariesViewModel dsv = new DispensariesViewModel();
            if (usr != null)
            {
                dsv.UserName = usr.UserName;
                dsv.ProfImagePath = GetStringFromNull(usr.ProfileImagePath);
            }
            if (dsp != null)
            {
                dsv.AvtarName = GetStringFromNull(dsp.AvatarName);
                dsv.AvtarPathName = GetStringFromNull(dsp.AvatarPath);
                if (dsp.DispensaryId != 0)
                {
                    dsv.DispensaryId = dsp.DispensaryId;
                }
                dsv.Body = GetStringFromNull(dsp.Body);
                dsv.City = GetStringFromNull(dsp.City);
                dsv.Country = GetStringFromNull(dsp.Country);
                dsv.DispensaryName = GetStringFromNull(dsp.DispensaryName);
                dsv.Email = GetStringFromNull(dsp.Email);
                dsv.State = GetStringFromNull(dsp.State);
                dsv.Street = GetStringFromNull(dsp.Street);
                dsv.FacebookPage = GetStringFromNull(dsp.Facebook);
                dsv.InstagramPage = GetStringFromNull(dsp.Instagram);
                dsv.TwitterPage = GetStringFromNull(dsp.Twitter);
                dsv.IntroBody = GetStringFromNull(dsp.IntroBody);
                dsv.Is18plus = GetboolFromNull((bool)dsp.Is18);
                dsv.Is21plus = GetboolFromNull((bool)dsp.Is21);
                dsv.IsAcceptCreditCard = GetboolFromNull((bool)dsp.IsCreditCards);
                dsv.IsHandicapAccess = GetboolFromNull((bool)dsp.IsHandicap);
                dsv.IsLounge = GetboolFromNull((bool)dsp.IsLounge);
                dsv.IsPicture = GetboolFromNull((bool)dsp.IsPictures);
                dsv.IsSecurityGuard = GetboolFromNull((bool)dsp.IsSecurityGuard);
                dsv.IsVideo = GetboolFromNull((bool)dsp.IsVideos);
                dsv.MobileNo = GetStringFromNull(dsp.PhoneNo);
                dsv.SundayClose = GetStringFromNull(dsp.SunDayClose);
                dsv.SundayOpen = GetStringFromNull(dsp.SunDayOpen);
                dsv.MondayClose = GetStringFromNull(dsp.MonDayClose);
                dsv.MondayOpen = GetStringFromNull(dsp.MonDayOpen);
                dsv.TuesdayClose = GetStringFromNull(dsp.TuesDayClose);
                dsv.TuesdayOpen = GetStringFromNull(dsp.TuesDayOpen);
                dsv.WednesdayClose = GetStringFromNull(dsp.WednesDayClose);
                dsv.WednesdayOpen = GetStringFromNull(dsp.WednesDayOpen);
                dsv.ThursdayClose = GetStringFromNull(dsp.ThursDayClose);
                dsv.ThursdayOpen = GetStringFromNull(dsp.ThursDayOpen);
                dsv.FridayOpen = GetStringFromNull(dsp.FriDayOpen);
                dsv.FridayClose = GetStringFromNull(dsp.FriDayClose);
                dsv.SaturdayClose = GetStringFromNull(dsp.SaturDayClose);
                dsv.SaturdayOpen = GetStringFromNull(dsp.SaturDayOpen);
                dsv.Website = GetStringFromNull(dsp.Website);
                dsv.ZipCode = GetStringFromNull(dsp.Zipcode);
            }
            return dsv;

        }
        public DispensariesViewModel DispenarydataToDispenaryVM(Dispensary dsp)
        {
            DispensariesViewModel dsv = new DispensariesViewModel();
            if (dsp != null)
            {
                dsv.AvtarName = GetStringFromNull(dsp.AvatarName);
                dsv.AvtarPathName = GetStringFromNull(dsp.AvatarPath);
                if (dsp.DispensaryId != 0)
                {
                    dsv.DispensaryId = dsp.DispensaryId;
                }
                dsv.Body = GetStringFromNull(dsp.Body);
                dsv.City = GetStringFromNull(dsp.City);
                dsv.Country = GetStringFromNull(dsp.Country);
                dsv.DispensaryName = GetStringFromNull(dsp.DispensaryName);
                dsv.Email = GetStringFromNull(dsp.Email);
                dsv.State = GetStringFromNull(dsp.State);
                dsv.Street = GetStringFromNull(dsp.Street);
                dsv.FacebookPage = GetStringFromNull(dsp.Facebook);
                dsv.InstagramPage = GetStringFromNull(dsp.Instagram);
                dsv.TwitterPage = GetStringFromNull(dsp.Twitter);
                dsv.IntroBody = GetStringFromNull(dsp.IntroBody);
                dsv.Is18plus = GetboolFromNull((bool)dsp.Is18);
                dsv.Is21plus = GetboolFromNull((bool)dsp.Is21);
                dsv.IsAcceptCreditCard = GetboolFromNull((bool)dsp.IsCreditCards);
                dsv.IsHandicapAccess = GetboolFromNull((bool)dsp.IsHandicap);
                dsv.IsLounge = GetboolFromNull((bool)dsp.IsLounge);
                dsv.IsPicture = GetboolFromNull((bool)dsp.IsPictures);
                dsv.IsSecurityGuard = GetboolFromNull((bool)dsp.IsSecurityGuard);
                dsv.IsVideo = GetboolFromNull((bool)dsp.IsVideos);
                dsv.MobileNo = GetStringFromNull(dsp.PhoneNo);
                dsv.SundayClose = GetStringFromNull(dsp.SunDayClose);
                dsv.SundayOpen = GetStringFromNull(dsp.SunDayOpen);
                dsv.MondayClose = GetStringFromNull(dsp.MonDayClose);
                dsv.MondayOpen = GetStringFromNull(dsp.MonDayOpen);
                dsv.TuesdayClose = GetStringFromNull(dsp.TuesDayClose);
                dsv.TuesdayOpen = GetStringFromNull(dsp.TuesDayOpen);
                dsv.WednesdayClose = GetStringFromNull(dsp.WednesDayClose);
                dsv.WednesdayOpen = GetStringFromNull(dsp.WednesDayOpen);
                dsv.ThursdayClose = GetStringFromNull(dsp.ThursDayClose);
                dsv.ThursdayOpen = GetStringFromNull(dsp.ThursDayOpen);
                dsv.FridayOpen = GetStringFromNull(dsp.FriDayOpen);
                dsv.FridayClose = GetStringFromNull(dsp.FriDayClose);
                dsv.SaturdayClose = GetStringFromNull(dsp.SaturDayClose);
                dsv.SaturdayOpen = GetStringFromNull(dsp.SaturDayOpen);
                dsv.Website = GetStringFromNull(dsp.Website);
                dsv.ZipCode = GetStringFromNull(dsp.Zipcode);
            }
            return dsv;

        }
        public List<DispensariesViewModel> ListDspToListDisVM(List<Dispensary> lstDsp)
        {
            List<DispensariesViewModel> lstDspvm = new List<DispensariesViewModel>();
            foreach (var item in lstDsp)
            {
                lstDspvm.Add(DispenarydataToDispenaryVM(item));
            }
            return lstDspvm;
        }
        public UserDispensaryViewModel listDspNUserProfileToLisDisVM(List<Dispensary> lstDsp, User usr)
        {
            UserDispensaryViewModel udvm = new UserDispensaryViewModel();
            List<DispensariesViewModel> lstDspvm = new List<DispensariesViewModel>();
            foreach (var item in lstDsp)
            {
                lstDspvm.Add(DispenarydataToDispenaryVM(item));
            }
            udvm.lstdvm = lstDspvm;
            if (usr != null)
            {
                udvm.UserName = GetStringFromNull(usr.UserName);
                udvm.AvtarPathName = GetStringFromNull(usr.ProfileImagePath);
            }
            return udvm;
        }
        public DispensariesViewModel UserToDispenasaryVM(User usr)
        {
            DispensariesViewModel dsvm = new DispensariesViewModel();
            if (usr != null)
            {
                dsvm.UserName = GetStringFromNull(usr.UserName);
                dsvm.ProfImagePath = GetStringFromNull(usr.ProfileImagePath);
            }
            return dsvm;
        }
        public Picture PictureViewModelTopicture(AddPictureVideoViewModel apvm)
        {
            Picture pc = new Picture();
            if (apvm != null)
            {
                pc.PictureName = apvm.PictureName;
                pc.PicturePath = apvm.PictureSource;
            }
            pc.CreatedDate = DateTime.Now;
            pc.Type = "Dispensary";
            return pc;
        }
        public Video VideoViewModelToVideo(AddPictureVideoViewModel apvm)
        {
            Video vd = new Video();
            vd.VideoName = apvm.VideoName;
            vd.VideoId = apvm.VideoId;
            vd.VideoSource = apvm.VideoSource;
            vd.VideoImageSrc = apvm.VideoImageSrc;
            vd.CreatedDate = DateTime.Now;
            vd.Type = "Dispensary";
            return vd;
        }
        public AddPictureVideoViewModel pictureToPictureVM(Picture pc)
        {
            AddPictureVideoViewModel apvm = new AddPictureVideoViewModel();
            if (pc != null)
            {
                apvm.PictureName = GetStringFromNull(pc.PictureName);
                apvm.PictureSource = GetStringFromNull(pc.PicturePath);
                apvm.pictureid = pc.PictureId;
                if (pc.CreatedDate != null)
                {
                    apvm.CreatedDateTime = (DateTime)pc.CreatedDate;
                }
                apvm.Type = GetStringFromNull(pc.Type);
            }
            return apvm;
        }
        public AddPictureVideoViewModel VideoEditToVideoVM(Video vd, User usr)
        {
            AddPictureVideoViewModel apvm = new AddPictureVideoViewModel();
            if (usr != null)
            {
                apvm.VideoName = GetStringFromNull(vd.VideoName);
                apvm.VideoSource = GetStringFromNull(vd.VideoSource);
                apvm.VideoImageSrc = GetStringFromNull(vd.VideoImageSrc);
                apvm.VideoId = vd.VideoId;
                apvm.UserName = GetStringFromNull(usr.UserName);
                apvm.ProfilePath = GetStringFromNull(usr.ProfileImagePath);
                if (vd.CreatedDate != null)
                {
                    apvm.CreatedDateTime = (DateTime)vd.CreatedDate;
                }
                apvm.Type = GetStringFromNull(vd.Type);
            }
            return apvm;
        }
        public AddPictureVideoViewModel VideoToVideoVM(Video vd)
        {
            AddPictureVideoViewModel apvm = new AddPictureVideoViewModel();
            if (vd != null)
            {
                apvm.VideoName = GetStringFromNull(vd.VideoName);
                apvm.VideoSource = GetStringFromNull(vd.VideoSource);
                apvm.VideoImageSrc = GetStringFromNull(vd.VideoImageSrc);
                apvm.VideoId = vd.VideoId;
                if(vd.CreatedDate !=  null)
                {
                apvm.CreatedDateTime = (DateTime)vd.CreatedDate;
                }
                apvm.Type = vd.Type;
            }
            return apvm;
        }
        public UserDispensaryPicVideoViewModel lstPicturetoLstPictureVM(List<Picture> lstpc, User usr)
        {
            UserDispensaryPicVideoViewModel udpv = new UserDispensaryPicVideoViewModel();
            if (usr != null)
            {
                udpv.UserName = GetStringFromNull(usr.UserName);
                udpv.Profilepath = GetStringFromNull(usr.ProfileImagePath);
            }
            List<AddPictureVideoViewModel> lstpcvm = new List<AddPictureVideoViewModel>();
            foreach (var item in lstpc)
            {
                lstpcvm.Add(pictureToPictureVM(item));
            }
            udpv.lstPivVdVM = lstpcvm;
            return udpv;
        }
        public UserDispensaryPicVideoViewModel lstVideotoLstVideoVM(List<Video> lstvd, User usr)
        {
            UserDispensaryPicVideoViewModel udpv = new UserDispensaryPicVideoViewModel();
            if (usr != null)
            {
                udpv.UserName = GetStringFromNull(usr.UserName);
                udpv.Profilepath = GetStringFromNull(usr.ProfileImagePath);
            }
            List<AddPictureVideoViewModel> lstpcvm = new List<AddPictureVideoViewModel>();
            foreach (var item in lstvd)
            {
                lstpcvm.Add(VideoToVideoVM(item));
            }
            udpv.lstPivVdVM = lstpcvm;
            return udpv;
        }
        public AddPictureVideoViewModel UsertoPivVdVM(User usr)
        {
            AddPictureVideoViewModel apvvm = new AddPictureVideoViewModel();
            if (usr != null)
            {
                apvvm.UserName = GetStringFromNull(usr.UserName);
                apvvm.ProfilePath = GetStringFromNull(usr.ProfileImagePath);
            }
            return apvvm;

        }
    }
}