using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicTrailSys.Repository;

namespace TropicTrailSys.Controllers
{
    public class BaseController : Controller
    {
        public TropicTrailEntities _db;
        public BaseRepository<User> _userRepo;

        public BaseController()
        {
            _userRepo = new BaseRepository<User>();
            _db = new TropicTrailEntities();
        }
    }
}