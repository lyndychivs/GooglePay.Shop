namespace Wallet.Controllers
{
    using System;

    using GooglePay.PaymentDataCryptography;

    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;

    using Wallet.Models;
    using Wallet.Models.SwaggerExamples;

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

        /// <summary>
        /// Decrypts the GooglePay (ECC) Encrypted Token and returns a Decrypted value of the Transaction Data.
        /// </summary>
        /// <param name="googlePayDecryptionRequest">The GooglePayDecryptionRequest for Decryption.</param>
        /// <returns>A GooglePayDecryptionResponse.</returns>
        [HttpPost]
        [Route("GooglePay/Decrypt")]
        [SwaggerRequestExample(typeof(GooglePayDecryptionRequest), typeof(GooglePayDecryptionRequestExample))]
        [SwaggerResponseExample(200, typeof(GooglePayDecryptionResponseExample))]
        [SwaggerResponse(200, "A valid GooglePayDecrpytionRequest will return a GooglePayDecryptionResponse with the Google Token Decrypted.", typeof(GooglePayDecryptionResponse))]
        [SwaggerResponse(400, "An invalid or missing input parameter will result in a Bad Request Response.", typeof(BadRequest))]
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