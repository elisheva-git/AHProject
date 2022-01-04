using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AHProject.BL
{
    public class VolunteersBL: IVolunteersBL
    {
        IVolunteersDAL _IVolunteersDAL;
        IMapper _mapper;
        public VolunteersBL(IVolunteersDAL _IVolunteersDAL, IMapper mapper)
        {
            this._IVolunteersDAL = _IVolunteersDAL;
            this._mapper = mapper;
        }
        public bool AddVolunteer(VolunteersDTO volunteer)
        {
            try
            {
                Volunteer newVolunteer = _mapper.Map<VolunteersDTO, Volunteer>(volunteer);
                newVolunteer.IdVolunteer = 0;
                newVolunteer.IsActive = true;
                return _IVolunteersDAL.AddVolunteer(newVolunteer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<VolunteersDTO> GetVolunteers()
        {
            List<Volunteer> volunteers = _IVolunteersDAL.GetVolunteers();
            VolunteersCompare volunteersCompare = new VolunteersCompare();
            volunteers.Sort(volunteersCompare);
            return _mapper.Map<List<Volunteer>, List<VolunteersDTO>>(volunteers);
        }
        public VolunteersDTO GetVolunteerById(int id)
        {
            Volunteer volunteer = _IVolunteersDAL.GetVolunteerById(id);
            return _mapper.Map<Volunteer, VolunteersDTO>(volunteer);
        }
        public bool Updateolunteer(VolunteersDTO volunteer)
        {
            try
            {
                Volunteer volunteerToUpdate = _mapper.Map<VolunteersDTO, Volunteer>(volunteer);
                return _IVolunteersDAL.Updateolunteer(volunteerToUpdate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ChangeStatus(VolunteersDTO volunteerToChange)
        {
            try
            {
                Volunteer volunteer= _mapper.Map<VolunteersDTO, Volunteer>(volunteerToChange);
                return _IVolunteersDAL.ChangeStatus(volunteer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool IsPlaced(int volunteer)
        {
            try
            {
                return _IVolunteersDAL.IsPlaced(volunteer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    class VolunteersCompare : IComparer<Volunteer>
    {
        public int Compare([AllowNull] Volunteer x, [AllowNull] Volunteer y)
        {
            return (x.FirstName + x.LastName).CompareTo(y.FirstName + y.LastName);
        }
    }
}
