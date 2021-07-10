using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public interface IVolunteersDAL
    {
        public bool AddVolunteer(Volunteer v);
        public List<Volunteer> GetVolunteers();
        public Volunteer GetVolunteerById(int id);
        public bool Updateolunteer(Volunteer volunteer);
        public bool ChangeStatus(Volunteer volunteerToChange);




    }
}
