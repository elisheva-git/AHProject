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
    public class SettlementController : ControllerBase
    {
        ISettlementBL _ISettlementBL;
        public SettlementController(ISettlementBL ISettlementBL)
        {
            this._ISettlementBL = ISettlementBL;
        }
        [HttpPost]
        public ActionResult<bool> AddSettlement(SettlementDTO settlement)
        {
            try
            {
                bool res = this._ISettlementBL.AddSettlement(settlement);
                return Ok(res);//?????
            }
            catch (Exception e)
            {
                return NotFound();
                throw e;
            }
        }

        [HttpPut]
        public ActionResult<bool> UpdateSettlement(SettlementDTO settlementToUpdate)
        {
            try
            {
                return Ok(_ISettlementBL.UpdatSettlement(settlementToUpdate));
            }
            catch (Exception)
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        public ActionResult<List<SettlementDTO>> GetSettlements()
        {
            return Ok(_ISettlementBL.GetSettlements());
        }
        [HttpDelete("{idSettlement}")]
        public ActionResult<bool> DeleteSettlement(int idSettlement)
        {
            return Ok(_ISettlementBL.DeleteSettlement(idSettlement));
        }
        [HttpGet("{id}")]
        public ActionResult<SettlementDTO> GetSettlementById(int id)
        {
            return Ok(_ISettlementBL.GetSettlementById(id));
        }

        [HttpGet("[action]/{settlement}")]
        public bool IsPlaced(int settlement)
        {
            try
            {
                return _ISettlementBL.IsPlaced(settlement);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
