using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio1_CV.Controllers
{
    public class CurriculumController : Controller
    {
        // GET: Curriculum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CV()
        {
            return View();
        }
    }
}