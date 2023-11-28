namespace Wallet.Pages
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using SeleniumExtras.WaitHelpers;

    public abstract class PageBase
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _webDriverWait;

        protected PageBase(IWebDriver webDriver, string expectedPageTitle)
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));

            if (string.IsNullOrWhiteSpace(expectedPageTitle))
            {
                throw new ArgumentException($"{nameof(expectedPageTitle)} cannot be null, empty or whitespace.", nameof(expectedPageTitle));
            }

            _webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));

            try
            {
                _webDriverWait.Until(ExpectedConditions.TitleContains(expectedPageTitle));
                Console.WriteLine($"Navigated to \"{WebDriver.Title}\" at {new Uri(WebDriver.Url)}");
            }
            catch (WebDriverTimeoutException ex)
            {
                string currentTitle = string.IsNullOrWhiteSpace(WebDriver.Title) ? "<empty>" : WebDriver.Title;
                string exceptionMessage = $"Expected Page Title to contain \"{expectedPageTitle}\" but was \"{currentTitle}\".";
                throw new InvalidOperationException(exceptionMessage, ex);
            }
        }

        protected IWebDriver WebDriver => _webDriver;

        protected void Click(By by)
        {
            WaitUntilElementExists(by);

            Console.WriteLine($"{nameof(Click)}: {by}");
            var element = _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
            element.Click();
        }

        protected void SetTextBoxValue(By by, string value)
        {
            Console.WriteLine($"{nameof(SetTextBoxValue)}: {by}, {value}");
            var element = FindElement(by);

            element.Clear();
            element.SendKeys(value);
        }

        protected IWebElement GetDropdownSelectedOption(By by)
        {
            Console.WriteLine($"{nameof(GetDropdownSelectedOption)}: {by}");
            return FindDropdownElement(by).SelectedOption;
        }

        protected void SelectDropdownOptionByText(By by, string optionText)
        {
            Console.WriteLine($"{nameof(SelectDropdownOptionByText)}: {by}, {optionText}");
            var selectElement = FindDropdownElement(by);
            selectElement.SelectByText(optionText);
        }

        protected IWebElement FindElement(By by)
        {
            Console.WriteLine($"{nameof(FindElement)}: {by}");
            return WaitUntilElementExists(by);
        }

        private IWebElement WaitUntilElementExists(By by)
        {
            Console.WriteLine($"{nameof(WaitUntilElementExists)}: {by}");
            return _webDriverWait.Until(ExpectedConditions.ElementExists(by));
        }

        private SelectElement FindDropdownElement(By by)
        {
            Console.WriteLine($"{nameof(FindDropdownElement)}: {by}");
            return new SelectElement(FindElement(by));
        }
    }
}