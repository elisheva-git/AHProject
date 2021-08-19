using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class ExperienceOptionalDAL: IExperienceOptionalDAL
    {
        AHDBContext _context;
        public ExperienceOptionalDAL(AHDBContext context)
        {
            this._context = context;
        }

        public List<ExperienceOptional> GetExperienceOptionals()
        {
            try
            {
                return _context.ExperienceOptionals.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
