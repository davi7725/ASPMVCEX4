using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPMVCEX4.Models;

namespace ASPMVCEX4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CalculatorVM cvm = new CalculatorVM();
            cvm.N1 = HttpContext.Session.Get<double>("lastCalculation");
            cvm.Result = HttpContext.Session.Get<double>("lastCalculation");

            return View(cvm);
        }

        [HttpPost]
        public IActionResult Index(CalculatorVM post)
        {
            switch(post.Action)
            {
                case "add":
                    post.Result = Calculator.Add(post.N1, post.N2);
                    break;
                case "subtract":
                    post.Result = Calculator.Subtract(post.N1, post.N2);
                    break;
                case "divide":
                    post.Result = Calculator.Divide(post.N1, post.N2);
                    break;
                case "multiply":
                    post.Result = Calculator.Multiply(post.N1, post.N2);
                    break;
            }
            HttpContext.Session.Set<double>("lastCalculation", post.Result);
            return View(post);
        }
    }
}
