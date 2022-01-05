using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IHolidaysDAL
    {
        //public List<Holiday> GetHolidaysDAL();
        public Holiday GetHolidayByIdDAL(int id);
        public bool DeleteHolidayDAL(int id);
        public List<Professional> GetProfessionalsHolidayDAL(int id);
        public List<Holiday> GetHolidays();
        public void AddHoliday(string name, List<Professional> professionals);
    }
}