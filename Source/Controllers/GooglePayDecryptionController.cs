namespace Wallet.Controllers
{
    using System;

    using GooglePay.PaymentDataCryptography;

    using Microsoft.AspNetCore.Mvc;

    using Wallet.Models;

    [ApiController]
    public class GooglePayDecryptionController : ControllerBase
    {
        private readonly GoogleKeyProvider _googleKeyProvider;

        private readonly PaymentMethodTokenRecipient _paymentMethodTokenRecipient;

        public GooglePayDecryptionController()
        {
            _googleKeyProvider = new GoogleKeyProvider(true);
            _paymentMethodTokenRecipient = new PaymentMethodTokenRecipient("merchant:12345678901234567890", _googleKeyProvider);
        }

        [HttpPost]
        [Route("GooglePay/Decrypt")]
        public IActionResult Post([FromBody] GooglePayDecryptionRequest googlePayDecryptionRequest)
        {
            return TryDecrypt(googlePayDecryptionRequest);
        }

        private IActionResult TryDecrypt(GooglePayDecryptionRequest googlePayDecryptionRequest)
        {
            try
            {
                _paymentMethodTokenRecipient.AddPrivateKey(googlePayDecryptionRequest.PrivateKey);
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(GooglePayDecryptionRequest)}.{nameof(googlePayDecryptionRequest.PrivateKey)}\n{ex.Message}");
            }

            try
            {
                string decryptedData = _paymentMethodTokenRecipient.Unseal(googlePayDecryptionRequest.EncryptedToken);
                return Ok(new GooglePayDecryptionResponse() { DecryptedData = decryptedData });
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(GooglePayDecryptionRequest)}.{nameof(googlePayDecryptionRequest.EncryptedToken)}\n{ex.Message}");
            }
        }
    }
}