using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IProfessionalBL
    {
        public List<ProfessionalDTO> GetProfessionalsById(int idHoliday);
        public List<ProfessionalDTO> GetProfessionals();
        public void AddProfessional(ProfessionalDTO professional);
    }
}