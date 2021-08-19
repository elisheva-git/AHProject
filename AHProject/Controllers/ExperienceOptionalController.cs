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
    public class ExperienceOptionalController : ControllerBase
    {
        IExperienceOptionalBL _IExperienceOptionalBL;
        public ExperienceOptionalController(IExperienceOptionalBL IExperienceOptionalBL)
        {
            this._IExperienceOptionalBL = IExperienceOptionalBL;
        }

        [HttpGet]
        public ActionResult<List<ExperienceOptionalDTO>> GetExperienceOptionals()
        {
            try
            {
                return Ok(_IExperienceOptionalBL.GetExperienceOptionals());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
