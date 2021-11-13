using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface ISchedulingHolidayBL
    {
        public bool AddSchedulingHoliday(SchedulingHolidayDTO schedulingHoliday);
        public List<SchedulingHolidayDTO> GetSchedulingHolidays();
        public bool DeleteSchedulingHoliday(int idSchedulingHoliday);
        public SchedulingHolidayDTO GetSchedulingHolidayById(int idSchedulingHoliday);
        public bool CloseScheduling(int idSchedulingHoliday);

    }
}