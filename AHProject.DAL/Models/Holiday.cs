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
            SettlementHoliday1s = new HashSet<SettlementHolidays>();
        }

        public int IdHoliday { get; set; }
        public string DescriptionHoliday { get; set; }

        public virtual ICollection<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        public virtual ICollection<SchedulingHoliday> SchedulingHolidays { get; set; }
        public virtual ICollection<SettlementHolidays> SettlementHoliday1s { get; set; }
    }
}
