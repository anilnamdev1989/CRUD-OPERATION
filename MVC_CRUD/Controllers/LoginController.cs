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
            BO.Login objLogin = new BO.Login();

            return View(objLogin);
        }
        [HttpPost]
        public string Index(BO.Login objLogin)
        {
            return "hello";
        }
    }
}