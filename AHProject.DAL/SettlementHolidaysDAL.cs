using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class SettlementHolidaysDAL: ISettlementHolidaysDAL
    {
        AHDBContext _context;
        public SettlementHolidaysDAL(AHDBContext context)
        {
            this._context = context;
        }

    }
}
