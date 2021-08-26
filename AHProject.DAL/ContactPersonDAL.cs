using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class ContactPersonDAL: IContactPersonDAL
    {
        AHDBContext _context;
        public ContactPersonDAL(AHDBContext context)
        {
            this._context = context;
        }
    }
}
