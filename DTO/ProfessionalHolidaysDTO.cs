using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProfessionalHolidaysDTO
    {
        public int IdProfessional { get; set; }
        public int IdHoliday { get; set; }

        //public virtual Holiday IdHolidayNavigation { get; set; }
        //public virtual Professional IdProfessionalNavigation { get; set; }
    }
}
