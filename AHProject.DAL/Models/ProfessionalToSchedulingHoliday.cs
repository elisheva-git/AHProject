using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class ProfessionalToSchedulingHoliday
    {
        public int IdSettlement { get; set; }
        public int IdSchedulingHoliday { get; set; }
        public int IdProfessional { get; set; }

        public virtual Professional IdProfessionalNavigation { get; set; }
        public virtual SettlementHoliday IdS { get; set; }
    }
}
