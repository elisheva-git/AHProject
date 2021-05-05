using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class VolunteersSettlementHoliday
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdVolunteer { get; set; }

        public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        public virtual Settlement IdSettlementNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
