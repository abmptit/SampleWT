namespace SeleniumWebTest
{
    using System.Linq;
    using NUnit.Framework;
    using SeleniumClient;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Interactions;
    using System.IO;

    public class FrameTestFixture
    {
        private readonly string _iframeTestPageUri = @"D:\sources\foundation-testing\TalentSoft.Foundation.Web.Tests.Nunit\BrowserResources\Resources\Html\componentsTestIntoIFrame.html";
        private readonly string _iframeWithComponents = @"TestedSite/componentsTestIntoIFrame.html";

        [Test]
        public void Selenium_ClickOnRadioButtonIntoIFrame_WithChangingPadding()
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(), _iframeWithComponents));
                string frameId = "iframeWebTest";
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(frameId));
                (webDriver as IJavaScriptExecutor).ExecuteScript($"document.getElementById('{frameId}').style.padding = 0");
                webDriver.SwitchTo().Frame(frame);
                var radiosGroupButtonValue = By.XPath("//input[@name='sex'][@type='radio']");
                var radiosGroupButtonLabel = new ByChained(radiosGroupButtonValue, By.XPath("./following-sibling::span"));
                var element = new ByChained(By.XPath("//input[@name='sex'][@type='radio']"), By.XPath("./self::input[@value='male']"));

                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    //webDriver.FindElement(element).Click();
                    var action = new Actions(webDriver);
                    action.Click(webElement).Build().Perform();
                }
                var allElements = webDriver.FindElements(By.XPath("//input[@name='sex'][@type='radio']"));
                string selectedValue = string.Empty;
                foreach (var el in allElements)
                {
                    if (el.Selected)
                    {
                        selectedValue = el.GetAttribute("value");
                        Assert.AreEqual("male", selectedValue);
                    }
                }
                Assert.AreEqual("male", selectedValue);
            }
        }

        [Test]
        public void Selenium_ClickOnRadioButtonIntoIFrame_WithoutChangingPadding()
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(), _iframeWithComponents));
                string frameId = "iframeWebTest";
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(frameId));
                webDriver.SwitchTo().Frame(frame);
                var radiosGroupButtonValue = By.XPath("//input[@name='sex'][@type='radio']");
                var radiosGroupButtonLabel = new ByChained(radiosGroupButtonValue, By.XPath("./following-sibling::span"));
                var element = new ByChained(By.XPath("//input[@name='sex'][@type='radio']"), By.XPath("./self::input[@value='male']"));

                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    //webDriver.FindElement(element).Click();
                    var action = new Actions(webDriver);
                    action.Click(webElement).Build().Perform();
                }
                var allElements = webDriver.FindElements(By.XPath("//input[@name='sex'][@type='radio']"));
                string selectedValue = string.Empty;
                foreach (var el in allElements)
                {
                    if (el.Selected)
                    {
                        selectedValue = el.GetAttribute("value");
                        Assert.AreEqual("male", selectedValue);
                    }
                }
                Assert.AreEqual("male", selectedValue);
            }

        }

        [Test]
        [TestCase("buttonTest2", "i m buttonTest2")]
        public void Selenium_ClickOnButtonIntoIFrame_WithoutChangingPadding(string idButton, string alertText)
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(),_iframeWithComponents));
                string frameId = "iframeWebTest";
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(frameId));
                webDriver.SwitchTo().Frame(frame);
              
                var element = By.Id(idButton);
                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    //webDriver.FindElement(element).Click();
                    var action = new Actions(webDriver);
                    action.Click(webElement).Build().Perform();
                }

                var actualText = webDriver.SwitchTo().Alert().Text;

               
                Assert.AreEqual(alertText, actualText);
            }

        }
    }
}
