using AHProject.DAL.Models;

namespace AHProject.DAL
{
    public interface ISchedulingHolidayDAL
    {
        public bool AddSchedulingHoliday(SchedulingHoliday schedulingHoliday);
    }
}