using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicTrail.Repository;

namespace TropicTrail.Controllers
{
    public class BaseController : Controller
    {
        public TropicTrailEntities _db;
        public BaseRepository<User> _userRepo;
        // GET: Base
        public BaseController()
        {
            _db = new TropicTrailEntities();
            _userRepo = new BaseRepository<User>();
        }
    }
}