using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HolidayVolunteerDTO
    {
        public int IdSchedulingHoliday { get; set; }
        public int IdVolunteer { get; set; }
        public int Countjoiners { get; set; }
        public bool WithFamily { get; set; }
        public int? CountKids { get; set; }
        public int IdPrayer { get; set; }
        public bool HasCar { get; set; }
        public bool HasLicense { get; set; }
        public List<ProfessionalDTO> Professionals { get; set; }

        //public virtual PrayerText IdPrayerNavigation { get; set; }
        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
