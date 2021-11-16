
using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IPasswordsBL
    {
        public bool checkPassword(string pass);
        public bool AddPassword(string pass);
        public List<string> GetPasswords();
    }
}