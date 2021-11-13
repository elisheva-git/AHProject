using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HolidaysDTO
    {
        //public Holiday()
        //{
        //    ProfessionalHolidays = new HashSet<ProfessionalHoliday>();
        //    SchedulingHolidays = new HashSet<SchedulingHoliday>();
        //    SettlementHoliday1s = new HashSet<SettlementHoliday1>();
        //}

        public int IdHoliday { get; set; }
        public string DescriptionHoliday { get; set; }
       // public ProfessionalDTO Professionals { get; set; }

        public virtual ICollection<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        //public virtual ICollection<SchedulingHoliday> SchedulingHolidays { get; set; }
        //public virtual ICollection<SettlementHoliday1> SettlementHoliday1s { get; set; }
    }
}
