using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IHolidayVolunteerBL
    {
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);
        public List<HolidayVolunteerDTO> GetVolunteersBySchedulingHoliday(int schedulingHoliday);
    }
}