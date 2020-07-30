using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCMSJIR.Controllers
{
    public class InfirmerieController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
