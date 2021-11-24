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
    public class PrayerTextController : ControllerBase
    {
        IPrayerTextBL _IPrayerTextBL;
        public PrayerTextController(IPrayerTextBL iPrayerTextBL)
        {
            this._IPrayerTextBL = iPrayerTextBL;
        }
        [HttpGet("[action]")]
        public ActionResult<List<PrayerTextDTO>> GetPrayerTexts()
        {
            try
            {
                return Ok(_IPrayerTextBL.GetPrayerTexts());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public void AddPrayerText(PrayerTextDTO prayer)
        {
            try
            {
                _IPrayerTextBL.AddPrayerText(prayer);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
