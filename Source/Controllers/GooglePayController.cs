namespace Wallet.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GooglePayController : Controller
    {
        [Route("")]
        [Route("GooglePay/Sale")]
        public IActionResult Sale()
        {
            return View();
        }

        [Route("GooglePay/Authorization")]
        public IActionResult Authorization()
        {
            return View();
        }

        [Route("GooglePay/Decryption")]
        public IActionResult Decryption()
        {
            return View();
        }
    }
}