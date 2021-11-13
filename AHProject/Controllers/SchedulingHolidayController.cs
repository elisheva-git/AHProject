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
        [HttpGet]
        public ActionResult<List<SchedulingHolidayDTO>> GetSchedulingHoliday()
        {
            try
            {
                return Ok(_ISchedulingHolidayBL.GetSchedulingHolidays());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{idSchedulingHoliday}")]
        public ActionResult<SchedulingHolidayDTO> GetSchedulingHolidayById(int idSchedulingHoliday)
        {
            try
            {
                return Ok(_ISchedulingHolidayBL.GetSchedulingHolidayById(idSchedulingHoliday));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{idSchedulingHoliday}")]
        public ActionResult<bool> DeleteSchedulingHoliday(int idSchedulingHoliday)
        {
            try
            {
                return _ISchedulingHolidayBL.DeleteSchedulingHoliday(idSchedulingHoliday);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
      
        [HttpPut("[action]/{idSchedulingHoliday}")]
        public bool CloseScheduling(int idSchedulingHoliday)
        {
            try
            {
                return _ISchedulingHolidayBL.CloseScheduling(idSchedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
