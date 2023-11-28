namespace Wallet.Tests.Web
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public abstract class WebSetUp
    {
        private readonly IWebDriver _webDriver;

        protected WebSetUp()
        {
            _webDriver = new ChromeDriver();
        }

        protected IWebDriver WebDriver => _webDriver;

        [TearDown]
        protected void TearDownWebDriver()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}