using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MobileUiTests.Pages
{
    
    class Page
    {
        private readonly AppiumDriver<AndroidElement> _driver; 
        private WebDriverWait wait;
        public Page(AppiumDriver<AndroidElement> webDriver)
        {
            _driver = webDriver;
        }

        [FindsBy(How = How.Id,Using = "#sidebar input[class='s']")]
        private IWebElement searchText;

        public Page search(string text)
        {
            searchText.SendKeys(text);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#sidebar .searchsubmit"))).Click();
            return new Page(_driver);
        }
    }
}
