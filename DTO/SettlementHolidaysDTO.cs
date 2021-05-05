using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SettlementHolidaysDTO
    {
        public int IdHoliday { get; set; }
        public int IdSettlement { get; set; }

        //public virtual Holiday IdHolidayNavigation { get; set; }
        //public virtual Settlement IdSettlementNavigation { get; set; }
    }
}
