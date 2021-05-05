using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Professional
    {
        public Professional()
        {
            ProfessionalHolidays = new HashSet<ProfessionalHoliday>();
        }

        public int IdProfessional { get; set; }
        public string DescriptionProfessional { get; set; }

        public virtual ICollection<ProfessionalHoliday> ProfessionalHolidays { get; set; }
    }
}
