using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TropicTrailSys.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u)
        {
            var user = _userRepo.Table().Where(m => m.userName == u.userName).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(u.userName, false);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "User does not exist or incorrect password!");

            return View(u);
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.userName} Created Successfully!";
            return RedirectToAction("Index");
        }       
    }
}