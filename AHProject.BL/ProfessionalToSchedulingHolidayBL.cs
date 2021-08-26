using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ProfessionalToSchedulingHolidayBL: IProfessionalToSchedulingHolidayBL
    {
        IProfessionalToSchedulingHolidayDAL _IProfessionalToSchedulingHolidayDAL;
        IMapper _mapper;
        public ProfessionalToSchedulingHolidayBL(IProfessionalToSchedulingHolidayDAL iProfessionalToSchedulingHolidayDAL, IMapper mapper)
        {
            this._IProfessionalToSchedulingHolidayDAL = iProfessionalToSchedulingHolidayDAL;
            this._mapper = mapper;
        }
    }
}
