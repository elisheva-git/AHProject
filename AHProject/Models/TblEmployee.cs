using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }
        public string Telephone { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateBeginWork { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblDepartment Department { get; set; }
    }
}
