//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeedAngel.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
        public Nullable<int> DispensaryId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Type { get; set; }
    
        public virtual Dispensary Dispensary { get; set; }
    }
}
