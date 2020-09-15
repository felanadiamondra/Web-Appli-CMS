using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCMSJIR.Controllers
{
    public class TrashController : Controller
    {
        public IActionResult Identifiant()
        {
            return View();
        }

        public IActionResult Agent()
        {
            return View();
        }

        public IActionResult Medecin()
        {
            return View();
        }
    }
}
