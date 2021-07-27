using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface ISchedulingHolidayBL
    {
        public bool AddSchedulingHoliday(SchedulingHolidayDTO schedulingHoliday);
        public List<SchedulingHolidayDTO> GetSchedulingHolidays();

    }
}