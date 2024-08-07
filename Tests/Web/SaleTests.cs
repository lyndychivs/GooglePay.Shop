namespace Wallet.Tests.Web
{
    using NUnit.Framework;

    using Wallet.Pages.GooglePay;

    [TestFixture]
    public class SaleTests : WebSetUp
    {
        [Test]
        public void Sale_Page_Can_Be_Rendered_Successfully()
        {
            WebDriver.Navigate().GoToUrl(SalePage.Url);
            var salePage = new SalePage(WebDriver);

            Assert.Multiple(() =>
            {
                Assert.That(salePage.ApiVersion, Is.EqualTo("v2.0"));
                Assert.That(salePage.AllowedAuthenticationMethods, Is.EqualTo("PAN_ONLY & CRYPTOGRAM_3DS"));
                Assert.That(salePage.TokenizationSpecificationType, Is.EqualTo("PAYMENT_GATEWAY"));
                Assert.That(salePage.TokenizationSpecificationGateway, Is.EqualTo("example"));
                Assert.That(salePage.TokenizationSpecificationGatewayMerchantId, Is.EqualTo("exampleGatewayMerchantId"));
                Assert.That(salePage.TokenizationSpecificationProtocolVersion, Is.EqualTo("ECv2"));
                Assert.That(salePage.TokenizationSpecificationProtocolVersionIsEnabled, Is.EqualTo(false));
                Assert.That(salePage.TokenizationSpecificationPublicKey, Is.EqualTo("BLX6MmeA6IYmmlg8W2bYpGIeQ32u+JxB3gOVDN+P4Abta3pOVnkgq9mgdavZqp6Ce0hsTWJWoCmde3tyiJsi8vs="));
                Assert.That(salePage.TokenizationSpecificationPublicKeyIsEnabled, Is.EqualTo(false));
                Assert.That(salePage.CurrencyCode, Is.EqualTo("USD"));
                Assert.That(salePage.TotalPrice, Is.EqualTo("1.00"));
                Assert.That(salePage.RequestLog, Is.EqualTo(string.Empty));
                Assert.That(salePage.ResponseLog, Is.EqualTo(string.Empty));
                Assert.That(salePage.ResponseToken, Is.EqualTo(string.Empty));
                Assert.That(salePage.ResponseTokenBase64Encoded, Is.EqualTo(string.Empty));
            });
        }
    }
}