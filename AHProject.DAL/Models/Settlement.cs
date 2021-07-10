using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Settlement
    {
        public Settlement()
        {
            OptionalSettlementToHolidays = new HashSet<OptionalSettlementToHoliday>();
            ProfessionalToSchedulingHolidays = new HashSet<ProfessionalToSchedulingHoliday>();
            SettlementHoliday1s = new HashSet<SettlementHoliday1>();
            SettlementHolidays = new HashSet<SettlementHoliday>();
            VolunteersSettlementHolidays = new HashSet<VolunteersSettlementHoliday>();
        }

        public int IdSettlement { get; set; }
        public string NameSettlement { get; set; }
        public int IdArea { get; set; }
        public int IdContactPer { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ContactPerson IdContactPerNavigation { get; set; }
        public virtual ICollection<OptionalSettlementToHoliday> OptionalSettlementToHolidays { get; set; }
        public virtual ICollection<ProfessionalToSchedulingHoliday> ProfessionalToSchedulingHolidays { get; set; }
        public virtual ICollection<SettlementHoliday1> SettlementHoliday1s { get; set; }
        public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
        public virtual ICollection<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }
    }
}
