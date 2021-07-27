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
        public SchedulingHolidayDAL(AHDBContext context, IOptionalVolunteerToHolidayDAL OptionalVolunteerToHolidayDAL)
        {
            this._context = context;
            _OptionalVolunteerToHolidayDAL = OptionalVolunteerToHolidayDAL;
        }
        public bool AddSchedulingHoliday(SchedulingHoliday schedulingHoliday)
        {
            try
            {
                if (_context.SchedulingHolidays.FirstOrDefault(s=>s.IdHoliday==schedulingHoliday.IdHoliday&&s.YearHoliday==schedulingHoliday.YearHoliday)==null)
                {
                    _context.SchedulingHolidays.Add(schedulingHoliday);
                    _context.SaveChanges();
                    _OptionalVolunteerToHolidayDAL.addVolunteers(schedulingHoliday.IdSchedulingHoliday);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
