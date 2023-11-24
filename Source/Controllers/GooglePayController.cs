namespace Wallet.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Wallet.Models;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GooglePayController : Controller
    {
        [Route("")]
        [Route("GooglePay/Sale")]
        [Route("GooglePay/Sale/{id?}")]
        public IActionResult Sale()
        {
            return View();
        }

        [Route("GooglePay/Authorization")]
        [Route("GooglePay/Authorization/{id?}")]
        public IActionResult Authorization()
        {
            return View();
        }

        [Route("GooglePay/Decryption")]
        [Route("GooglePay/Decryption/{id?}")]
        public IActionResult Decryption()
        {
            return View();
        }

        [Route("{id?}")]
        [Route("{id?}/{value?}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}