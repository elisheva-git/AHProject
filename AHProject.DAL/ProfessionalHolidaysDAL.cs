using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class ProfessionalHolidaysDAL: IProfessionalHolidaysDAL
    {
        AHDBContext _context;
        public ProfessionalHolidaysDAL(AHDBContext context)
        {
            this._context = context;
        }
    }
}
