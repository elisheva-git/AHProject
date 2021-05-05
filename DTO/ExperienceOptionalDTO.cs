using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ExperienceOptionalDTO
    {
        //public ExperienceOptional()
        //{
        //    OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
        //    SettlementHolidays = new HashSet<SettlementHoliday>();
        //}

        public int IdExperience { get; set; }
        public string DescriptionExperience { get; set; }

        //public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        //public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
    }
}
