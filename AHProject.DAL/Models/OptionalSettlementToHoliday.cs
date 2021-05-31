using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class OptionalSettlementToHoliday
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdExperience { get; set; }

        public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Settlement IdSettlementNavigation { get; set; }
    }
}
