namespace Wallet.Tests.Web
{
    using NUnit.Framework;
    using Wallet.Pages.GooglePay;

    [TestFixture]
    public class DecryptionTests : WebSetUp
    {
        [Test]
        public void ValidatePageHasRenderedSuccessfully()
        {
            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            var decryptionPage = new DecryptionPage(WebDriver);

            Assert.Multiple(() =>
            {
                Assert.That(decryptionPage.PrivateKey, Is.EqualTo("MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgYdlZJyI+jyPgcFXrqsoBMyqc8PQYEYwXTi1fyrlmv4ehRANCAAT1omR2cdQ0PNSQ1EY28FA8uzAmw280FZglKmGqGK6lJ8AEXSg/CQTZhQ1W7B3Bf3Q9t6FEA5e0zoHXfzqvcELs"));
                Assert.That(decryptionPage.EncryptedToken, Is.EqualTo(string.Empty));
                Assert.That(decryptionPage.Response, Is.EqualTo(string.Empty));
            });
        }
    }
}