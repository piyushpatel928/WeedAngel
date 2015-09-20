using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedAngel.Models.DB;
using WeedAngel.Models.ViewModel;

namespace WeedAngel.Models.Abstract
{
  public  interface IDispensaryRepository
    {
        int insertDispensary(Dispensary ds, int userid);
        string UpadteDispensary(Dispensary ds, int id);
        Dispensary GetDispensaryData(int disid);
        List<Dispensary> GetListDispensary(int id);
        void InsertPicture(int dispenId, Picture pc);
        void InsertVideos(int dispenId, Video vd);
        List<Picture> GetListPictureFromDispensary(int Dispensaryid);
        List<Video> GetListVideosFromDispensary(int Dispensaryid);
        Video GetSingleVideo(int videoId);
        void UpdateVideo(Video vd);
        void DeletePicture(int id);
        void DeleteVideo(int id);
    }
}
