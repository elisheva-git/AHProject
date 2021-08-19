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
    public class OptionalVolunteerToHolidayController : ControllerBase
    {
        IOptionalVolunteerToHolidayBL _iOptionalVolunteerToHolidayBL;
        public OptionalVolunteerToHolidayController(IOptionalVolunteerToHolidayBL iOptionalVolunteerToHolidayBL)
        {
            this._iOptionalVolunteerToHolidayBL = iOptionalVolunteerToHolidayBL;
        }
        [HttpGet("{idSchedulingHoliday}")]
        public ActionResult<List<OptionalVolunteerToHolidayDTO>> getOptionalVolunteerByHoliday(int idSchedulingHoliday)
        {
            try
            {
                return Ok(_iOptionalVolunteerToHolidayBL.getOptionalVolunteerByHoliday(idSchedulingHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost]
        public bool ChangeOptional( [FromRoute]int newExperience, [FromBody] OptionalVolunteerToHolidayDTO optionalVolunteerToHoliday)
        {
            try
            {
                _iOptionalVolunteerToHolidayBL.ChangeOptional(optionalVolunteerToHoliday, newExperience);
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
