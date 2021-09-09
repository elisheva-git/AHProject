using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IOptionalSettlementToHolidayDAL
    {
        public void addSettlements(int idSchedulingHoliday);
        public void removeSettlements(int idSchedulingHoliday);
        public List<OptionalSettlementToHoliday> getOptionalSettlementByHoliday(int idSchedulingHoliday);
        public bool ChangeOptional(OptionalSettlementToHoliday optionalSettlementToHoliday, int newExperience);
    }
}