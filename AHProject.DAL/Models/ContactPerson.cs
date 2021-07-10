using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            Settlements = new HashSet<Settlement>();
        }

        public int IdContactPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gmail { get; set; }

        public virtual ICollection<Settlement> Settlements { get; set; }
    }
}
