using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SettlementDTO
    {
        //public Settlement()
        //{
        //    ContactPeople = new HashSet<ContactPerson>();
        //    SettlementHoliday1s = new HashSet<SettlementHoliday1>();
        //    SettlementHolidays = new HashSet<SettlementHoliday>();
        //    VolunteersSettlementHolidays = new HashSet<VolunteersSettlementHoliday>();
        //}

        public int IdSettlement { get; set; }
        public string NameSettlement { get; set; }
        public int IdArea { get; set; }

        public int IdContactPer { get; set; }
        public ContactPersonDTO ContactPer { get; set; }
        public string AreaName { get; set; }
        public bool IsActive { get; set; }
        public AreaDTO Area { get; set; }




        //public virtual Area IdAreaNavigation { get; set; }
        //public virtual ContactPerson IdContactPerNavigation { get; set; }
        //public virtual ICollection<ContactPerson> ContactPeople { get; set; }
        //public virtual ICollection<SettlementHoliday1> SettlementHoliday1s { get; set; }
        //public virtual ICollection<SettlementHoliday> SettlementHolidays { get; set; }
        //public virtual ICollection<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }

    }
}
