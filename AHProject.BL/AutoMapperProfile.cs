using AHProject.DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            CreateMap<Settlement, SettlementDTO>().ForMember(dest => dest.ContactPer, src => src.MapFrom(d => d.IdContactPerNavigation)).ForMember(dest=>dest.AreaName,src=>src.MapFrom(s=>s.IdAreaNavigation.AreaName));
            //CreateMap<SettlementDTO, Settlement>().ForMember(dest => dest.IdContactPerNavigation, src => src.MapFrom(d => d.ContactPer)).ForPath(dest => dest.IdAreaNavigation.AreaName, src => src.MapFrom(s => s.AreaName));
            CreateMap<SettlementDTO, Settlement>().ForMember(dest => dest.IdContactPerNavigation, src => src.MapFrom(d => d.ContactPer));

            CreateMap <Volunteer, VolunteersDTO> ();
            CreateMap <VolunteersDTO, Volunteer> ();
            CreateMap <ExperienceOptional, ExperienceOptionalDTO> ();
            CreateMap <ExperienceOptionalDTO, ExperienceOptional > ();
            CreateMap <Holiday, HolidaysDTO> ();
            CreateMap <HolidaysDTO, Holiday > ();
            //CreateMap<SchedulingHolidayDTO, SchedulingHoliday>().ForPath(dest=>dest.IdHolidayNavigation.DescriptionHoliday,src=>src.MapFrom(s=>s.Descripation));
            CreateMap<SchedulingHolidayDTO, SchedulingHoliday>();

            CreateMap<SchedulingHoliday, SchedulingHolidayDTO>().ForMember(d=>d.Descripation,o=>o.MapFrom(s=>s.IdHolidayNavigation.DescriptionHoliday));
            CreateMap<int, ProfessionalToVolunteer>().ConvertUsing((src, dest) =>
            new ProfessionalToVolunteer { IdProfessional = src }
            );
            CreateMap<HolidayVolunteer, HolidayVolunteerDTO>().ForMember(dest => dest.Professionals, src => src.MapFrom(v => v.ProfessionalToVolunteers));
            CreateMap<HolidayVolunteerDTO, HolidayVolunteer>().ForMember(dest => dest.ProfessionalToVolunteers, src => src.MapFrom(v => v.Professionals));
            CreateMap<int, ProfessionalToSchedulingHoliday>().ConvertUsing((src, dest) =>
            new ProfessionalToSchedulingHoliday { IdProfessional = src }
            );

            //CreateMap <SettlementHoliday, SettlementHolidayDTO> ().ForMember(dest => dest.Professionals, src => src.MapFrom(v => v.));
            CreateMap <SettlementHolidayDTO, SettlementHoliday > ();
            CreateMap <VolunteersSettlementHoliday, VolunteersSettlementHolidayDTO> ();
            CreateMap <VolunteersSettlementHolidayDTO, VolunteersSettlementHoliday > ();
            CreateMap <ContactPerson, ContactPersonDTO> ();
            CreateMap <ContactPersonDTO, ContactPerson> ();

            CreateMap<OptionalVolunteerToHoliday, OptionalVolunteerToHolidayDTO>().ForMember(dest => dest.Volunteer, act => act.MapFrom(src => src.IdVolunteerNavigation))
                .ForMember(dest=>dest.Icon,src=>src.MapFrom(i=>i.IdExperienceNavigation.Icon));
            CreateMap<OptionalVolunteerToHolidayDTO, OptionalVolunteerToHoliday>().ForPath(dest=>dest.IdExperienceNavigation.Icon,src=>src.MapFrom(i=>i.Icon)).
                ForMember(dest=>dest.IdVolunteerNavigation,src=>src.MapFrom(v=>v.Volunteer));

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
            CreateMap <OptionalSettlementToHoliday, OptionalSettlementToHolidayDTO> ().ForMember(dest=>dest.Settlement,src=>src.MapFrom(s=>s.IdSettlementNavigation)).
                ForMember(dest=>dest.Icon,src=>src.MapFrom(i=>i.IdExperienceNavigation.Icon));
            CreateMap <OptionalSettlementToHolidayDTO, OptionalSettlementToHoliday> ().ForPath(dest=>dest.IdSettlementNavigation,src=>src.MapFrom(s=>s.Settlement)).
                ForPath(dest=>dest.IdExperienceNavigation.Icon,src=>src.MapFrom(i=>i.Icon));


        }
    }
}
