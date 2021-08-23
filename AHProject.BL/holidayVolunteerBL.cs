using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class HolidayVolunteerBL: IHolidayVolunteerBL
    {
        IHolidayVolunteerDAL _IHolidayVolunteerDAL;
        IMapper _mapper;
        public HolidayVolunteerBL(IHolidayVolunteerDAL IHolidayVolunteerDAL, IMapper mapper)
        {
            this._IHolidayVolunteerDAL = IHolidayVolunteerDAL;
            this._mapper = mapper;
        }
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday)
        {
            try
            {
                HolidayVolunteer holidayVolunteer = _mapper.Map<HolidayVolunteerDTO, HolidayVolunteer>(volunteerHoliday);
                return _IHolidayVolunteerDAL.AddHolidayVolunteer(holidayVolunteer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday)
        {
            try
            {
                return _IHolidayVolunteerDAL.DeleteHolidayVolunteer(idVolunteer,idSchedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
