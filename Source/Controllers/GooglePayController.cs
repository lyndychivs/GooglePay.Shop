namespace Wallet.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Wallet.Models;

    public class GooglePayController : Controller
    {
        private readonly ILogger<GooglePayController> _logger;

        public GooglePayController(ILogger<GooglePayController> logger)
        {
            _logger = logger;
        }

        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult Authorization()
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