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
    public class ProfessionalController : ControllerBase
    {
        IProfessionalBL _IProfessionalBL;
        public ProfessionalController(IProfessionalBL iProfessionalBL)
        {
            this._IProfessionalBL = iProfessionalBL;
        }
        [HttpGet("[action]/{idHoliday}")]
        public ActionResult< List<ProfessionalDTO>> GetProfessionalsById(int idHoliday)
        {
            try
            {
                return Ok(_IProfessionalBL.GetProfessionalsById(idHoliday));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult< List<ProfessionalDTO> >GetProfessionals()
        {
            try
            {
                return Ok(_IProfessionalBL.GetProfessionals());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
