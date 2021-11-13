using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class HistoryBL:IHistoryBL
    {
        IHolidayVolunteerDAL _IHolidayVolunteerDAL;
        IMapper _mapper;
        public HistoryBL(IHolidayVolunteerDAL iHolidayVolunteerDAL, IMapper mapper)
        {
            this._IHolidayVolunteerDAL = iHolidayVolunteerDAL;
            this._mapper = mapper;
        }

        public List<HistoryDTO> GetHistory()
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers = _IHolidayVolunteerDAL.GetHolidayVolunteers();
                return _mapper.Map<List<HolidayVolunteer>, List<HistoryDTO>>(holidayVolunteers);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
