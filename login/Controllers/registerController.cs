using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace login.Controllers
{
    [ApiController]
    [Route("/register")]
    public class RegisterController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post(AccountModel model)
        {
            return Content(Login.Register(model).ToString());
        }
    }

}
