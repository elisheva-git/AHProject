using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblEmployeeSalary
    {
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public double SalaryAmount { get; set; }
        public double? Bonus { get; set; }
    }
}
