using AHProject.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class OptionalSettlementToHolidayBL: IOptionalSettlementToHolidayBL
    {
        IOptionalSettlementToHolidayDAL _IOptionalSettlementToHolidayDAL;
        IMapper _mapper;
        public OptionalSettlementToHolidayBL(IOptionalSettlementToHolidayDAL iOptionalSettlementToHolidayDAL, IMapper mapper)
        {
            this._IOptionalSettlementToHolidayDAL = iOptionalSettlementToHolidayDAL;
            this._mapper = mapper;
        }
    }
}
