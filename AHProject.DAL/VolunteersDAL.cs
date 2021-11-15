using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class VolunteersDAL:IVolunteersDAL
    {
        AHDBContext _context;
        public VolunteersDAL(AHDBContext context)
        {
            this._context = context;
        }
      
        public bool AddVolunteer(Volunteer volunteer)
        {
            try
            {
                Volunteer volunteerExist = null;
               volunteerExist= _context.Volunteers.FirstOrDefault(v=>v.IdentityNumber==volunteer.IdentityNumber);
                if (volunteerExist != null)
                {
                    return false;
                }
                _context.Volunteers.Add(volunteer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Updateolunteer(Volunteer volunteer)
        {
            try
            {
                //Volunteer volunteerToUpdate = _context.Volunteers.SingleOrDefault(v => v.IdVolunteer == id);
                //_context.Volunteers.Update(volunteerToUpdate);
                _context.Volunteers.Update(volunteer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Volunteer> GetVolunteers()
        {
            return _context.Volunteers.Where(v=>v.IsActive).ToList();
        }
        public Volunteer GetVolunteerById(int id)
        {

            Volunteer volunteer = _context.Volunteers.FirstOrDefault(v => v.IdVolunteer == id);
            return volunteer;
        }
        public bool ChangeStatus(Volunteer volunteerToChange)
        {
            //לעשות בדיקה באיזה עוד טבלאות למחוק
            try
            {
                Volunteer volunteer = _context.Volunteers.FirstOrDefault(v => v.IdVolunteer == volunteerToChange.IdVolunteer);
                if (volunteer.IsActive == true)
                {
                    _context.OptionalVolunteerToHolidays.Where(v => v.IdVolunteer == volunteer.IdVolunteer && v.IdSchedulingHolidayNavigation.IsOpen == true).ToList().ForEach(v =>
                          {
                              _context.OptionalVolunteerToHolidays.Remove(v);
                              _context.SaveChanges();
                          });
                    _context.HolidayVolunteers.Where(v => v.IdVolunteer == volunteer.IdVolunteer && v.IdSchedulingHolidayNavigation.IsOpen == true).ToList().ForEach(v =>
                    {
                        _context.HolidayVolunteers.Remove(v);
                        _context.SaveChanges();
                    });
                }
                volunteer.IsActive = !volunteer.IsActive;

                _context.Update(volunteer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsPlaced(int volunteer)
        {
            try
            {
                Volunteer v = _context.Volunteers.First(s => s.IdVolunteer == volunteer);
                //HolidayVolunteer one = v.HolidayVolunteers.FirstOrDefault(vo=>vo.IdSchedulingHolidayNavigation.IsOpen==true);
                OptionalVolunteerToHoliday two = v.OptionalVolunteerToHolidays.FirstOrDefault(s => s.IdSchedulingHolidayNavigation.IsOpen == true);
                if (two != default)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
