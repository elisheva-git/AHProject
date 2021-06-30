using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IHolidaysBL
    {
        public List<HolidaysDTO> GetHolidaysBL();
        public HolidaysDTO GetHolidayByIdBL(int id);
        public bool DeleteHolidayBL(int id);
    }
}