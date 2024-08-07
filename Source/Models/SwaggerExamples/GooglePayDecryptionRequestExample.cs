namespace Wallet.Models.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;

    public class GooglePayDecryptionRequestExample : IExamplesProvider<GooglePayDecryptionRequest>
    {
        public GooglePayDecryptionRequest GetExamples()
        {
            return new GooglePayDecryptionRequest()
            {
                PrivateKey = "MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQga53ZFNSLxRqJZEl81QesCTY8NDXugxripMFTYx9JoiChRANCAAS1+jJngOiGJppYPFtm2KRiHkN9rvicQd4DlQzfj+AG7Wt6TlZ5IKvZoHWr2aqegntIbE1iVqApnXt7coibIvL7",
                EncryptedToken = "{\"signature\":\"MEQCIBpgHAA2kaftXXTylQNNVKBOufoWnpIShaXzpRscBnfbAiBR7U1vg+WTvt2MYSO9j4ZDar1NgeaC4qOnHl5j3VtayA\\u003d\\u003d\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEyI3cW1bFbGfRTsQa0EM7cbvPdQEAqaqfuqR60KNQp4Rk1QBxBi0ivl2mqsnlsY7xYMVKTr1yWnCLDXoJYV3gBg\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1723745294964\\\"}\",\"signatures\":[\"MEUCIQDTYHsTSKF3wzUz/28jlmiWSqijvxelOdJ2Kh8xHKRcmQIgXzS5+Gp9T4/TGAW7+g2uakqw27dC5YAv2bRjIUmAIuw\\u003d\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"Sca5iJfuNp1ADKLmeu0eAES5SU9IKiKbJuMkBOBMVq3nBstS13ZIq9HLsvyMp1wnP/fz93Md61GtAUVV6i25QTDQBTI/pgLxJZRhA5qpYNPHgqTTZtkVAzptevFzxIAHcGVjgNWoO2wliWqf1eAEOvpgjl4iMoydl1pytN2J7OGKnfIgFsYkieh38EmSkBmrHnpFQxZtrzaUuYy8jRwOqmNqsjnUXzm2tKRzAvPquuaaDh7vyAHZV3LYMkH6vORGJGMX1H3HL5CmYs5/NvBDn/3Ak5zLrLQ9Fm9EbiY24R92QPs9bfhN+RVHDhCFnCEEwTzY0YPbzhCLw9un6i9UhLd8mGvtLgRpfw3Jfhqk/wkC4HjDJV6Prgc1xv7M8W2BrmENNKCGuXbEWtH8e0ucPUmCVUTAuDw\\\\u003d\\\",\\\"ephemeralPublicKey\\\":\\\"BFqUpnZvV47cfdN7gDSdzxR2K8cZWPCq7tsm8Quzp1KpkINUwwDp5UOaWfj2bTwqDcfM6YBZQzp/d12b8Oypg34\\\\u003d\\\",\\\"tag\\\":\\\"pu/EfCzAjJlwuzv0kRG+us2Lx/faKTWgu8grVqr699w\\\\u003d\\\"}\"}",
            };
        }
    }
}