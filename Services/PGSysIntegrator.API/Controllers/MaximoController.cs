using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGSysIntegrator.API.Controllers
{
    public class MaximoController : Controller
    {
        //GET /os/mxapioperloc/{id}/syschildren.mxapioperloc?ctx=systemid=<systemid>
        public IActionResult Index()
        {
            return View();
        }
    }
}
