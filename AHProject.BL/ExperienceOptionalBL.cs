using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ExperienceOptionalBL: IExperienceOptionalBL
    {
        IExperienceOptionalDAL _IExperienceOptionalDAL;
        IMapper _mapper;
        public ExperienceOptionalBL(IExperienceOptionalDAL IExperienceOptionalDAL, IMapper mapper)
        {
            this._IExperienceOptionalDAL = IExperienceOptionalDAL;
            this._mapper = mapper;
        }

        public List<ExperienceOptionalDTO> GetExperienceOptionals()
        {
            try
            {
                List<ExperienceOptional> experienceOptionals = _IExperienceOptionalDAL.GetExperienceOptionals();
                return _mapper.Map<List<ExperienceOptional>,List<ExperienceOptionalDTO>>(experienceOptionals);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
