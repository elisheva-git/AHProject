using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IProfessionalDAL
    {
        public List<Professional> GetProfessionalsById(int idHoliday);
        public List<Professional> GetProfessionals();

    }
}