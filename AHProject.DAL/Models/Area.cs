using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class Area
    {
        public Area()
        {
            Settlements = new HashSet<Settlement>();
            Volunteers = new HashSet<Volunteer>();
        }

        public int IdArea { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<Settlement> Settlements { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
