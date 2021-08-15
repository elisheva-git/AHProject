﻿using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<OptionalVolunteerToHoliday> getOptionalVolunteerByHoliday(int idSchedulingHoliday)
        {
            try
            {
                return _context.OptionalVolunteerToHolidays.Where(opv => opv.IdSchedulingHoliday == idSchedulingHoliday).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
