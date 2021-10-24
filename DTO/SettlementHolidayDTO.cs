using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SettlementHolidayDTO
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int AmountPeopleConsumed { get; set; }
        public int IdPrayer { get; set; }
        public bool IsSynagogue { get; set; }
        public bool IsSeferTora { get; set; }
        public string AdditionalNeeds { get; set; }
        public List<int> Professionals { get; set; }
        public SettlementDTO Settlement { get; set; }

        //public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        //public virtual PrayerText IdPrayerNavigation { get; set; }
        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Settlement IdSettlementNavigation { get; set; }

    }
}
