using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? MinimumWorkingHours { get; set; }

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
