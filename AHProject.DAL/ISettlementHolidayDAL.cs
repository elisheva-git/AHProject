using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface ISettlementHolidayDAL
    {
        public bool AddSettlementHoliday(SettlementHoliday settlementHoliday);
        public List<SettlementHoliday> GetSettlementsBySchedulingHoliday(int schedulingHoliday);
        public SettlementHoliday GetSettlementHoliday(int schedulingHoliday, int settlement);

    }
}