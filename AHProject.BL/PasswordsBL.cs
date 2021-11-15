using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
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
    }
}
