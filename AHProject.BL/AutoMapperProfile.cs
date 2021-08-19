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
            CreateMap<PrayerText, PrayerTextDTO>();
            CreateMap <PrayerTextDTO, PrayerText> ();

            CreateMap<Settlement, SettlementDTO>().ForMember(dest => dest.ContactPer, src => src.MapFrom<ContactPerson>(d => d.IdContactPerNavigation));
            CreateMap<SettlementDTO, Settlement>().ForMember(dest => dest.IdContactPerNavigation, src => src.MapFrom(d => d.ContactPer));
            CreateMap <Volunteer, VolunteersDTO> ();
            CreateMap <VolunteersDTO, Volunteer> ();
            CreateMap <ExperienceOptional, ExperienceOptionalDTO> ();
            CreateMap <ExperienceOptionalDTO, ExperienceOptional > ();
            CreateMap <Holiday, HolidaysDTO> ();
            CreateMap <HolidaysDTO, Holiday > ();
            CreateMap<SchedulingHoliday, SchedulingHolidayDTO>();
            CreateMap<SchedulingHoliday, SchedulingHolidayDTO>().ForMember(d=>d.Descripation,o=>o.MapFrom(s=>s.IdHolidayNavigation.DescriptionHoliday));

            //CreateMap<SchedulingHolidayDTO, SchedulingHoliday>();
            //CreateMap<SchedulingHolidayDTO, SchedulingHoliday>().ForMember(d=>d.IdHolidayNavigation.DescriptionHoliday,o=>o.MapFrom(s=>s.Descripation));
            CreateMap <HolidayVolunteer, HolidayVolunteerDTO> ();
            CreateMap <SettlementHoliday, SettlementHolidayDTO> ();
            CreateMap <SettlementHolidayDTO, SettlementHoliday > ();
            CreateMap <VolunteersSettlementHoliday, VolunteersSettlementHolidayDTO> ();
            CreateMap <VolunteersSettlementHolidayDTO, VolunteersSettlementHoliday > ();
            CreateMap <ContactPerson, ContactPersonDTO> ();
            CreateMap <ContactPersonDTO, ContactPerson> ();
            //CreateMap <OptionalVolunteerToHoliday, OptionalVolunteerToHolidayDTO> ();
            //CreateMap <OptionalVolunteerToHolidayDTO, OptionalVolunteerToHoliday> ();

            CreateMap<OptionalVolunteerToHoliday, OptionalVolunteerToHolidayDTO>().ForMember(dest => dest.Volunteer, act => act.MapFrom(src => src.IdVolunteerNavigation));
            CreateMap<OptionalVolunteerToHolidayDTO, OptionalVolunteerToHoliday>();

            CreateMap <Professional, ProfessionalDTO> ();
            CreateMap <ProfessionalDTO, Professional> ();
            CreateMap <ProfessionalHoliday, ProfessionalHolidaysDTO> ();
            CreateMap <ProfessionalHolidaysDTO, ProfessionalHoliday> ();
            CreateMap <SettlementHolidays, SettlementHolidaysDTO> ();
            CreateMap <SettlementHolidaysDTO, SettlementHolidays> (); 
            CreateMap <Password, PasswordsDTO> ();
            CreateMap <PasswordsDTO, Password> ();
            CreateMap <ProfessionalToSchedulingHoliday, ProfessionalToSchedulingHolidayDTO> ();
            CreateMap <ProfessionalToSchedulingHolidayDTO, ProfessionalToSchedulingHoliday> ();
            CreateMap <ProfessionalToVolunteer, ProfessionalToVolunteerDTO> ();
            CreateMap <ProfessionalToVolunteerDTO, ProfessionalToVolunteer> ();
            CreateMap <OptionalSettlementToHoliday, OptionalSettlementToHolidayDTO> ();
            CreateMap <OptionalSettlementToHolidayDTO, OptionalSettlementToHoliday> ();


        }
    }
}
