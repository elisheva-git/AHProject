using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.DAL
{
    public class PasswordsDAL: IPasswordsDAL
    {
        AHDBContext _context;
        public PasswordsDAL(AHDBContext context)
        {
            this._context = context;
        }
        public bool checkPassword(Password pass)
        {
            if(this._context.Passwords.Find(pass)!=null)
            {
                return true;
            }
            return false;
        }

    }
}
