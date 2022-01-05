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
        //public List<Holiday> GetHolidaysDAL()
        //{
        //    return _context.Holidays.ToList();
        //}
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

        public List<Professional> GetProfessionalsHolidayDAL(int id)
        {
            return _context.Holidays.First(h => h.IdHoliday == id).ProfessionalHolidays.ToList()
                .Select(p => p.IdProfessionalNavigation).ToList();
        }

        //public bool DeleteProfessionalHoliday(string prof)
        //{
        //    int idProf = _context.Professionals.First(p => p.DescriptionProfessional == prof).IdProfessional;
        //    _context.ProfessionalHolidays.First(p=> p.IdProfessional == idProf).
        //}
        public List<Holiday> GetHolidays()
        {
            return _context.Holidays.ToList();
        }

        public void AddHoliday(string name,List<Professional> professionals)
        {
            try
            {
                _context.Holidays.Add(new Holiday() { DescriptionHoliday=name});
                _context.SaveChanges();
                Holiday holiday = _context.Holidays.First(h => h.DescriptionHoliday == name);
                professionals.ForEach(p =>
                {
                    holiday.ProfessionalHolidays.Add(new ProfessionalHoliday() { IdHoliday = holiday.IdHoliday, IdProfessional = p.IdProfessional });
                });
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
