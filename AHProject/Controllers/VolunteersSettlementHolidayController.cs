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
    public class VolunteersSettlementHolidayController : ControllerBase
    {
        IVolunteersSettlementHolidayBL _IVolunteersSettlementHolidayBL;
        public VolunteersSettlementHolidayController(IVolunteersSettlementHolidayBL iVolunteersSettlementHolidayBL)
        {
            this._IVolunteersSettlementHolidayBL = iVolunteersSettlementHolidayBL;
        }
    }
}
