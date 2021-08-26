using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class ProfessionalToSchedulingHolidayDAL: IProfessionalToSchedulingHolidayDAL
    {
        AHDBContext _context;
        public ProfessionalToSchedulingHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }
    }
}
