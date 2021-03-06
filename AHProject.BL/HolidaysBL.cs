using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class HolidaysBL: IHolidaysBL
    {
        IHolidaysDAL _IHolidaysDAL;
        IMapper _mapper;
        public HolidaysBL(IHolidaysDAL IHolidaysDAL, IMapper mapper)
        {
            this._IHolidaysDAL = IHolidaysDAL;
            this._mapper = mapper;
        }

        public HolidaysDTO GetHolidayByIdBL(int id)
        {
            Holiday holiday = _IHolidaysDAL.GetHolidayByIdDAL(id);
            return _mapper.Map<Holiday, HolidaysDTO>(holiday);

        }

        public bool DeleteHolidayBL(int id)
        {
            return _IHolidaysDAL.DeleteHolidayDAL(id);

        }

        public List<HolidaysDTO> GetHolidays()
        {
            try
            {
                List<Holiday> holidays = _IHolidaysDAL.GetHolidays();
                return _mapper.Map<List<Holiday>, List<HolidaysDTO>>(holidays);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddHoliday(HolidaysDTO holiday)
        {
            try
            {
                List<Professional> professionals = _mapper.Map<List<ProfessionalDTO>, List<Professional>>(holiday.Professionals);
                 _IHolidaysDAL.AddHoliday(holiday.DescriptionHoliday,professionals);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
