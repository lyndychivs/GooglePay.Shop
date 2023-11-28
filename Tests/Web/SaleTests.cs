namespace Wallet.Tests.Web
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public class SaleTests : GooglePay
    {
        private readonly IWebDriver _webDriver;

        public SaleTests()
        {
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void SalePageShouldHaveTitle()
        {
            _webDriver.Navigate().GoToUrl(WalletUrl);
            Assert.That("Sale", Is.EqualTo(_webDriver.Title));
        }
    }
}