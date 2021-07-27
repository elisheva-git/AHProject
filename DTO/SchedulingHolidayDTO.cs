using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SchedulingHolidayDTO
    {
        //public SchedulingHoliday()
        //{
        //    HolidayVolunteers = new HashSet<HolidayVolunteer>();
        //    OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
        //    SettlementHolidays = new HashSet<SettlementHoliday>();
        //    VolunteersSettlementHolidays = new HashSet<VolunteersSettlementHoliday>();
        //}
        public int IdHoliday { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int YearHoliday { get; set; }
        public bool IsOpen { get; set; }


        //public virtual Holiday IdHolidayNavigation { get; set; }
        //public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        //public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        //public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
        //public virtual ICollection<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }

    }
}
