using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class SchedulingHoliday
    {
        public SchedulingHoliday()
        {
            HolidayVolunteers = new HashSet<HolidayVolunteer>();
            OptionalSettlementToHolidays = new HashSet<OptionalSettlementToHoliday>();
            OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
            SettlementHolidays = new HashSet<SettlementHoliday>();
        }

        public int IdSchedulingHoliday { get; set; }
        public int IdHoliday { get; set; }
        public int YearHoliday { get; set; }
        public bool? IsOpen { get; set; }

        public virtual Holiday IdHolidayNavigation { get; set; }
        public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        public virtual ICollection<OptionalSettlementToHoliday> OptionalSettlementToHolidays { get; set; }
        public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
    }
}
