using AHProject.DAL.Models;
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
                if (settlementExist != null)
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
        public List<SettlementHoliday> GetSettlementsBySchedulingHoliday(int schedulingHoliday)
        {
            try
            {
                return _context.SettlementHolidays.Where(s => s.IdSchedulingHoliday == schedulingHoliday).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SettlementHoliday GetSettlementHoliday(int schedulingHoliday,int settlement)
        {
            try
            {
                return _context.SettlementHolidays.First(s => s.IdSchedulingHoliday == schedulingHoliday && s.IdSettlement == settlement);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
