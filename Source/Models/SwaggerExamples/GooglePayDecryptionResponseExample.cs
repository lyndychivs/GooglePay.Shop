namespace Wallet.Models.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;

    public class GooglePayDecryptionResponseExample : IExamplesProvider<GooglePayDecryptionResponse>
    {
        public GooglePayDecryptionResponse GetExamples()
        {
            return new GooglePayDecryptionResponse()
            {
                DecryptedData = "{\"messageExpiration\":\"1701132815643\",\"messageId\":\"AH2EjtchhEjWLcFeuBb4UMU3oPuB-Ury9g_AZ7dvqvRXNAz5jKRMHwPOZGlfJAOySxmw6qmKL2lfGlrdMNSAzN4VJ-aIJ0X6LJL2CLa-hEeltBXTGzW9QNM3Zjs97g4taMQWppDIhEYP\",\"paymentMethod\":\"CARD\",\"paymentMethodDetails\":{\"expirationYear\":2025,\"expirationMonth\":12,\"pan\":\"5555555555554444\",\"authMethod\":\"PAN_ONLY\"}}}",
            };
        }
    }
}