using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class VolunteersSettlementHolidayDTO
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdVolunteer { get; set; }

        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Settlement IdSettlementNavigation { get; set; }
        //public virtual Volunteer IdVolunteerNavigation { get; set; }

    }
}
