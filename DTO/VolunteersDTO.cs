using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class VolunteersDTO
    {

        public int IdVolunteer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Gmail { get; set; }
        public int IdArea { get; set; }
        public bool IsActive { get; set; }


    }
}
