using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ProfessionalHolidaysBL: IProfessionalHolidaysBL
    {
        IProfessionalHolidaysDAL _IProfessionalHolidaysDAL;
        IMapper _mapper;
        public ProfessionalHolidaysBL(IProfessionalHolidaysDAL iProfessionalHolidaysDAL, IMapper mapper)
        {
            this._IProfessionalHolidaysDAL = iProfessionalHolidaysDAL;
            this._mapper = mapper;
        }
    }
}
