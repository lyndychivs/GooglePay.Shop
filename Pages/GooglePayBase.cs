namespace GooglePay.Shop.Pages
{
    using OpenQA.Selenium;

    public abstract class GooglePayBase : PageBase
    {
        protected const string Endpoint = "https://googlepay.lyndychivs.com/";

        private readonly By _navigationGooglePaySale = By.Id("navigationGooglePaySale");
        private readonly By _navigationGooglePayAuthorization = By.Id("navigationGooglePayAuthorization");
        private readonly By _navigationGooglePayDecryption = By.Id("navigationGooglePayDecryption");
        private readonly By _navigationGooglePayDecryptionSwagger = By.Id("navigationGooglePayDecryptionSwagger");

        protected GooglePayBase(IWebDriver webDriver, string expectedPageTitle)
            : base(webDriver, expectedPageTitle)
        {
        }

        public SalePage ClickNavigationBarGooglePaySale()
        {
            Click(_navigationGooglePaySale);
            return new SalePage(WebDriver);
        }

        public AuthorizationPage ClickNavigationBarGooglePayAuthorization()
        {
            Click(_navigationGooglePayAuthorization);
            return new AuthorizationPage(WebDriver);
        }

        public DecryptionPage ClickNavigationBarGooglePayDecryption()
        {
            Click(_navigationGooglePayDecryption);
            return new DecryptionPage(WebDriver);
        }

        public DecryptionApiSwaggerPage ClickNavigationBarGooglePayDecryptionApiSwagger()
        {
            Click(_navigationGooglePayDecryptionSwagger);
            return new DecryptionApiSwaggerPage(WebDriver);
        }
    }
}