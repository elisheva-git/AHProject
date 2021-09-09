﻿using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool AddSettlementHoliday(SettlementHoliday settlementHoliday)
        {
            try
            {
                SettlementHoliday settlementExist = null;
                settlementExist = _context.SettlementHolidays.ToList().FirstOrDefault(s => s.IdSettlement == settlementHoliday.IdSettlement && s.IdSchedulingHoliday == settlementHoliday.IdSchedulingHoliday);
                if (settlementHoliday != null)
                {
                    return false;
                }
                _context.SettlementHolidays.Add(settlementHoliday);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
