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
    public class PasswordController : ControllerBase
    {
        IPasswordsBL _IpasswordBL;
        public PasswordController(IPasswordsBL IpasswordBL)
        {
            this._IpasswordBL = IpasswordBL;
        }
        [HttpPost]
        public ActionResult<bool> checkPassword(PasswordsDTO pass)
        {
            try
            {
                bool res = this._IpasswordBL.checkPassword(pass);
                return Ok(res);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
