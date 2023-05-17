using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class WebChatController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public WebChatController()
        {
        }

        public WebChatController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserName = User.Identity.Name;
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult GetStooq(string stock_code)
        {
            //using (var client = new HttpClient())
            //{
            //    var uri = new Uri("http://www.google.com/");

            //    var response = await client.GetAsync(uri);

            //    string textResult = await response.Content.ReadAsStringAsync();
            //}
            //return Json(new { status = "false", Msg = "CEP não pode ser vazio." });
            return new JsonResult() { Data = stock_code };
        }
    }
}