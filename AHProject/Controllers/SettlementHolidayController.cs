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
    public class SettlementHolidayController : ControllerBase
    {
        ISettlementHolidayBL _ISettlementHolidayBL;
        public SettlementHolidayController(ISettlementHolidayBL iSettlementHolidayBL)
        {
            this._ISettlementHolidayBL = iSettlementHolidayBL;
        }
        [HttpPost]
        public ActionResult<bool> AddSettlementHoliday(SettlementHolidayDTO settlementHoliday)
        {
            try
            {
                return Ok(_ISettlementHolidayBL.AddSettlementHoliday(settlementHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
