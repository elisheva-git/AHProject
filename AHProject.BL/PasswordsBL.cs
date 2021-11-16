using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.BL
{
    public class PasswordsBL: IPasswordsBL
    {
        IPasswordsDAL _IPasswordsDAL;
        IMapper _mapper;
        public PasswordsBL(IPasswordsDAL IPasswordsDAL, IMapper mapper)
        {
            this._IPasswordsDAL = IPasswordsDAL;
            this._mapper = mapper;
        }
        public bool checkPassword(string pass)
        {
            return _IPasswordsDAL.checkPassword(pass);
        }
        public bool AddPassword(string pass)
        {
            try
            {
                return _IPasswordsDAL.AddPassword(pass);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> GetPasswords()
        {
            try
            {
                return _IPasswordsDAL.GetPasswords().Select(pas => pas.PasswordNumber).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
