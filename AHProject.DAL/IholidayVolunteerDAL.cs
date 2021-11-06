using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IHolidayVolunteerDAL
    {
        public bool AddHolidayVolunteer(HolidayVolunteer volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);
        public List<HolidayVolunteer> GetVolunteersBySchedulingHoliday(int schedulingHoliday);
        public List<HolidayVolunteer> GetVolunteersFromHistory(int settlementId, int schedulingId);
        public void saveVolunteerToSettlement(HolidayVolunteer holidayVolunteer, int settlement);
        public List<HolidayVolunteer> GetBusyVolunteers(int schedulingId, int settlement);
        public List<HolidayVolunteer> GetVolunteersToSettlements(int schedulingId, int settlement);

    }
}