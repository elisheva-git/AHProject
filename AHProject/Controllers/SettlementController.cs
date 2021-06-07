﻿using AHProject.BL;
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
    }
}
