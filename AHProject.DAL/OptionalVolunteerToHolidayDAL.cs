using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class OptionalVolunteerToHolidayDAL: IOptionalVolunteerToHolidayDAL
    {
        AHDBContext _context;
        public OptionalVolunteerToHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }
        public void addVolunteers(int idSchedulingHoliday)
        {
            foreach (var volunteer in _context.Volunteers)
            {
                OptionalVolunteerToHoliday optionalVolunteer = new OptionalVolunteerToHoliday();
                optionalVolunteer.IdExperience = null;
                optionalVolunteer.IdSchedulingHoliday =idSchedulingHoliday;
                optionalVolunteer.IdVolunteer = volunteer.IdVolunteer;
                _context.OptionalVolunteerToHolidays.Add(optionalVolunteer);
            };
            _context.SaveChanges();
        }
    }
}
