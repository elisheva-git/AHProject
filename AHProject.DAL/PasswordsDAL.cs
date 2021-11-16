using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool checkPassword(string pass)
        {
            if (this._context.Passwords.FirstOrDefault(p => p.PasswordNumber == pass) != default)
            {
                return true;
            }
            return false;
        }
        public bool AddPassword(string pass)
        {
            if (pass!=null&&this._context.Passwords.FirstOrDefault(p => p.PasswordNumber == pass) == default)
            {
                this._context.Passwords.Add(new Password() { PasswordNumber = pass });
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Password> GetPasswords()
        {
            try
            {
                return _context.Passwords.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
