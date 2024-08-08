namespace GooglePay.Shop.Tests.Web
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public abstract class WebSetUp
    {
        private IWebDriver _webDriver;

        protected IWebDriver WebDriver => _webDriver;

        [SetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
        }

        [TearDown]
        protected void TearDown()
        {
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}