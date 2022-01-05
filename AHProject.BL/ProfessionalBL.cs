using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ProfessionalBL: IProfessionalBL
    {
        IProfessionalDAL _IprofessionalDAL;
        IMapper _mapper;
        public ProfessionalBL(IProfessionalDAL iprofessionalDAL, IMapper mapper)
        {
            this._IprofessionalDAL = iprofessionalDAL;
            this._mapper = mapper;
        }
        public List<ProfessionalDTO> GetProfessionalsById(int idHoliday)
        {
            try
            {
                List<Professional> professionals = _IprofessionalDAL.GetProfessionalsById(idHoliday);
                return _mapper.Map<List<Professional>, List<ProfessionalDTO>>(professionals);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfessionalDTO> GetProfessionals()
        {
            try
            {
                List<Professional> professionals = _IprofessionalDAL.GetProfessionals();
                return _mapper.Map<List<Professional>, List<ProfessionalDTO>>(professionals);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddProfessional(ProfessionalDTO professional)
        {
            try
            {
                _IprofessionalDAL.AddProfessional(_mapper.Map<ProfessionalDTO, Professional>(professional));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
