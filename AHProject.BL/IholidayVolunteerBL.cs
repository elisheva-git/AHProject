using DTO;

namespace AHProject.BL
{
    public interface IHolidayVolunteerBL
    {
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);

    }
}