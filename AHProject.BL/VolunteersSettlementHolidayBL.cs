using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class VolunteersSettlementHolidayBL: IVolunteersSettlementHolidayBL
    {
        IVolunteersSettlementHolidayDAL _IVolunteersSettlementHolidayDAL;
        IMapper _mapper;
        public VolunteersSettlementHolidayBL(IVolunteersSettlementHolidayDAL iVolunteersSettlementHolidayDAL, IMapper mapper)
        {
            this._IVolunteersSettlementHolidayDAL = iVolunteersSettlementHolidayDAL;
            this._mapper = mapper;
        }
    }
}
