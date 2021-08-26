using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class ContactPersonBL: IContactPersonBL
    {
        IContactPersonDAL _IContactPersonDAL;
        IMapper _mapper;
        public ContactPersonBL(IContactPersonDAL iContactPersonDAL, IMapper mapper)
        {
            this._IContactPersonDAL = iContactPersonDAL;
            this._mapper = mapper;
        }
    }
}
