namespace GooglePay.Shop.Tests.Web
{
    using GooglePay.Shop.Pages;

    using NUnit.Framework;

    [TestFixture]
    public class DecryptionTests : WebSetUp
    {
        [Test]
        public void Decryption_Page_Can_Be_Rendered_Successfully()
        {
            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            var decryptionPage = new DecryptionPage(WebDriver);

            Assert.Multiple(() =>
            {
                Assert.That(decryptionPage.PrivateKey, Is.EqualTo("MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQga53ZFNSLxRqJZEl81QesCTY8NDXugxripMFTYx9JoiChRANCAAS1+jJngOiGJppYPFtm2KRiHkN9rvicQd4DlQzfj+AG7Wt6TlZ5IKvZoHWr2aqegntIbE1iVqApnXt7coibIvL7"));
                Assert.That(decryptionPage.EncryptedToken, Is.EqualTo(string.Empty));
                Assert.That(decryptionPage.Response, Is.EqualTo(string.Empty));
            });
        }
    }
}