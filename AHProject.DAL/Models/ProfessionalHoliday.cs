using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class ProfessionalHoliday
    {
        public int IdProfessional { get; set; }
        public int IdHoliday { get; set; }

        public virtual Holiday IdHolidayNavigation { get; set; }
        public virtual Professional IdProfessionalNavigation { get; set; }
    }
}
