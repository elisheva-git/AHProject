using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Professional
    {
        public Professional()
        {
            ProfessionalHolidays = new List<ProfessionalHoliday>();
            ProfessionalToSchedulingHolidays = new HashSet<ProfessionalToSchedulingHoliday>();
            ProfessionalToVolunteers = new HashSet<ProfessionalToVolunteer>();
        }

        public int IdProfessional { get; set; }
        public string DescriptionProfessional { get; set; }

        public virtual List<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        public virtual ICollection<ProfessionalToSchedulingHoliday> ProfessionalToSchedulingHolidays { get; set; }
        public virtual ICollection<ProfessionalToVolunteer> ProfessionalToVolunteers { get; set; }
    }
}
