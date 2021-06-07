using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class SettlementBL: ISettlementBL
    {
        ISettlementDAL _ISettlementDAL;
        IMapper _mapper;
        public SettlementBL(ISettlementDAL ISettlementDAL, IMapper mapper)
        {
            this._ISettlementDAL = ISettlementDAL;
            this._mapper = mapper;
        }
        public bool AddSettlement(SettlementDTO settlement)
        {
            try
            {
                Settlement newSettlement = _mapper.Map<SettlementDTO, Settlement>(settlement);
                newSettlement.IdSettlement = 0;
                return _ISettlementDAL.AddSettlement(newSettlement);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
