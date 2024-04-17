namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public class DecryptionPage : GooglePayBase
    {
        public static readonly string Title = "Wallet | GooglePay Decryption";
        public static readonly string Url = $"{Endpoint}Decryption";

        private readonly By _privateKeyTextBox = By.Id("privateKey");
        private readonly By _encryptedTokenTextBox = By.Id("encryptedToken");
        private readonly By _responseTextBox = By.Id("response");

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