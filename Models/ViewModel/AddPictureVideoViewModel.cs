using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeedAngel.Models.ViewModel
{
    public class AddPictureVideoViewModel
    {
        public string PictureName { get; set; }
        public string PictureSource { get; set; }
        public int pictureid { get; set; }

        [Required(ErrorMessage = "Please Enter VideoName")]
        public string VideoName { get; set; }

        [Required(ErrorMessage = "Please Enter Video Url")]
        public string VideoSource { get; set; }
        public int VideoId { get; set; }
        public string VideoImageSrc { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Type { get; set; }
        public string UserName{ get ;set  ;}
        public string ProfilePath { get; set; }
    }
}