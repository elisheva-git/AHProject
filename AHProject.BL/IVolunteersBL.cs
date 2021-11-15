using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IVolunteersBL
    {
        public bool AddVolunteer(VolunteersDTO volunteer);
        public List<VolunteersDTO> GetVolunteers();
        public VolunteersDTO GetVolunteerById(int id);
        public bool Updateolunteer(VolunteersDTO volunteer);
        public bool ChangeStatus(VolunteersDTO volunteerToChange);
        public bool IsPlaced(int volunteer);
    }
}