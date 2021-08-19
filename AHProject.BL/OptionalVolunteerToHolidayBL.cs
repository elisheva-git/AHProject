using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class OptionalVolunteerToHolidayBL: IOptionalVolunteerToHolidayBL
    {
        IOptionalVolunteerToHolidayDAL _IOptionalVolunteerToHolidayDAL;
        IMapper _mapper;
        public OptionalVolunteerToHolidayBL(IOptionalVolunteerToHolidayDAL iOptionalVolunteerToHolidayDAL, IMapper mapper)
        {
            this._IOptionalVolunteerToHolidayDAL = iOptionalVolunteerToHolidayDAL;
            this._mapper = mapper;
        }
        public List<OptionalVolunteerToHolidayDTO> getOptionalVolunteerByHoliday(int idSchedulingHoliday)
        {
            try
            {
                List<OptionalVolunteerToHoliday> volunteers = _IOptionalVolunteerToHolidayDAL.getOptionalVolunteerByHoliday(idSchedulingHoliday);
                return _mapper.Map<List<OptionalVolunteerToHoliday>, List<OptionalVolunteerToHolidayDTO>>(volunteers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ChangeOptional(OptionalVolunteerToHolidayDTO optionalVolunteerToHoliday, int newExperience)
        {
            try
            {
                OptionalVolunteerToHoliday optionalVolunteerToHolidaymap = _mapper.Map<OptionalVolunteerToHolidayDTO, OptionalVolunteerToHoliday>(optionalVolunteerToHoliday);
                return _IOptionalVolunteerToHolidayDAL.ChangeOptional(optionalVolunteerToHolidaymap, newExperience);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
