using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class HolidayVolunteer
    {
        public HolidayVolunteer()
        {
            ProfessionalToVolunteers = new HashSet<ProfessionalToVolunteer>();
        }

        public int IdSchedulingHoliday { get; set; }
        public int IdVolunteer { get; set; }
        public int Countjoiners { get; set; }
        public bool WithFamily { get; set; }
        public int? CountKids { get; set; }
        public int IdPrayer { get; set; }
        public bool HasCar { get; set; }
        public bool HasLicense { get; set; }
        public int? IdSettlement { get; set; }

        public virtual PrayerText IdPrayerNavigation { get; set; }
        public virtual SettlementHoliday IdS { get; set; }
        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
        public virtual ICollection<ProfessionalToVolunteer> ProfessionalToVolunteers { get; set; }
    }
}
