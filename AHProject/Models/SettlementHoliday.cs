using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class SettlementHoliday
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int AmountPeopleConsumed { get; set; }
        public int IdPrayer { get; set; }
        public bool IsSynagogue { get; set; }
        public bool IsSeferTora { get; set; }
        public string AdditionalNeeds { get; set; }
        public int? IdExperience { get; set; }

        public virtual ExperienceOptional IdExperienceNavigation { get; set; }
        public virtual PrayerText IdPrayerNavigation { get; set; }
        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Settlement IdSettlementNavigation { get; set; }
    }
}
