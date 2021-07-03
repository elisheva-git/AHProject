using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public double? PermanentDiscount { get; set; }
        public int? EmployeeContactPerson { get; set; }
    }
}
