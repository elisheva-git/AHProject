using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProfessionalToVolunteerDTO
    {
        public int IdVolunteer { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdProfessional { get; set; }

        //public virtual Professional IdProfessionalNavigation { get; set; }
        //public virtual SchedulingHoliday IdSchedulingHolidayNavigation { get; set; }
        //public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
