namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public abstract class GooglePayBase : PageBase
    {
        private readonly By _navigationGooglePaySale = By.Id("google-pay-sale");
        private readonly By _navigationGooglePayAuthorization = By.Id("google-pay-authorization");
        private readonly By _navigationGooglePayDecryption = By.Id("google-pay-decryption");
        private readonly By _navigationGooglePayDecryptionApiSwagger = By.Id("google-pay-decryption-swagger");

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
            Click(_navigationGooglePayDecryptionApiSwagger);
            return new DecryptionApiSwaggerPage(WebDriver);
        }
    }
}