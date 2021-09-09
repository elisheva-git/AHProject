using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
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
        public bool AddSettlementHoliday(SettlementHolidayDTO settlementHoliday)
        {
            try
            {
                SettlementHoliday settlement = _mapper.Map<SettlementHolidayDTO, SettlementHoliday>(settlementHoliday);
                return _ISettlementHolidayDAL.AddSettlementHoliday(settlement);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
