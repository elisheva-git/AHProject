using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
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
        public void AddArea()
        {

        }
    }
}
