using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedAngel.Models.DB;

namespace WeedAngel.Models.Abstract
{
   public interface IDoctorRepository
    {
       int InsertDoctor(Doctor dr);
    }
}
