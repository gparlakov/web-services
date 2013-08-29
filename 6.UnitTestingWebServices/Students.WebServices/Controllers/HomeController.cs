using System;
using System.Linq;
using System.Web.Mvc;

namespace Students.WebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}