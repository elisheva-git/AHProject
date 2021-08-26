using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ProfessionalToVolunteerBL: IProfessionalToVolunteerBL
    {
        IProfessionalToVolunteerDAL _IProfessionalToVolunteerDAL;
        IMapper _mapper;
        public ProfessionalToVolunteerBL(IProfessionalToVolunteerDAL iProfessionalToVolunteerDAL, IMapper mapper)
        {
            this._IProfessionalToVolunteerDAL = iProfessionalToVolunteerDAL;
            this._mapper = mapper;
        }
    }
}
