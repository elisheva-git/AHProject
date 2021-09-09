using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OptionalSettlementToHolidayDTO
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdExperience { get; set; }

        public SettlementDTO Settlement { get; set; }
        public string Icon { get; set; }

        //public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Settlement IdSettlementNavigation { get; set; }
    }
}
