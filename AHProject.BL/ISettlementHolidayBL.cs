using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface ISettlementHolidayBL
    {
        public bool AddSettlementHoliday(SettlementHolidayDTO settlementHoliday);
        public List<SettlementHolidayDTO> GetSettlementsBySchedulingHoliday(int schedulingHoliday);
    }
}