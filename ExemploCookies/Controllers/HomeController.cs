using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploCookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLucas"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLucas"];
                ViewBag.NomeDoProfessor = cookie.Value;
            }
            else
            {
                InsereCookie();
            }

            return View();
        }
        
        public void InsereCookie()
        {
            HttpCookie cookie = new HttpCookie("CookieLucas");
            cookie.Value = "Lucas Tudda Schoch, criado em " + DateTime.Now.ToShortTimeString();
            cookie.Expires = DateTime.Now.AddDays(1);

            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            ViewBag.NomeDoProfessor = cookie.Value;
        }

        public void RemoveCookie()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLucas"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieLucas"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            RemoveCookie();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}