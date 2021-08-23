﻿using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class HolidayVolunteerDAL: IHolidayVolunteerDAL
    {
        AHDBContext _context;
        public HolidayVolunteerDAL(AHDBContext context)
        {
            this._context = context;
        }

        public bool AddHolidayVolunteer(HolidayVolunteer volunteerHoliday)
        {
            try
            {
                HolidayVolunteer volunteerExist = null;
                volunteerExist = _context.HolidayVolunteers.FirstOrDefault(v => v.IdVolunteer==volunteerHoliday.IdVolunteer&&v.IdSchedulingHoliday==volunteerHoliday.IdSchedulingHoliday);
                if (volunteerExist != null)
                {
                    return false;
                }
                _context.HolidayVolunteers.Add(volunteerHoliday);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday)
        {
            try
            {
                HolidayVolunteer holidayVolunteer = _context.HolidayVolunteers.FirstOrDefault(hv => hv.IdSchedulingHoliday == idSchedulingHoliday && hv.IdVolunteer == idVolunteer);
                _context.HolidayVolunteers.Remove(holidayVolunteer);
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
