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
                bool res= this._volunteersBL.AddVolunteer(volunteer);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet]
        public ActionResult<List<VolunteersDTO>> GetVolunteers()
        {
            try
            {
                return Ok(_volunteersBL.GetVolunteers());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            // return BadRequest(); 
        }
        [HttpGet("{id}")]
        public ActionResult<VolunteersDTO> GetVolunteerById(int id)
        {
            try
            {
                return Ok(_volunteersBL.GetVolunteerById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<bool> UpdateVolunteer([FromBody] VolunteersDTO volunteerToUpdate)
        {
            try
            {
                return Ok( _volunteersBL.Updateolunteer(volunteerToUpdate));
            }
            catch (Exception)
            {
                return BadRequest(false);
            }
        }
        [HttpPut("[action]")]
        public ActionResult<bool> ChangeStatus([FromBody] VolunteersDTO volunteerToChange)
        {
            try
            {
                return Ok(_volunteersBL.ChangeStatus(volunteerToChange));
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }
     

    }
}
