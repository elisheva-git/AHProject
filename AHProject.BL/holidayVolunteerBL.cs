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
        IProfessionalToVolunteerDAL _IprofessionalToVolunteer;
        IMapper _mapper;
        public HolidayVolunteerBL(IHolidayVolunteerDAL IHolidayVolunteerDAL, IMapper mapper, IProfessionalToVolunteerDAL iprofessionalToVolunteer)
        {
            this._IHolidayVolunteerDAL = IHolidayVolunteerDAL;
            this._mapper = mapper;
            _IprofessionalToVolunteer = iprofessionalToVolunteer;
        }
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday)
        {
            try
            {
                HolidayVolunteer holidayVolunteer = _mapper.Map<HolidayVolunteerDTO, HolidayVolunteer>(volunteerHoliday);
                List<Professional> professionals=_mapper.Map<List<ProfessionalDTO>,List< Professional >> (volunteerHoliday.Professionals);
                _IprofessionalToVolunteer.AddProfessionalsToVolunteer(professionals, volunteerHoliday.IdSchedulingHoliday, volunteerHoliday.IdVolunteer);
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
