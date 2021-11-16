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
        [HttpGet("[action]/{pass}")]
        public ActionResult<bool> checkPassword(string pass)
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
        [HttpGet("[action]/{passw}")]
        public ActionResult<bool> AddPassword(string passw)
        {
            try
            {
                return _IpasswordBL.AddPassword(passw);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("[action]")]
        public List<string> GetPasswords()
        {
            try
            {
                return _IpasswordBL.GetPasswords();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
