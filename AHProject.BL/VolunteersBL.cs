using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class VolunteersBL: IVolunteersBL
    {
        IVolunteersDAL _IVolunteersDAL;
        IMapper _mapper;
        public VolunteersBL(IVolunteersDAL _IVolunteersDAL, IMapper mapper)
        {
            this._IVolunteersDAL = _IVolunteersDAL;
            this._mapper = mapper;
        }
        public bool AddVolunteer(VolunteersDTO volunteer)
        {
            try
            {
                return _IVolunteersDAL.AddVolunteer(_mapper.Map<VolunteersDTO, Volunteer>(volunteer));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
