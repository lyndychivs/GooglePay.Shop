namespace GooglePay.Shop.Tests.Unit
{
    using System;

    using GooglePay.PaymentDataCryptography;
    using GooglePay.Shop.Controllers;
    using GooglePay.Shop.Models;

    using Microsoft.AspNetCore.Mvc;

    using NUnit.Framework;

    [TestFixture]
    public class GooglePayDecryptControllerTests
    {
        [Test]
        public void Constructor_WithValidParameters_ReturnsGooglePayDecryptController()
        {
            var signatureKeyProvider = new GoogleKeyProvider();

            var googlePayDecryptController = new GooglePayDecryptController(signatureKeyProvider, "a");

            Assert.That(googlePayDecryptController, Is.Not.Null);
        }

        [Test]
        public void Constructor_WithNullSignatureKeyProvider_ThrowsArgumentNullException()
        {
            Assert.Multiple(() =>
            {
                var ex = Assert.Throws<ArgumentNullException>(() => new GooglePayDecryptController(null, "a"));

                Assert.That(ex?.ParamName, Is.EqualTo("signatureKeyProvider"));
                Assert.That(ex?.Message, Is.EqualTo("Value cannot be null. (Parameter 'signatureKeyProvider')"));
            });
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Constructor_WithInvalidRecipientId_ThrowsArgumentNullException(string? recipientId)
        {
            var signatureKeyProvider = new GoogleKeyProvider();

            Assert.Multiple(() =>
            {
                var ex = Assert.Throws<ArgumentNullException>(() => new GooglePayDecryptController(signatureKeyProvider, recipientId));

                Assert.That(ex?.ParamName, Is.EqualTo("recipientId"));
                Assert.That(ex?.Message, Is.EqualTo("Value cannot be null. (Parameter 'recipientId')"));
            });
        }

        [Test]
        public void Post_WithValidDecryptionRequestForDev_ReturnsOk()
        {
            var signatureKeyProvider = new GoogleKeyProvider(true);
            var devMerchant = "merchant:12345678901234567890";
            var googlePayDecryptController = new GooglePayDecryptController(signatureKeyProvider, devMerchant);
            var decryptionRequest = GetValidGooglePayDecryptionRequest();
            var expectedDecryptedResponse = GetValidGooglePayDecryptionResponse();

            var result = googlePayDecryptController.Post(decryptionRequest);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
                var okObjectResult = result as OkObjectResult;
                Assert.That(okObjectResult?.StatusCode, Is.EqualTo(200));
                Assert.That(okObjectResult?.Value, Is.TypeOf(typeof(DecryptionResponse)));
                var decryptionResponseResult = okObjectResult?.Value as DecryptionResponse;
                Assert.That(decryptionResponseResult?.DecryptedData, Is.EqualTo(expectedDecryptedResponse.DecryptedData));
            });
        }

        [TestCase("", "DecryptionRequest.PrivateKey Object reference not set to an instance of an object.")]
        [TestCase(" ", "DecryptionRequest.PrivateKey Object reference not set to an instance of an object.")]
        [TestCase("a", "DecryptionRequest.PrivateKey The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.")]
        public void Post_WithInvalidPrivateKey_ReturnsBadRequest(string invalidPrivateKey, string expectedResponseString)
        {
            var signatureKeyProvider = new GoogleKeyProvider(true);
            var devMerchant = "merchant:12345678901234567890";
            var googlePayDecryptController = new GooglePayDecryptController(signatureKeyProvider, devMerchant);
            var decryptionRequest = GetValidGooglePayDecryptionRequest();
            var expectedDecryptedResponse = GetValidGooglePayDecryptionResponse();
            decryptionRequest.PrivateKey = invalidPrivateKey;

            var result = googlePayDecryptController.Post(decryptionRequest);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
                var badRequestObjectResult = result as BadRequestObjectResult;
                Assert.That(badRequestObjectResult?.StatusCode, Is.EqualTo(400));
                Assert.That(badRequestObjectResult?.Value, Is.TypeOf(typeof(string)));
                var badRequestString = badRequestObjectResult?.Value as string;
                Assert.That(badRequestString, Is.EqualTo(expectedResponseString));
            });
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("a")]
        public void Post_WithInvalidEncryptedToken_ReturnsBadRequest(string invalidEncryptedToken)
        {
            var signatureKeyProvider = new GoogleKeyProvider(true);
            var devMerchant = "merchant:12345678901234567890";
            var googlePayDecryptController = new GooglePayDecryptController(signatureKeyProvider, devMerchant);
            var decryptionRequest = GetValidGooglePayDecryptionRequest();
            var expectedDecryptedResponse = GetValidGooglePayDecryptionResponse();
            decryptionRequest.EncryptedToken = invalidEncryptedToken;

            var result = googlePayDecryptController.Post(decryptionRequest);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
                var badRequestObjectResult = result as BadRequestObjectResult;
                Assert.That(badRequestObjectResult?.StatusCode, Is.EqualTo(400));
                Assert.That(badRequestObjectResult?.Value, Is.TypeOf(typeof(string)));
                var badRequestString = badRequestObjectResult?.Value as string;
                Assert.That(badRequestString, Is.EqualTo("DecryptionRequest.EncryptedToken Cannot parse JSON"));
            });
        }

        private static DecryptionRequest GetValidGooglePayDecryptionRequest()
        {
            return new DecryptionRequest()
            {
                PrivateKey = "MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQga53ZFNSLxRqJZEl81QesCTY8NDXugxripMFTYx9JoiChRANCAAS1+jJngOiGJppYPFtm2KRiHkN9rvicQd4DlQzfj+AG7Wt6TlZ5IKvZoHWr2aqegntIbE1iVqApnXt7coibIvL7",

                // EncryptedToken response is only valid for 7 days from creation.
                // without access to the internal constructors on the Decrypter library, the test data will always expire after 7 days.
                EncryptedToken = "{\"signature\":\"MEQCIBpgHAA2kaftXXTylQNNVKBOufoWnpIShaXzpRscBnfbAiBR7U1vg+WTvt2MYSO9j4ZDar1NgeaC4qOnHl5j3VtayA\\u003d\\u003d\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEyI3cW1bFbGfRTsQa0EM7cbvPdQEAqaqfuqR60KNQp4Rk1QBxBi0ivl2mqsnlsY7xYMVKTr1yWnCLDXoJYV3gBg\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1723745294964\\\"}\",\"signatures\":[\"MEUCIQDTYHsTSKF3wzUz/28jlmiWSqijvxelOdJ2Kh8xHKRcmQIgXzS5+Gp9T4/TGAW7+g2uakqw27dC5YAv2bRjIUmAIuw\\u003d\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"Sca5iJfuNp1ADKLmeu0eAES5SU9IKiKbJuMkBOBMVq3nBstS13ZIq9HLsvyMp1wnP/fz93Md61GtAUVV6i25QTDQBTI/pgLxJZRhA5qpYNPHgqTTZtkVAzptevFzxIAHcGVjgNWoO2wliWqf1eAEOvpgjl4iMoydl1pytN2J7OGKnfIgFsYkieh38EmSkBmrHnpFQxZtrzaUuYy8jRwOqmNqsjnUXzm2tKRzAvPquuaaDh7vyAHZV3LYMkH6vORGJGMX1H3HL5CmYs5/NvBDn/3Ak5zLrLQ9Fm9EbiY24R92QPs9bfhN+RVHDhCFnCEEwTzY0YPbzhCLw9un6i9UhLd8mGvtLgRpfw3Jfhqk/wkC4HjDJV6Prgc1xv7M8W2BrmENNKCGuXbEWtH8e0ucPUmCVUTAuDw\\\\u003d\\\",\\\"ephemeralPublicKey\\\":\\\"BFqUpnZvV47cfdN7gDSdzxR2K8cZWPCq7tsm8Quzp1KpkINUwwDp5UOaWfj2bTwqDcfM6YBZQzp/d12b8Oypg34\\\\u003d\\\",\\\"tag\\\":\\\"pu/EfCzAjJlwuzv0kRG+us2Lx/faKTWgu8grVqr699w\\\\u003d\\\"}\"}",
            };
        }

        private static DecryptionResponse GetValidGooglePayDecryptionResponse()
        {
            return new DecryptionResponse()
            {
                DecryptedData = "{\"messageExpiration\":\"1723668252408\",\"messageId\":\"AH2EjtckFSe28llUPFQN5HCxvny4EC5_dmyHrsImrLAEddon7bOWG-kOF_ENgq7qAdYRn91uSrX5E3d0n7ORKRSkG8K8uUtmW9WkppQTaUYJLY5g2VoZ-AU\",\"paymentMethod\":\"CARD\",\"paymentMethodDetails\":{\"expirationYear\":2026,\"expirationMonth\":12,\"pan\":\"4111111111111111\",\"authMethod\":\"PAN_ONLY\"}}",
            };
        }
    }
}