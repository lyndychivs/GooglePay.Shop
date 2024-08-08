namespace GooglePay.Shop.Controllers
{
    using System;

    using GooglePay.PaymentDataCryptography;
    using GooglePay.Shop.Models;
    using GooglePay.Shop.Models.SwaggerExamples;

    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;

    [ApiController]
    public class GooglePayDecryptController : ControllerBase
    {
        private readonly ISignatureKeyProvider _signatureKeyProvider;

        private readonly PaymentMethodTokenRecipient _paymentMethodTokenRecipient;

        [ActivatorUtilitiesConstructor]
        public GooglePayDecryptController()
            : this(new GoogleKeyProvider(true), "merchant:12345678901234567890")
        {
        }

        public GooglePayDecryptController(ISignatureKeyProvider? signatureKeyProvider, string? recipientId)
        {
            _signatureKeyProvider = signatureKeyProvider ?? throw new ArgumentNullException(nameof(signatureKeyProvider));

            if (string.IsNullOrWhiteSpace(recipientId))
            {
                throw new ArgumentNullException(nameof(recipientId));
            }

            _paymentMethodTokenRecipient = new PaymentMethodTokenRecipient(recipientId, _signatureKeyProvider);
        }

        /// <summary>
        /// Decrypts the GooglePay (ECC) Encrypted Token and returns a Decrypted value of the Transaction Data.
        /// </summary>
        /// <param name="googlePayDecryptionRequest">The <see cref="DecryptionRequest"/> for Decryption.</param>
        /// <returns>A <see cref="DecryptionResponse"/>.</returns>
        [HttpPost]
        [Route("Decrypt")]
        [SwaggerRequestExample(typeof(DecryptionRequest), typeof(DecryptionRequestExample))]
        [SwaggerResponseExample(200, typeof(DecryptionResponseExample))]
        [SwaggerResponse(200, "A valid GooglePayDecrpytionRequest will return a DecryptionResponse with the Google Token Decrypted.", typeof(DecryptionResponse))]
        [SwaggerResponse(400, "An invalid or missing input parameter will result in a Bad Request Response.", typeof(BadRequest))]
        public IActionResult Post([FromBody] DecryptionRequest googlePayDecryptionRequest)
        {
            return TryDecrypt(googlePayDecryptionRequest);
        }

        private IActionResult TryDecrypt(DecryptionRequest googlePayDecryptionRequest)
        {
            try
            {
                _paymentMethodTokenRecipient.AddPrivateKey(googlePayDecryptionRequest.PrivateKey);
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(DecryptionRequest)}.{nameof(googlePayDecryptionRequest.PrivateKey)} {ex.Message}");
            }

            try
            {
                string decryptedData = _paymentMethodTokenRecipient.Unseal(googlePayDecryptionRequest.EncryptedToken);
                return Ok(new DecryptionResponse() { DecryptedData = decryptedData });
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(DecryptionRequest)}.{nameof(googlePayDecryptionRequest.EncryptedToken)} {ex.Message}");
            }
        }
    }
}