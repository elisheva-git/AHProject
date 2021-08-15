using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IOptionalVolunteerToHolidayBL
    {
        public List<OptionalVolunteerToHolidayDTO> getOptionalVolunteerByHoliday(int idSchedulingHoliday);
    }
}