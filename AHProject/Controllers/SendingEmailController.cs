using AHProject.BL;
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
    public class SendingEmailController : ControllerBase
    {
        ISendingEmailBL _ISendingEmailBL;
        public SendingEmailController(ISendingEmailBL ISendingEmailBL)
        {
            this._ISendingEmailBL = ISendingEmailBL;
        }
        [HttpGet("[action]/{schedulingHoliday}")]
        public ActionResult sendToContactPersonOfSettlements(int schedulingHoliday)
        {
            try
            {
                _ISendingEmailBL.sendToContactPersonOfSettlements(schedulingHoliday);
                return Ok();
            }
            catch (Exception)
            {

                throw;
                return BadRequest();
            }
        }
        [HttpGet("[action]/{schedulingHoliday}")]
        public ActionResult sendToVolunteers(int schedulingHoliday)
        {
            try
            {
                _ISendingEmailBL.sendToVolunteers(schedulingHoliday);
                return Ok();
            }
            catch (Exception)
            {

                throw;
                return BadRequest();
            }
        }

    }
}
