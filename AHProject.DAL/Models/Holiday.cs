using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Holiday
    {
        public Holiday()
        {
            ProfessionalHolidays = new HashSet<ProfessionalHoliday>();
            SchedulingHolidays = new HashSet<SchedulingHoliday>();
            SettlementHoliday1s = new HashSet<SettlementHoliday1>();
        }

        public int IdHoliday { get; set; }
        public string DescriptionHoliday { get; set; }

        public virtual ICollection<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        public virtual ICollection<SchedulingHoliday> SchedulingHolidays { get; set; }
        public virtual ICollection<SettlementHoliday1> SettlementHoliday1s { get; set; }
    }
}
