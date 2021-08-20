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
            
            Volunteer volunteer = _context.Volunteers.FirstOrDefault(v=>v.IdVolunteer==id);
            return volunteer;
        }
        public bool ChangeStatus(Volunteer volunteerToChange)
        {
            try
            {
                Volunteer volunteer = _context.Volunteers.FirstOrDefault(v => v.IdVolunteer == volunteerToChange.IdVolunteer);
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
    }
}
