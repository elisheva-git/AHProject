using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IHolidayVolunteerBL
    {
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);
        public List<HolidayVolunteerDTO> GetVolunteersBySchedulingHoliday(int schedulingHoliday);
        public List<HolidayVolunteerDTO> GetVolunteersBySettlement(int settlementId, int schedulingId);
        public void saveVolunteerToSettlement(HolidayVolunteerDTO holidayVolunteer, int settlement);
        public List<List<HolidayVolunteerDTO>> GetVolunteersToScheduling(int settlementId, int schedulingId);
        public void deleteVolunteerFromSettlement(HolidayVolunteerDTO holidayVolunteer);
    }
}