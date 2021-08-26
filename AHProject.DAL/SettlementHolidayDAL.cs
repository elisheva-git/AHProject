using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class SettlementHolidayDAL: ISettlementHolidayDAL
    {
        AHDBContext _context;
        public SettlementHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }
        
    }
}
