namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public class AuthorizationPage : GooglePayBase
    {
        public static readonly string Title = "Wallet | GooglePay Authorization";
        public static readonly string Url = "https://wallet.lyndychivs.com/GooglePay/Authorization";

        public AuthorizationPage(IWebDriver webDriver)
            : base(webDriver, Title)
        {
        }
    }
}