using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class SettlementHoliday1
    {
        public int IdHoliday { get; set; }
        public int IdSettlement { get; set; }

        public virtual Holiday IdHolidayNavigation { get; set; }
        public virtual Settlement IdSettlementNavigation { get; set; }
    }
}
