using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.Abstract;
using WeedAngel.Models.DB;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Models.Repo
{
    public class DispensaryRepository : IDispensaryRepository
    {
        WeedAngelEntities db = new WeedAngelEntities();
        public int insertDispensary(Dispensary ds, int userid)
        {
            ds.UserId = userid;
            ds.Is18 = false;
            ds.Is21 = false;
            ds.IsCreditCards = false;
            ds.IsHandicap = false;
            ds.IsLounge = false;
            ds.IsPictures = false;
            ds.IsSecurityGuard = false;
            ds.IsVideos = false;

            try
            {
                db.Dispensaries.Add(ds);
                db.SaveChanges();
                var data = db.Dispensaries.OrderByDescending(a => a.DispensaryId).FirstOrDefault(a => a.DispensaryName == ds.DispensaryName && a.UserId==userid );
                return data.DispensaryId;
            }
            catch
            {
                return 0;
            }


        }

        public string UpadteDispensary(Dispensary ds, int id)
        {
            var data = db.Dispensaries.FirstOrDefault(a => a.DispensaryId == id);

            try
            {
                if (data != null)
                {
                    data.DispensaryName = ds.DispensaryName;
                    data.PhoneNo = ds.PhoneNo;
                    data.Website = ds.Website;
                    data.Email = ds.Email;
                    if (ds.AvatarName != null)
                    {
                        data.AvatarName = ds.AvatarName;
                        data.AvatarPath = ds.AvatarPath;
                    }
                    data.Facebook = ds.Facebook;
                    data.Instagram = ds.Instagram;
                    data.Twitter = ds.Twitter;
                    data.IntroBody = ds.IntroBody;
                    data.Body = ds.Body;
                    data.City = ds.City;
                    data.Country = ds.Country;

                    data.Zipcode = ds.Zipcode;
                    data.State = ds.State;
                    data.Street = ds.Street;

                    data.RegionId = 1;
                    data.TimeZoneId = 1;

                    data.Is18 = ds.Is18;
                    data.Is21 = ds.Is21;
                    data.IsCreditCards = ds.IsCreditCards;
                    data.IsHandicap = ds.IsHandicap;
                    data.IsLounge = ds.IsLounge;
                    data.IsPictures = ds.IsPictures;
                    data.IsSecurityGuard = ds.IsSecurityGuard;
                    data.IsVideos = ds.IsVideos;

                    data.SunDayClose = ds.SunDayClose;
                    data.SunDayOpen = ds.SunDayOpen;
                    data.MonDayClose = ds.MonDayClose;
                    data.MonDayOpen = ds.MonDayOpen;
                    data.TuesDayClose = ds.TuesDayClose;
                    data.TuesDayOpen = ds.TuesDayOpen;
                    data.WednesDayClose = ds.WednesDayClose;
                    data.WednesDayOpen = ds.WednesDayOpen;
                    data.ThursDayClose = ds.ThursDayClose;
                    data.ThursDayOpen = ds.ThursDayOpen;
                    data.FriDayClose = ds.FriDayClose;
                    data.FriDayOpen = ds.FriDayOpen;
                    data.SaturDayClose = ds.SaturDayClose;
                    data.SaturDayOpen = ds.SaturDayOpen;


                }
                db.SaveChanges();
                return "true";
            }
            catch
            {
                return "false";
            }

        }

        public Dispensary GetDispensaryData(int disid)
        {
            var data = db.Dispensaries.FirstOrDefault(a => a.DispensaryId == disid);

            return data;
        }
        public List<Dispensary> GetListDispensary(int id)
        {
            var data = db.Dispensaries.Where(a => a.UserId == id).ToList();
            return data;

        }
        public void InsertPicture(int dispenId, Picture pc)
        {
            try
            {
                pc.DispensaryId = dispenId;
                db.Pictures.Add(pc);
                db.SaveChanges();
            }
            catch
            {
            }
        }
        public void InsertVideos(int dispenId, Video vd)
        {
            try
            {
                vd.DispensaryId = dispenId;
                db.Videos.Add(vd);
                db.SaveChanges();
            }
            catch
            {
            }
        }
        public Video GetSingleVideo(int videoId)
        {
            var data = db.Videos.FirstOrDefault(a => a.VideoId == videoId);
            return data;

        }
        public List<Picture> GetListPictureFromDispensary(int Dispensaryid)
        {
            var data = db.Pictures.Where(a => a.DispensaryId == Dispensaryid).ToList();
            return data;
        }
        public List<Video> GetListVideosFromDispensary(int Dispensaryid)
        {
            var data = db.Videos.Where(a => a.DispensaryId == Dispensaryid).ToList();
            return data;
        }

        public void DeleteVideo(int id)
        {
            var data = db.Videos.FirstOrDefault(a => a.VideoId == id);
            try
            {
                db.Videos.Remove(data);
                db.SaveChanges();

            }
            catch
            {
            }
        }
        public void DeletePicture(int id)
        {
            var data = db.Pictures.FirstOrDefault(a => a.PictureId == id);
            try
            {
                db.Pictures.Remove(data);
                db.SaveChanges();

            }
            catch
            {
            }
        }
        public void UpdateVideo(Video vd)
        {
            var data = db.Videos.FirstOrDefault(a => a.VideoId == vd.VideoId);
            try
            {
                
                data.VideoName = vd.VideoName;
                data.VideoSource = vd.VideoSource;
                data.CreatedDate = DateTime.Now;
                data.VideoImageSrc = vd.VideoImageSrc;
                db.SaveChanges();
            }
            catch
            {
            }

        }
    }
}