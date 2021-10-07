using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            HolidayVolunteers = new HashSet<HolidayVolunteer>();
            OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
        }

        public int IdVolunteer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Gmail { get; set; }
        public int IdArea { get; set; }
        public bool IsActive { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<HolidayVolunteer> HolidayVolunteers { get; set; }
        public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
    }
}
