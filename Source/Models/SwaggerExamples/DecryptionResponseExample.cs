namespace GooglePay.Shop.Models.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;

    public class DecryptionResponseExample : IExamplesProvider<DecryptionResponse>
    {
        public DecryptionResponse GetExamples()
        {
            return new DecryptionResponse()
            {
                DecryptedData = "{\"messageExpiration\":\"1723668252408\",\"messageId\":\"AH2EjtckFSe28llUPFQN5HCxvny4EC5_dmyHrsImrLAEddon7bOWG-kOF_ENgq7qAdYRn91uSrX5E3d0n7ORKRSkG8K8uUtmW9WkppQTaUYJLY5g2VoZ-AU\",\"paymentMethod\":\"CARD\",\"paymentMethodDetails\":{\"expirationYear\":2026,\"expirationMonth\":12,\"pan\":\"4111111111111111\",\"authMethod\":\"PAN_ONLY\"}}",
            };
        }
    }
}