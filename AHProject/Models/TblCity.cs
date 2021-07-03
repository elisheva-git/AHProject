using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
