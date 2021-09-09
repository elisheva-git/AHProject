using AHProject.BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionalSettlementToHolidayController : ControllerBase
    {
        IOptionalSettlementToHolidayBL _IoptionalSettlementToHolidayBL;
        public OptionalSettlementToHolidayController(IOptionalSettlementToHolidayBL ioptionalSettlementToHolidayBL)
        {
            this._IoptionalSettlementToHolidayBL = ioptionalSettlementToHolidayBL;
        }
        [HttpGet("{idSchedulingHoliday}")]
        public ActionResult<List<OptionalSettlementToHolidayDTO>> getOptionalSettlementByHoliday(int idSchedulingHoliday)
        {
            try
            {
                return Ok(_IoptionalSettlementToHolidayBL.getOptionalSettlementByHoliday(idSchedulingHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost("{newExperience}")]
        public bool ChangeOptional([FromRoute] int newExperience, [FromBody] OptionalSettlementToHolidayDTO optionalSettlementToHoliday)
        {
            try
            {
                _IoptionalSettlementToHolidayBL.ChangeOptional(optionalSettlementToHoliday, newExperience);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
