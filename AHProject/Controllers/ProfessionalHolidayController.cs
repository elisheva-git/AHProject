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
    public class ProfessionalHolidayController : ControllerBase
    {
        IProfessionalHolidaysBL _IProfessionalHolidayBL;
        public ProfessionalHolidayController(IProfessionalHolidaysBL iProfessionalHolidayBL)
        {
            this._IProfessionalHolidayBL = iProfessionalHolidayBL;
        }


    }
}
