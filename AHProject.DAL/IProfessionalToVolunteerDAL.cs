using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IProfessionalToVolunteerDAL
    {
        public void AddProfessionalsToVolunteer(List<Professional> professionals, int idSchedulingHoliday, int idVolunteer);
    }
}