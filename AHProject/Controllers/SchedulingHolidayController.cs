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
    public class SchedulingHolidayController : ControllerBase
    {
        ISchedulingHolidayBL _ISchedulingHolidayBL;
        public SchedulingHolidayController(ISchedulingHolidayBL iSchedulingHolidayBL)
        {
            this._ISchedulingHolidayBL = iSchedulingHolidayBL;
        }

        [HttpPost]
        public ActionResult<bool> AddSchedulingHoliday([FromBody] SchedulingHolidayDTO schedulingHoliday)
        {
            try
            {
                bool res = this._ISchedulingHolidayBL.AddSchedulingHoliday(schedulingHoliday);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
