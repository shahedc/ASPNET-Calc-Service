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
        // OPTION 1: inject via constructor
        //public IExternalService ExternalService { get; set; }
        //public CalcController(IExternalService externalService)
        //{
        //    ExternalService = externalService;
        //}

        // OPTION 2: use setter injection
        [FromServices]
        public IExternalService ExternalService { get; set; }

        // GET: Calc
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public ActionResult ProcessWithService(CalcViewModel model)
        {
            bool isSuccess = ExternalService.DoGreatThings();
            if (isSuccess)
            {
                var cs = new CalcService();
                var result = cs.AddNumbers(model.Number1, model.Number2);
                model.Result = result;
                return View(model);
            }
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public ActionResult Process(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View(model);
        }


        [HttpPost]
        public ActionResult Add(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public ActionResult Subtract(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.SubtractNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public ActionResult Multiply(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.MultiplyNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public ActionResult Divide(CalcViewModel model)
        {
            var cs = new CalcService();
            var result = cs.SafeDivide(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }
    }
}
