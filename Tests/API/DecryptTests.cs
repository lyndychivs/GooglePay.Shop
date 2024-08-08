namespace GooglePay.Shop.Tests.Api
{
    using System.Net;

    using GooglePay.Shop.Models;

    using NUnit.Framework;

    using RestSharp;

    [TestFixture]
    public class DecryptTests
    {
        private const string BaseUrl = "https://googlepay.lyndychivs.com/";
        private const string DecryptResource = "Decrypt";

        private RestClient _restClient;

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient(new RestClientOptions(BaseUrl));
        }

        [TearDown]
        public void TearDown()
        {
            _restClient.Dispose();
        }

        [Test]
        public void Valid_Request_Can_Be_Decrypted_Successfully()
        {
            var request = new RestRequest(DecryptResource, Method.Post);
            request.AddJsonBody(GetValidGooglePayDecryptionRequest());

            var response = _restClient.Execute<DecryptionResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.Data, Is.TypeOf<DecryptionResponse>());
                Assert.That(response.Data?.DecryptedData, Is.EqualTo(GetValidGooglePayDecryptionResponse().DecryptedData));
            });
        }

        [Test]
        public void Invalid_Private_Key_Returns_Response_Of_Bad_Request()
        {
            var request = new RestRequest(DecryptResource, Method.Post);
            var body = GetValidGooglePayDecryptionRequest();
            body.PrivateKey = "x";
            request.AddJsonBody(body);

            var response = _restClient.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(response.Content, Is.Not.Null);
                Assert.That(response.Content, Is.EqualTo("\"DecryptionRequest.PrivateKey The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.\""));
            });
        }

        [Test]
        public void Invalid_Encrypted_Token_Returns_Response_Of_Bad_Request()
        {
            var request = new RestRequest(DecryptResource, Method.Post);
            var body = GetValidGooglePayDecryptionRequest();
            body.EncryptedToken = "x";
            request.AddJsonBody(body);

            var response = _restClient.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(response.Content, Is.Not.Null);
                Assert.That(response.Content, Is.EqualTo("\"DecryptionRequest.EncryptedToken Cannot parse JSON\""));
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