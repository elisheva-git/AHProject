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
    public class HolidayVolunteerController : ControllerBase
    {
        IHolidayVolunteerBL _IholidayVolunteerBL;
        public HolidayVolunteerController(IHolidayVolunteerBL holidayVolunteerBL)
        {
            this._IholidayVolunteerBL = holidayVolunteerBL;
        }
        [HttpPost]
        public ActionResult<bool> AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday)
        {
            try
            {
                return Ok(_IholidayVolunteerBL.AddHolidayVolunteer(volunteerHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpDelete]
        public ActionResult<bool> DeleteHolidayVolunteer(int idVolunteer,int idSchedulingHoliday)
        {
            try
            {
                return Ok(_IholidayVolunteerBL.DeleteHolidayVolunteer(idVolunteer,idSchedulingHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpGet("{schedulingHoliday}")]
        public  ActionResult<List<HolidayVolunteerDTO>> GetVolunteersBySchedulingHoliday(int schedulingHoliday)
        {
            try
            {
                return Ok( _IholidayVolunteerBL.GetVolunteersBySchedulingHoliday(schedulingHoliday));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("[action]/{settlementId}/{schedulingId}")]
        public ActionResult< List<HolidayVolunteerDTO>> GetVolunteersBySettlement(int settlementId, int schedulingId)
        {
            try
            {
                return Ok(_IholidayVolunteerBL.GetVolunteersBySettlement(settlementId,schedulingId));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("[action]/{settlement}")]
        public ActionResult<bool> saveVolunteerToSettlement( int settlement, HolidayVolunteerDTO holidayVolunteer)
        {
            try
            {
                _IholidayVolunteerBL.saveVolunteerToSettlement(holidayVolunteer, settlement);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
                return BadRequest(false);
            }
        }
        [HttpGet("[action]/{settlementId}/{schedulingId}")]
        public ActionResult<List<List<HolidayVolunteerDTO>>> GetVolunteersToScheduling(int settlementId, int schedulingId)
        {
            try
            {
                return Ok( _IholidayVolunteerBL.GetVolunteersToScheduling(settlementId, schedulingId));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
