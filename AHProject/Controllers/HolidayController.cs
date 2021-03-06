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
    public class HolidayController : ControllerBase
    {
        IHolidaysBL _IHolidaysBL;
        public HolidayController(IHolidaysBL IHolidaysBL)
        {
            this._IHolidaysBL = IHolidaysBL;
        }
        
        [HttpGet]
        public ActionResult<List<HolidaysDTO>> GetHolidays()
        {
            return Ok(_IHolidaysBL.GetHolidays());
        }
        [HttpGet("{id}")]
        public ActionResult<HolidaysDTO> GetHolidayBy(int id)
        {
            return Ok(_IHolidaysBL.GetHolidayByIdBL(id));
        }
        
        [HttpDelete("{id}")]
        public ActionResult< bool> DeleteHoliday(int id)
        {
            return _IHolidaysBL.DeleteHolidayBL(id);
        }
        [HttpPost("[action]")]
        public ActionResult<bool> AddHoliday(HolidaysDTO holiday)
        {
            try
            {
                _IHolidaysBL.AddHoliday(holiday);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(false);
            }
        }

    }
}
