namespace Wallet.Controllers
{
    using System;

    using GooglePay.PaymentDataCryptography;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Wallet.Models;

    [ApiController]
    [Route("googlepay")]
    public class GooglePayApiController : ControllerBase
    {
        private readonly GoogleKeyProvider _googleKeyProvider;

        private readonly PaymentMethodTokenRecipient _paymentMethodTokenRecipient;

        public GooglePayApiController()
        {
            _googleKeyProvider = new GoogleKeyProvider(true);
            _paymentMethodTokenRecipient = new PaymentMethodTokenRecipient("merchant:12345678901234567890", _googleKeyProvider);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GooglePayDecryptionRequest googlePayDecryptionRequest)
        {
            return TryDecrypt(googlePayDecryptionRequest);
        }

        private IActionResult TryDecrypt(GooglePayDecryptionRequest googlePayDecryptionRequest)
        {
            try
            {
                _paymentMethodTokenRecipient.AddPrivateKey(googlePayDecryptionRequest.PrivateKey);
                string decryptedData = _paymentMethodTokenRecipient.Unseal(googlePayDecryptionRequest.EncryptedToken);
                return Ok(new GooglePayDecryptionResponse() { DecryptedData = decryptedData });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}