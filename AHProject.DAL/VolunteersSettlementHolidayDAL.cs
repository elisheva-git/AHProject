using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class VolunteersSettlementHolidayDAL: IVolunteersSettlementHolidayDAL
    {
        AHDBContext _context;
        public VolunteersSettlementHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }

    }
}
