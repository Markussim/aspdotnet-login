using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace login.Controllers
{
    [ApiController]
    [Route("/signIn")]
    public class SignInController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            ActionResult loginForm;

            if (Sessions.CheckIfLoggedIn(HttpContext.Session.GetString("User")))
            {
                loginForm = Content("You are the doctor");
            }
            else
            {
                loginForm = Content(System.IO.File.ReadAllText(@"./image/index.html"), "text/html");
            }

            return loginForm;
        }

        [HttpPost]
        public IActionResult Post(AccountModel model)
        {
            bool loginSuccess = Login.SignIn(model);

            if (loginSuccess)
            {
                String ID = RandomString.GetRandomString(256);
                HttpContext.Session.SetString("User", ID);
                Sessions.AddUser(ID);
            }
            return Content(loginSuccess.ToString());
        }
    }

}
