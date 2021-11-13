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
    public class HistoryController : ControllerBase
    {
        IHistoryBL _IHistoryBL;
        public HistoryController(IHistoryBL IHistoryBL)
        {
            this._IHistoryBL = IHistoryBL;
        }
        [HttpGet]
        public List<HistoryDTO> GetHistory()
        {
            try
            {
                return _IHistoryBL.GetHistory();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
