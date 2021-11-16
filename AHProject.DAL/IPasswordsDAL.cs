using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IPasswordsDAL
    {
        public bool checkPassword(string pass);
        public bool AddPassword(string pass);
        public List<Password> GetPasswords();
    }
}