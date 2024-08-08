namespace GooglePay.Shop.Pages
{
    using OpenQA.Selenium;

    public class AuthorizationPage : GooglePayBase
    {
        public static readonly string Title = "GooglePay.Shop | Authorization";
        public static readonly string Url = $"{Endpoint}Authorization";

        private readonly By _apiVersionLabel = By.Id("apiVersion");
        private readonly By _allowedAuthenticationMethodsDropdown = By.Id("allowedAuthMethods");
        private readonly By _tokenizationSpecificationTypeDropdown = By.Id("tokenizationSpecificationType");
        private readonly By _tokenizationSpecificationGatewayTextBox = By.Id("tokenizationSpecificationParametersGateway");
        private readonly By _tokenizationSpecificationGatewayMerchantIdTextBox = By.Id("tokenizationSpecificationParametersGatewayMerchantId");
        private readonly By _tokenizationSpecificationProtocolVersionDropdown = By.Id("tokenizationSpecificationParametersProtocolVersion");
        private readonly By _tokenizationSpecificationPublicKeyTextBox = By.Id("tokenizationSpecificationParametersPublicKey");
        private readonly By _currencyCodeLabel = By.Id("currencyCode");
        private readonly By _totalPriceTextBox = By.Id("totalPrice");

        private readonly By _requestLogBlock = By.Id("requestLog");
        private readonly By _responseLogBlock = By.Id("responseLog");
        private readonly By _responseTokenBlock = By.Id("responseToken");
        private readonly By _responseTokenBase64EncodedBlock = By.Id("responseTokenBase64Encoded");

        public AuthorizationPage(IWebDriver webDriver)
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
        }

        public string TokenizationSpecificationType
        {
            get => GetDropdownSelectedOption(_tokenizationSpecificationTypeDropdown).Text;
        }

        public string TokenizationSpecificationGateway
        {
            get => GetTextBoxValue(_tokenizationSpecificationGatewayTextBox);
        }

        public string TokenizationSpecificationGatewayMerchantId
        {
            get => GetTextBoxValue(_tokenizationSpecificationGatewayMerchantIdTextBox);
        }

        public string TokenizationSpecificationProtocolVersion
        {
            get => GetDropdownSelectedOption(_tokenizationSpecificationProtocolVersionDropdown).Text;
        }

        public bool TokenizationSpecificationProtocolVersionIsEnabled
        {
            get => FindElement(_tokenizationSpecificationProtocolVersionDropdown).Enabled;
        }

        public string TokenizationSpecificationPublicKey
        {
            get => GetTextBoxValue(_tokenizationSpecificationPublicKeyTextBox);
        }

        public bool TokenizationSpecificationPublicKeyIsEnabled
        {
            get => FindElement(_tokenizationSpecificationPublicKeyTextBox).Enabled;
        }

        public string CurrencyCode
        {
            get => FindElement(_currencyCodeLabel).Text;
        }

        public string TotalPrice
        {
            get => GetTextBoxValue(_totalPriceTextBox);
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
    }
}