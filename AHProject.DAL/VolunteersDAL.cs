using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
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
      
        public bool AddVolunteer(Volunteer v)
        {
            try
            {
                _context.Volunteers.Add(v);
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
