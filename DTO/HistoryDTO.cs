using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HistoryDTO
    {
        public HolidayVolunteerDTO Volunteer { get; set; }
        public SettlementHolidayDTO Settlement { get; set; }
        public SchedulingHolidayDTO Scheduling { get; set; }
    }
}
