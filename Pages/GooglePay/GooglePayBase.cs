namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public abstract class GooglePayBase : PageBase
    {
        private readonly By _navigationGooglePaySale = By.Id("navigationGooglePaySale");
        private readonly By _navigationGooglePayAuthorization = By.Id("navigationGooglePayAuthorization");
        private readonly By _navigationGooglePayDecryption = By.Id("navigationGooglePayDecryption");
        private readonly By _navigationGooglePayDecryptionSwagger = By.Id("navigationGooglePayDecryptionSwagger");

        protected GooglePayBase(IWebDriver webDriver, string expectedPageTitle)
            : base(webDriver, expectedPageTitle)
        {
        }

        protected SalePage ClickNavigationBarGooglePaySale()
        {
            Click(_navigationGooglePaySale);
            return new SalePage(WebDriver);
        }

        protected AuthorizationPage ClickNavigationBarGooglePayAuthorization()
        {
            Click(_navigationGooglePayAuthorization);
            return new AuthorizationPage(WebDriver);
        }

        protected DecryptionPage ClickNavigationBarGooglePayDecryption()
        {
            Click(_navigationGooglePayDecryption);
            return new DecryptionPage(WebDriver);
        }

        protected DecryptionApiSwaggerPage ClickNavigationBarGooglePayDecryptionApiSwagger()
        {
            Click(_navigationGooglePayDecryptionSwagger);
            return new DecryptionApiSwaggerPage(WebDriver);
        }
    }
}