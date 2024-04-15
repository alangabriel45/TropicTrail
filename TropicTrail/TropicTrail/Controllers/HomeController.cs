using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TropicTrail.Controllers
{
    [Authorize(Roles = "User, Admin")]
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
            if (user != null && user.userPass == u.userPass)
            {
                FormsAuthentication.SetAuthCookie(u.userName, false);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User does not exist or incorrect password!");

            return View(u);
        }
        [Authorize(Roles = "User, Admin")]
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
            var services = _db.sp_Services(id).ToList();

            return View(services);
        }
        [HttpPost]
        public ActionResult BookNow(DateTime dIn, DateTime dOut, int serviceIdTextBox, String lName, String fName, String pay)
        {
            string status = "Pending";

            // Get the username of the currently logged-in user
            string userName = User.Identity.Name;

            // Retrieve the user from the repository using the username
            var user = _userRepo.Table().Where(m => m.userName == userName).FirstOrDefault();

            // Check if the user is found
            if (user != null)
            {
                // Use the ID of the logged-in user for booking
                int bookedBy = user.userId;

                // Call the stored procedure to make a reservation
                var reservation = _db.sp_Reservation(bookedBy, dIn, dOut, serviceIdTextBox, lName, fName, pay, status);

                // Save changes to the database
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Handle case when user is not found
            ModelState.AddModelError("", "User not found!");

            // Redirect to appropriate action or view
            return RedirectToAction("Index");
        }
    }
}