using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IHolidayVolunteerDAL
    {
        public bool AddHolidayVolunteer(HolidayVolunteer volunteerHoliday);
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday);
        public List<HolidayVolunteer> GetVolunteersBySchedulingHoliday(int schedulingHoliday);
        public List<HolidayVolunteer> GetVolunteersBySettlement(int settlementId);


    }
}