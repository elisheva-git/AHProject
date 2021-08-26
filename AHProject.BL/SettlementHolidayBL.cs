using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class SettlementHolidayBL: ISettlementHolidayBL
    {
        ISettlementHolidayDAL _ISettlementHolidayDAL;
        IMapper _mapper;
        public SettlementHolidayBL(ISettlementHolidayDAL iSettlementHolidayDAL, IMapper mapper)
        {
            this._ISettlementHolidayDAL = iSettlementHolidayDAL;
            this._mapper = mapper;
        }
    }
}
