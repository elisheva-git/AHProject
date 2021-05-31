using AHProject.DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AreaDTO,Area>();
            CreateMap<Area,AreaDTO > ();
            CreateMap<ContactPersonDTO, ContactPerson>();
            CreateMap<ContactPerson, ContactPersonDTO>();
            CreateMap<Volunteer, VolunteersDTO>();
            CreateMap<VolunteersDTO, Volunteer>();

        }
    }
}
