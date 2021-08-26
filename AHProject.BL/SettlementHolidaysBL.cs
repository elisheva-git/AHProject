using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class SettlementHolidaysBL: ISettlementHolidaysBL
    {
        ISettlementHolidaysDAL _ISettlementHolidaysDAL;
        IMapper _mapper;
        public SettlementHolidaysBL(ISettlementHolidaysDAL iSettlementHolidaysDAL, IMapper mapper)
        {
            this._ISettlementHolidaysDAL = iSettlementHolidaysDAL;
            this._mapper = mapper;
        }
    }
}
