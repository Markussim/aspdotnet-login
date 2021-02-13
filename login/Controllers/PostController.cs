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
    [Route("/post")]
    public class PostController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {

            return Content(System.IO.File.ReadAllText(@"./image/index.html"), "text/html");
        }

        [HttpPost]
        public IActionResult Post(AccountModel model)
        {
            System.Console.WriteLine(model.Name);
            return new ObjectResult(model);
        }
    }

   

}
