using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBG.Louvor.Repertorio.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            return View();
        }

        public ActionResult InicializaSessão()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return View();
        }
    }
}