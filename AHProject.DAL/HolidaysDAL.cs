using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class HolidaysDAL: IHolidaysDAL
    {
        AHDBContext _context;
        public HolidaysDAL(AHDBContext context)
        {
            this._context = context;
        }
        //public bool AddArea(Area area)
        //{
        //    try
        //    {
        //        _context.Areas.Add(area);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //}
        public List<Holiday> GetHolidaysDAL()
        {
            return _context.Holidays.ToList();
        }
        public Holiday GetHolidayByIdDAL(int id)
        {
            return _context.Holidays.Where(h => h.IdHoliday == id).FirstOrDefault();
        }
        public bool DeleteHolidayDAL(int id)
        {
            Holiday holidayTodelete = _context.Holidays.FirstOrDefault(h => h.IdHoliday == id);
            try
            {
                _context.Holidays.Remove(holidayTodelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }
    }
}
