namespace Wallet.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Wallet.Models;

    public class GooglePayController : Controller
    {
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