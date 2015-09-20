using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeedAngel.Models.Abstract;
using WeedAngel.Models.DB;

namespace WeedAngel.Models.Repo
{
    public class DoctorRepository : IDoctorRepository
    {
        WeedAngelEntities db = new WeedAngelEntities();
        public int InsertDoctor(Doctor dr)
        {
           
            try
            {
                db.Doctors.Add(dr);
                db.SaveChanges();
                var data = db.Doctors.OrderByDescending(a => a.DoctorId).FirstOrDefault(a => a.DoctorName == dr.DoctorName);
                return data.DoctorId;
            }
            catch
            {
                return 0;
            }
        }
    }
}