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
    public class ContactPersonController : ControllerBase
    {
        IContactPersonBL _IContactPersonBL;
        public ContactPersonController(IContactPersonBL iContactPersonBL)
        {
            this._IContactPersonBL = iContactPersonBL;
        }
    }
}
