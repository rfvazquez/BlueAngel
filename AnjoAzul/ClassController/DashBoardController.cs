using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AnjoAzul.ClassController
{
    public class DashBoardController : Controller
    {
        public IActionResult ListaPacientes()
        {

            return View();
        }
    }
}