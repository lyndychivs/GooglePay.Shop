namespace Wallet.Tests.Web
{
    using NUnit.Framework;
    using Wallet.Pages.GooglePay;

    [TestFixture]
    public class AuthorizationTests : WebSetUp
    {
        [Test]
        public void Authorization_Page_Can_Be_Rendered_Successfully()
        {
            WebDriver.Navigate().GoToUrl(AuthorizationPage.Url);
            var authorizationPage = new AuthorizationPage(WebDriver);

            Assert.Multiple(() =>
            {
                Assert.That(authorizationPage.ApiVersion, Is.EqualTo("v2.0"));
                Assert.That(authorizationPage.AllowedAuthenticationMethods, Is.EqualTo("PAN_ONLY & CRYPTOGRAM_3DS"));
                Assert.That(authorizationPage.TokenizationSpecificationType, Is.EqualTo("PAYMENT_GATEWAY"));
                Assert.That(authorizationPage.TokenizationSpecificationGateway, Is.EqualTo("example"));
                Assert.That(authorizationPage.TokenizationSpecificationGatewayMerchantId, Is.EqualTo("exampleGatewayMerchantId"));
                Assert.That(authorizationPage.TokenizationSpecificationProtocolVersion, Is.EqualTo("ECv2"));
                Assert.That(authorizationPage.TokenizationSpecificationProtocolVersionIsEnabled, Is.EqualTo(false));
                Assert.That(authorizationPage.TokenizationSpecificationPublicKey, Is.EqualTo("BLX6MmeA6IYmmlg8W2bYpGIeQ32u+JxB3gOVDN+P4Abta3pOVnkgq9mgdavZqp6Ce0hsTWJWoCmde3tyiJsi8vs="));
                Assert.That(authorizationPage.TokenizationSpecificationPublicKeyIsEnabled, Is.EqualTo(false));
                Assert.That(authorizationPage.CurrencyCode, Is.EqualTo("USD"));
                Assert.That(authorizationPage.TotalPrice, Is.EqualTo("1.00"));
                Assert.That(authorizationPage.RequestLog, Is.EqualTo(string.Empty));
                Assert.That(authorizationPage.ResponseLog, Is.EqualTo(string.Empty));
                Assert.That(authorizationPage.ResponseToken, Is.EqualTo(string.Empty));
                Assert.That(authorizationPage.ResponseTokenBase64Encoded, Is.EqualTo(string.Empty));
            });
        }
    }
}