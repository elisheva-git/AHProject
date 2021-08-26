using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class ProfessionalToVolunteerDAL: IProfessionalToVolunteerDAL
    {
        AHDBContext _context;
        public ProfessionalToVolunteerDAL(AHDBContext context)
        {
            this._context = context;
        }
        public void AddProfessionalsToVolunteer(List<Professional> professionals,int idSchedulingHoliday,int idVolunteer)
        {
            try
            {
                foreach (Professional professional in professionals)
                {
                    ProfessionalToVolunteer professionalToVolunteer = new ProfessionalToVolunteer();
                    professionalToVolunteer.IdProfessional = professional.IdProfessional;
                    professionalToVolunteer.IdSchedulingHoliday = idSchedulingHoliday;
                    professionalToVolunteer.IdVolunteer = idVolunteer;
                    _context.ProfessionalToVolunteers.Add(professionalToVolunteer);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
