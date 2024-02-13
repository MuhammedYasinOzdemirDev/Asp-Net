using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieApp.Controllers
{
    public class BaseController : Controller
{
    public BaseController()
    {
        // Burada istediğiniz verileri hazırlayıp ViewData'ya ekleyebilirsiniz
        ViewData["UserName"] = null;
        ViewData["IsAdministrator"] = false;
    }
}
}