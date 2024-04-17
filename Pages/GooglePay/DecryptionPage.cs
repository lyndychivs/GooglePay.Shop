namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public class DecryptionPage : GooglePayBase
    {
        public static readonly string Title = "Wallet | GooglePay Decryption";
        public static readonly string Url = "https://wallet.lyndychivs.com/GooglePay/Decryption";

        private By _privateKeyTextBox = By.Id("privateKey");
        private By _encryptedTokenTextBox = By.Id("encryptedToken");
        private By _responseTextBox = By.Id("response");

        public DecryptionPage(IWebDriver webDriver)
            : base(webDriver, Title)
        {
        }

        public string PrivateKey
        {
            get => GetTextBoxValue(_privateKeyTextBox);
        }

        public string EncryptedToken
        {
            get => GetTextBoxValue(_encryptedTokenTextBox);
        }

        public string Response
        {
            get => FindElement(_responseTextBox).Text;
        }
    }
}