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
    public class VolunteerController : ControllerBase{
        IVolunteersBL _volunteersBL;
        public VolunteerController(IVolunteersBL volunteersBL)
        {
            this._volunteersBL = volunteersBL;
        }
        [HttpPost]
        public ActionResult<bool> AddVolunteer(VolunteersDTO volunteer)
        {
            try
            {
                this._volunteersBL.AddVolunteer(volunteer);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult<bool> GetVolunteers()
        {
            return Ok(true);
           // return BadRequest(); 
        }


    }
}
