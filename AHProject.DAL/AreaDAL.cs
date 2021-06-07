using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class AreaDAL : IAreaDAL
    {
        AHDBContext _context;
        public AreaDAL(AHDBContext context)
        {
            this._context = context;
        }
        public bool AddArea(Area area)
        {
            try
            {
                _context.Areas.Add(area);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<Area> GetAreas()
        {
            return _context.Areas.ToList();
        }
    }
}
