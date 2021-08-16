using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IOptionalVolunteerToHolidayDAL
    {
        public void addVolunteers(int idSchedulingHoliday);
        public List<OptionalVolunteerToHoliday> getOptionalVolunteerByHoliday(int idSchedulingHoliday);
        public void removeVolunteers(int idSchedulingHoliday);
    }
}