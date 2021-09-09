using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IOptionalSettlementToHolidayBL
    {
        public List<OptionalSettlementToHolidayDTO> getOptionalSettlementByHoliday(int idSchedulingHoliday);
        public bool ChangeOptional(OptionalSettlementToHolidayDTO optionalSettlementToHolidayDTO, int newExperience);
    }
}