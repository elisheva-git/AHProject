using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class SettlementHoliday
    {
        public SettlementHoliday()
        {
            HolidayVolunteers = new HashSet<HolidayVolunteer>();
            ProfessionalToSchedulingHolidays = new HashSet<ProfessionalToSchedulingHoliday>();
        }

        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int AmountPeopleConsumed { get; set; }
        public int IdPrayer { get; set; }
        public bool IsSynagogue { get; set; }
        public bool IsSeferTora { get; set; }
        public string AdditionalNeeds { get; set; }

        public virtual PrayerText IdPrayerNavigation { get; set; }
        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Settlement IdSettlementNavigation { get; set; }
        public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        public virtual ICollection<ProfessionalToSchedulingHoliday> ProfessionalToSchedulingHolidays { get; set; }
    }
}
