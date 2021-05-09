using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AreaDTO,Area>();
            CreateMap<Area,AreaDTO > ();
            CreateMap<ContactPersonDTO, ContactPerson>();
            CreateMap<ContactPerson, ContactPersonDTO>();


        }
    }
}
