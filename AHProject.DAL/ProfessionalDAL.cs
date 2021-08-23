﻿using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class ProfessionalDAL: IProfessionalDAL
    {
        AHDBContext _context;
        public ProfessionalDAL(AHDBContext context)
        {
            this._context = context;
        }
        public List<Professional> GetProfessionalsById(int idHoliday)
        {
            try
            {
                List<Professional> professionals = new List<Professional>();
                List<Professional> professionals1 = _context.Professionals.ToList();
                for (int i = 0; i < professionals1.Count; i++)
                {
                    //professionals.Add(professionals1[i].ProfessionalHolidays.Where(p => p.IdHoliday == idHoliday));
                    foreach (var item in professionals1[i].ProfessionalHolidays)
                    {
                        if (item.IdHoliday == idHoliday)
                            professionals.Add(professionals1[i]);
                    }
                }
                return professionals;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
