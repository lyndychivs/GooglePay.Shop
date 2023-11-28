namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public class DecryptionPage : GooglePayBase
    {
        public static readonly string Title = "Wallet | GooglePay Decryption";
        public static readonly string Url = "https://wallet.lyndychivs.com/GooglePay/Decryption";

        public DecryptionPage(IWebDriver webDriver)
            : base(webDriver, Title)
        {
        }
    }
}