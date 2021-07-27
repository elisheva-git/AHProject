using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface ISchedulingHolidayDAL
    {
        public bool AddSchedulingHoliday(SchedulingHoliday schedulingHoliday);
        public List<SchedulingHoliday> GetSchedulingHolidays();

    }
}