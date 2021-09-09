using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
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
        public List<OptionalSettlementToHolidayDTO> getOptionalSettlementByHoliday(int idSchedulingHoliday)
        {
            try
            {
                List<OptionalSettlementToHoliday> settlementToHolidays = _IOptionalSettlementToHolidayDAL.getOptionalSettlementByHoliday(idSchedulingHoliday);
                return _mapper.Map<List<OptionalSettlementToHoliday>, List<OptionalSettlementToHolidayDTO>>(settlementToHolidays);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ChangeOptional(OptionalSettlementToHolidayDTO optionalSettlementToHolidayDTO, int newExperience)
        {
            try
            {
                OptionalSettlementToHoliday  optionalSettlement= _mapper.Map<OptionalSettlementToHolidayDTO, OptionalSettlementToHoliday>(optionalSettlementToHolidayDTO);
                return _IOptionalSettlementToHolidayDAL.ChangeOptional(optionalSettlement, newExperience);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
