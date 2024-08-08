namespace GooglePay.Shop.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GooglePayController : Controller
    {
        [Route("")]
        [Route("Sale")]
        public IActionResult Sale()
        {
            return View();
        }

        [Route("Authorization")]
        public IActionResult Authorization()
        {
            return View();
        }

        [Route("Decryption")]
        public IActionResult Decryption()
        {
            return View();
        }
    }
}