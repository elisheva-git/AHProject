using AHProject.DAL.Models;

namespace AHProject.DAL
{
    public interface IPasswordsDAL
    {
        public bool checkPassword(string pass);
        
    }
}