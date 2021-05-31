using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class VolunteersDTO
    {
        //public Volunteer()
        //{
        //    HolidayVolunteers = new HashSet<HolidayVolunteer>();
        //    OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
        //    VolunteersSettlementHolidays = new HashSet<VolunteersSettlementHoliday>();
        //}

        public int IdVolunteer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Gmail { get; set; }
        public int IdArea { get; set; }
        public bool IsActive { get; set; }

        //public virtual Area IdAreaNavigation { get; set; }
        //public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        //public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        //public virtual ICollection<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }

    }
}
