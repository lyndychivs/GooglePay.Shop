namespace Wallet.Models.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;

    public class GooglePayDecryptionRequestExample : IExamplesProvider<GooglePayDecryptionRequest>
    {
        public GooglePayDecryptionRequest GetExamples()
        {
            return new GooglePayDecryptionRequest()
            {
                PrivateKey = "MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgYdlZJyI+jyPgcFXrqsoBMyqc8PQYEYwXTi1fyrlmv4ehRANCAAT1omR2cdQ0PNSQ1EY28FA8uzAmw280FZglKmGqGK6lJ8AEXSg/CQTZhQ1W7B3Bf3Q9t6FEA5e0zoHXfzqvcELs",
                EncryptedToken = "{\"signature\":\"MEYCIQDO7uxL3RDyqhe8pmdgE0i1KAT/6LMH03YZtc3ccmQM2QIhAManIJ16csL0mLkUsi+gy66eI8Qh12eGZcmUGoaQVoUZ\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEv3hnGTC89aRwiciKNk/fOQ03thauFo1s5wdL7RFb3mgojDX8JbWcwclqpaDSKYRqEXrkZ9KD2sx08jTswsFqig\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1701152594588\\\"}\",\"signatures\":[\"MEUCIQCBw5Tv0AAIj90fS8tMnQ1TgPvfF9HoOymHyLbbBezoQAIgcnIqYTxUM1J3kGpoTdNMiGMtC6l7y/5WUcnfkjkdnc8\\u003d\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"NcSlYp80yMnUOk6DsSAv7bNPcXEMlCV4Uhs5WhWQBg623aB9y3ue7v5w8nYeMvg87dd+7UXW0fQs2SgNKRWK0S4jJPo0fkD0J63E8/TpFFC/9m1/Dv8lUsiQwdQIU+XSHhr4QPSGOwslD0t/tLMDDEsr7hd0zhyowg/S8y12n6Q9DAApK8Apz4Fomq4J/1ipI6oNyDuXw5A/sjn30jYa/iL+9eyWjgnYToqgUlvTQlaGbk1+6tlADlsI8rwM/nuXoDDJOZ8vQo+aYfL7a3x36vdYt1wMlZPHBuGDzzy3sdTEn6JYqnJLCBpCYca4WQC/AOGICYx2fsqJ7os0cRQXIJ++SFiOEEyIMbfCQPQ0BMTNZ68pE94HVGrIeI7n92/UNdAXP8FUp+/hG85d5GmT1ekACW8sg4czLLEnpVWATlLuG14R7jiaH7+Xt70\\\\u003d\\\",\\\"ephemeralPublicKey\\\":\\\"BO5KpRF2Upj3a1kzo0SiXpFNl/0JxrJ+Adh6vbllsa6jn5kkyrJrlHtXXNtjfEH5BVYzL3l1Z+EtOy8xiEmCAWw\\\\u003d\\\",\\\"tag\\\":\\\"26m1wc8XZmlkhTzKuArOL7l5NJ/tuXk77R1gsjLzJMA\\\\u003d\\\"}\"}}",
            };
        }
    }
}