using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class OptionalVolunteerToHoliday
    {
        public int IdVolunteer { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdExperience { get; set; }

        public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
