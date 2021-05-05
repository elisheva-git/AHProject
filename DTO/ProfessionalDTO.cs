using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProfessionalDTO
    {
        //public Professional()
        //{
        //    ProfessionalHolidays = new HashSet<ProfessionalHoliday>();
        //}

        public int IdProfessional { get; set; }
        public string DescriptionProfessional { get; set; }

        //public virtual ICollection<ProfessionalHoliday> ProfessionalHolidays { get; set; }

    }
}
