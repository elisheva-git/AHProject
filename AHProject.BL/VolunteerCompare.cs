using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AHProject.BL
{
    class VolunteerCompare: IComparer<HolidayVolunteer>
    {
        SettlementHoliday settlement;
        public VolunteerCompare(SettlementHoliday settlementHoliday)
        {
            settlement = settlementHoliday;
        }
        public int Compare([AllowNull] HolidayVolunteer x, [AllowNull] HolidayVolunteer y)
        {
            List<Professional> professionalsSettlement = settlement.ProfessionalToSchedulingHolidays.ToList().Select(p => p.IdProfessionalNavigation).ToList();
            int countProffesionalsX = x.ProfessionalToVolunteers.Count(p => professionalsSettlement.Contains(p.IdProfessionalNavigation));
            int countProffesionalsY = y.ProfessionalToVolunteers.Count(p => professionalsSettlement.Contains(p.IdProfessionalNavigation));
            if (countProffesionalsX > countProffesionalsY)
            {
                return -1;
            }
            if (countProffesionalsY > countProffesionalsX)
            {
                return 1;
            }
            if (x.Countjoiners == settlement.AmountPeopleConsumed && y.Countjoiners != settlement.AmountPeopleConsumed)
            {
                return 1;
            }
            if (y.Countjoiners == settlement.AmountPeopleConsumed)
            {
                return -1;
            }
            if (x.IdPrayer == settlement.IdPrayer && y.IdPrayer!=settlement.IdPrayer)
            {
                return -1;
            }
            if(y.IdPrayer == settlement.IdPrayer)
            {
                return 1;
            }
            return 0;
            throw new NotImplementedException();
        }
    }
}
