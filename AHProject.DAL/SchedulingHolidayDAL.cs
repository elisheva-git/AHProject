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
        public SchedulingHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }
        public bool AddSchedulingHoliday(SchedulingHoliday schedulingHoliday)
        {
            try
            {
                if (_context.SchedulingHolidays.FirstOrDefault(s=>s.IdHoliday==schedulingHoliday.IdHoliday&&s.YearHoliday==schedulingHoliday.YearHoliday)==null)
                {
                    _context.SchedulingHolidays.Add(schedulingHoliday);
                    _context.SaveChanges();

                    foreach (var volunteer in _context.Volunteers)
                    {
                        OptionalVolunteerToHoliday optionalVolunteer = new OptionalVolunteerToHoliday();
                        //optionalVolunteer.IdExperience=null;

                        optionalVolunteer.IdSchedulingHoliday = schedulingHoliday.IdSchedulingHoliday;
                        optionalVolunteer.IdVolunteer = volunteer.IdVolunteer;
                        _context.OptionalVolunteerToHolidays.Add(optionalVolunteer);
                    };
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
