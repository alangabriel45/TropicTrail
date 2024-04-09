using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TropicTrail.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        [AllowAnonymous]
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(User u)
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.userName} Added!";

            return RedirectToAction("Login");
        }
        public ActionResult HotDeals()
        {
            return View();
        }
        public ActionResult Offers()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Book()
        {
            return View();
        }
        public ActionResult BookNow(int id)
        {
            var services = _db.sp_Service(id).ToList();

            return View(services);
        }
    }
}