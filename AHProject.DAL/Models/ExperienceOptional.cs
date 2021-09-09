using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class ExperienceOptional
    {
        public ExperienceOptional()
        {
            OptionalSettlementToHolidays = new HashSet<OptionalSettlementToHoliday>();
            OptionalVolunteerToHolidays = new HashSet<OptionalVolunteerToHoliday>();
        }

        public int IdExperience { get; set; }
        public string DescriptionExperience { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<OptionalSettlementToHoliday> OptionalSettlementToHolidays { get; set; }
        public virtual ICollection<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
    }
}
