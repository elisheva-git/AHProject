using AHProject.DAL.Models;

namespace AHProject.DAL
{
    public interface IHolidayVolunteerDAL
    {
        public bool AddHolidayVolunteer(HolidayVolunteer volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);
    }
}