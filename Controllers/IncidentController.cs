using Kald_IntsiHaldur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kald_IntsiHaldur.Controllers
{
    public class IncidentController : Controller
    {
        private readonly ILogger<IncidentController> _logger;

        public IncidentController(ILogger<IncidentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
