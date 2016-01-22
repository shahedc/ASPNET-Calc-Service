using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MinimalMVC.Models;
using MinimalMVC.Services;

namespace MinimalMVC.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Process(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View(model);
        }
    }
}
