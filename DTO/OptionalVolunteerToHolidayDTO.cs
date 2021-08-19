using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OptionalVolunteerToHolidayDTO
    {
        public int IdVolunteer { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdExperience { get; set; }

        public VolunteersDTO Volunteer { get; set; }

        //public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
