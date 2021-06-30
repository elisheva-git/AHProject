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
    }
}
