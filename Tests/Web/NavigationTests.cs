namespace Wallet.Tests.Web
{
    using NUnit.Framework;
    using Wallet.Pages.GooglePay;

    [TestFixture]
    public class NavigationTests : WebSetUp
    {
        [Test]
        public void ValidateNavigationBarIsWorking()
        {
            WebDriver.Navigate().GoToUrl(SalePage.Url);
            var salePage = new SalePage(WebDriver);
            salePage.ClickNavigationBarGooglePaySale();

            WebDriver.Navigate().GoToUrl(SalePage.Url);
            salePage = new SalePage(WebDriver);
            salePage.ClickNavigationBarGooglePayAuthorization();

            WebDriver.Navigate().GoToUrl(SalePage.Url);
            salePage = new SalePage(WebDriver);
            salePage.ClickNavigationBarGooglePayDecryption();

            WebDriver.Navigate().GoToUrl(SalePage.Url);
            salePage = new SalePage(WebDriver);
            salePage.ClickNavigationBarGooglePayDecryptionApiSwagger();

            WebDriver.Navigate().GoToUrl(AuthorizationPage.Url);
            var authorizationPage = new AuthorizationPage(WebDriver);
            authorizationPage.ClickNavigationBarGooglePaySale();

            WebDriver.Navigate().GoToUrl(AuthorizationPage.Url);
            authorizationPage = new AuthorizationPage(WebDriver);
            authorizationPage.ClickNavigationBarGooglePayAuthorization();

            WebDriver.Navigate().GoToUrl(AuthorizationPage.Url);
            authorizationPage = new AuthorizationPage(WebDriver);
            authorizationPage.ClickNavigationBarGooglePayDecryption();

            WebDriver.Navigate().GoToUrl(AuthorizationPage.Url);
            authorizationPage = new AuthorizationPage(WebDriver);
            authorizationPage.ClickNavigationBarGooglePayDecryptionApiSwagger();

            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            var decryptionPage = new DecryptionPage(WebDriver);
            decryptionPage.ClickNavigationBarGooglePaySale();

            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            decryptionPage = new DecryptionPage(WebDriver);
            decryptionPage.ClickNavigationBarGooglePayAuthorization();

            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            decryptionPage = new DecryptionPage(WebDriver);
            decryptionPage.ClickNavigationBarGooglePayDecryption();

            WebDriver.Navigate().GoToUrl(DecryptionPage.Url);
            decryptionPage = new DecryptionPage(WebDriver);
            decryptionPage.ClickNavigationBarGooglePayDecryptionApiSwagger();
        }
    }
}