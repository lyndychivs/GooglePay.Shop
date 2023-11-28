namespace Wallet.Pages.GooglePay
{
    using OpenQA.Selenium;

    public class SalePage : GooglePayBase
    {
        public static readonly string Title = "Wallet | GooglePay Sale";
        public static readonly string Url = "https://wallet.lyndychivs.com/GooglePay/Sale";

        private readonly By _apiVersionLabel = By.Id("api-version");
        private readonly By _allowedAuthenticationMethodsDropdown = By.Id("allowed-authentication-methods");
        private readonly By _tokenizationSpecificationTypeDropdown = By.Id("tokenization-specification-type");
        private readonly By _tokenizationSpecificationGatewayTextBox = By.Id("tokenization-specification-gateway");
        private readonly By _tokenizationSpecificationGatewayMerchantIdTextBox = By.Id("tokenization-specification-gateway-merchant-id");
        private readonly By _tokenizationSpecificationProtocolVersionDropdown = By.Id("tokenization-specification-protocol-version");
        private readonly By _tokenizationSpecificationPublicKeyTextBox = By.Id("tokenization-specification-public-key");
        private readonly By _currencyCodeLabel = By.Id("currency-code");
        private readonly By _totalPriceTextBox = By.Id("total-price");

        private readonly By _payWithGooglePayButton = By.XPath("//*[@id=\"googlepay-button\"]/div/button");
        private readonly By _clearLogsButton = By.Id("clear-logs");
        private readonly By _copyTokenToClipboardButton = By.Id("copy-token-to-clipboard");
        private readonly By _copyBase64TokenToClipboardButton = By.Id("copy-base64-token-to-clipboard");

        private readonly By _requestLogBlock = By.Id("request-log");
        private readonly By _responseLogBlock = By.Id("response-log");
        private readonly By _responseTokenBlock = By.Id("response-token");
        private readonly By _responseTokenBase64EncodedBlock = By.Id("response-token-base64-encoded");

        public SalePage(IWebDriver webDriver)
            : base(webDriver, Title)
        {
        }

        public string ApiVersion
        {
            get => FindElement(_apiVersionLabel).Text;
        }

        public string AllowedAuthenticationMethods
        {
            get => GetDropdownSelectedOption(_allowedAuthenticationMethodsDropdown).Text;
            set => SelectDropdownOptionByText(_allowedAuthenticationMethodsDropdown, value);
        }

        public string TokenizationSpecificationType
        {
            get => GetDropdownSelectedOption(_tokenizationSpecificationTypeDropdown).Text;
            set => SelectDropdownOptionByText(_tokenizationSpecificationTypeDropdown, value);
        }

        public string TokenizationSpecificationGateway
        {
            get => FindElement(_tokenizationSpecificationGatewayTextBox).Text;
            set => SetTextBoxValue(_tokenizationSpecificationGatewayTextBox, value);
        }

        public string TokenizationSpecificationGatewayMerchantId
        {
            get => FindElement(_tokenizationSpecificationGatewayMerchantIdTextBox).Text;
            set => SetTextBoxValue(_tokenizationSpecificationGatewayMerchantIdTextBox, value);
        }

        public string TokenizationSpecificationProtocolVersion
        {
            get => GetDropdownSelectedOption(_tokenizationSpecificationProtocolVersionDropdown).Text;
            set => SelectDropdownOptionByText(_tokenizationSpecificationProtocolVersionDropdown, value);
        }

        public string TokenizationSpecificationPublicKey
        {
            get => FindElement(_tokenizationSpecificationPublicKeyTextBox).Text;
            set => SetTextBoxValue(_tokenizationSpecificationPublicKeyTextBox, value);
        }

        public string CurrencyCode
        {
            get => FindElement(_currencyCodeLabel).Text;
        }

        public string TotalPrice
        {
            get => FindElement(_totalPriceTextBox).Text;
            set => SetTextBoxValue(_totalPriceTextBox, value);
        }

        public string RequestLog
        {
            get => FindElement(_requestLogBlock).Text;
        }

        public string ResponseLog
        {
            get => FindElement(_responseLogBlock).Text;
        }

        public string ResponseToken
        {
            get => FindElement(_responseTokenBlock).Text;
        }

        public string ResponseTokenBase64Encoded
        {
            get => FindElement(_responseTokenBase64EncodedBlock).Text;
        }

        public void ClickPayWithGooglePayButton()
        {
            Click(_payWithGooglePayButton);

            // var xPathRes = document.evaluate ('//*[@id=\"googlepay-button\"]/div/button', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
            // xPathRes.singleNodeValue.click();
        }

        public void ClickClearLogs()
        {
            Click(_clearLogsButton);
        }

        public void ClickCopyTokenToClipboard()
        {
            Click(_copyTokenToClipboardButton);
        }

        public void ClickCopyBase64TokenToClipboard()
        {
            Click(_copyBase64TokenToClipboardButton);
        }
    }
}