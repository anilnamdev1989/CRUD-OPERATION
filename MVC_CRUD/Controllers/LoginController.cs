using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            BO.User objUser = new BO.User();

            return View(objUser);
        }
        [HttpPost]
        public string Index(BO.User objUser)
        {
            return "hello";
        }
    }
}