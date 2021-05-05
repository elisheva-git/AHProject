using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PrayerTextDTO
    {
        //public PrayerText()
        //{
        //    HolidayVolunteers = new HashSet<HolidayVolunteer>();
        //    SettlementHolidays = new HashSet<SettlementHoliday>();
        //}

        public int IdPrayer { get; set; }
        public string NamePrayer { get; set; }

        //public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        //public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
    }
}
