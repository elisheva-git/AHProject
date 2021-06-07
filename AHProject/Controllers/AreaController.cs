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
    public class AreaController : ControllerBase
    {
        IAreaBL _IAreaBL;
        public AreaController(IAreaBL IAreaBL)
        {
            this._IAreaBL = IAreaBL;
        }
        [HttpGet]
        public ActionResult<List<AreaDTO>> GetAreas()
        {
            return Ok(_IAreaBL.GetAreas());
        }
        [HttpPost]
        public ActionResult<bool> AddArea(AreaDTO area)
        {
            return Ok(_IAreaBL.AddArea(area));
        }
    }
}
