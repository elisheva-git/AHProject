using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public interface IVolunteersDAL
    {
        public bool AddVolunteer(Volunteer v);

    }
}
