using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class SchedulingHolidayDAL: ISchedulingHolidayDAL
    {
        AHDBContext _context;
        IOptionalVolunteerToHolidayDAL _OptionalVolunteerToHolidayDAL;
        IOptionalSettlementToHolidayDAL _OptionalSettlementToHolidayDAL;
        public SchedulingHolidayDAL(AHDBContext context, IOptionalVolunteerToHolidayDAL OptionalVolunteerToHolidayDAL,IOptionalSettlementToHolidayDAL OptionalSettlementToHolidayDAL)
        {
            this._context = context;
            _OptionalVolunteerToHolidayDAL = OptionalVolunteerToHolidayDAL;
            _OptionalSettlementToHolidayDAL = OptionalSettlementToHolidayDAL;
        }
        public bool AddSchedulingHoliday(SchedulingHoliday schedulingHoliday)
        {
            try
            {
                if (_context.SchedulingHolidays.FirstOrDefault(s=>s.YearHoliday==schedulingHoliday.YearHoliday&&s.IdHoliday==schedulingHoliday.IdHoliday)==default) 
                {
                    _context.SchedulingHolidays.Add(schedulingHoliday);
                    _context.SaveChanges();
                    //SchedulingHoliday q = _context.SchedulingHolidays.FirstOrDefault(s => s.YearHoliday == schedulingHoliday.YearHoliday && s.IdHoliday == schedulingHoliday.IdHoliday);
                    //q.OptionalVolunteerToHolidays.Add();
                    //_context.Volunteers.ToList().ForEach(v => q.OptionalVolunteerToHolidays.Add());
                    _OptionalVolunteerToHolidayDAL.addVolunteers(schedulingHoliday.IdSchedulingHoliday);
                    _OptionalSettlementToHolidayDAL.addSettlements(schedulingHoliday.IdSchedulingHoliday);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<SchedulingHoliday> GetSchedulingHolidays()
        {
            try
            {
                return _context.SchedulingHolidays.Where(s=>s.IsValid==true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SchedulingHoliday GetSchedulingHolidayById(int idSchedulingHoliday)
        {
            try
            {
                return _context.SchedulingHolidays.First(s => s.IdSchedulingHoliday == idSchedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteSchedulingHoliday(int idSchedulingHoliday)
        {
            try
            {
                SchedulingHoliday schedulingHoliday = _context.SchedulingHolidays.First(s => s.IdSchedulingHoliday == idSchedulingHoliday);
                schedulingHoliday.IsValid = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool CloseScheduling(int idSchedulingHoliday)
        {
            try
            {
                SchedulingHoliday schedulingHoliday = _context.SchedulingHolidays.First(s => s.IdSchedulingHoliday == idSchedulingHoliday);
                schedulingHoliday.IsOpen = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<HolidayVolunteer> GetVolunteers(int idSchedulingHoliday)
        {
            try
            {
                SchedulingHoliday schedulingHoliday = GetSchedulingHolidayById(idSchedulingHoliday);
                return schedulingHoliday.HolidayVolunteers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SettlementHoliday> GetSettlements(int idSchedulingHoliday)
        {
            try
            {
                SchedulingHoliday schedulingHoliday = GetSchedulingHolidayById(idSchedulingHoliday);
                return schedulingHoliday.SettlementHolidays.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }       
    }
}
