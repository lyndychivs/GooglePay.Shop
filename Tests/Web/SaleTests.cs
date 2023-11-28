namespace Wallet.Tests.Web
{
    using NUnit.Framework;

    using Wallet.Pages.GooglePay;

    [TestFixture]
    public class SaleTests : WebSetUp
    {
        [Test]
        public void Testing_GooglePayClickWorks_ReturnsGooglePayWindow()
        {
            WebDriver.Navigate().GoToUrl(SalePage.Url);
            var salePage = new SalePage(WebDriver);
            salePage.ClickPayWithGooglePayButton();
        }
    }
}