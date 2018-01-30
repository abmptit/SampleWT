namespace SeleniumWebTest
{
    using System.IO;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Interactions;
    using SeleniumClient;

    public class FrameTestFixture
    {
        private readonly string _iframeWithComponents = @"TestedSite/componentsTestIntoIFrame.html";
        private readonly string _iframeId = "iframeWebTest";

        [Test]
        public void Selenium_ClickOnRadioButtonIntoIFrame_WithChangingPadding()
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(), _iframeWithComponents));
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(_iframeId));
                (webDriver as IJavaScriptExecutor).ExecuteScript($"document.getElementById('{_iframeId}').style.padding = 0");
                webDriver.SwitchTo().Frame(frame);
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
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(_iframeId));
                webDriver.SwitchTo().Frame(frame);
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
                    }
                }
                Assert.AreEqual("male", selectedValue);
            }
        }

        [Test]
        [TestCase("buttonTest2", "i m buttonTest2")]
        public void Selenium_ClickOnButtonIntoIFrame_WithActionClick_WithoutChangingPadding(string idButton, string alertText)
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(),_iframeWithComponents));
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(_iframeId));
                webDriver.SwitchTo().Frame(frame);
              
                var element = By.Id(idButton);
                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    var action = new Actions(webDriver);
                    action.Click(webElement).Build().Perform();
                }

                var alert = webDriver.SwitchTo().Alert();
                Assert.IsNotNull(alert);
                var actualText = webDriver.SwitchTo().Alert().Text;

               
                Assert.AreEqual(alertText, actualText);
            }
        }

        [Test]
        [TestCase("buttonTest2", "i m buttonTest2")]
        [TestCase("uploadPictureLinkId", "i m ref")]
        public void Selenium_ClickOnButtonIntoIFrame_WithSimpleClick_WithoutChangingPadding(string idButton, string alertText)
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(), _iframeWithComponents));
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(_iframeId));
                webDriver.SwitchTo().Frame(frame);

                var element = By.Id(idButton);
                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    webDriver.FindElement(element).Click();
                }

                var alert = webDriver.SwitchTo().Alert();
                Assert.IsNotNull(alert);
                var actualText = webDriver.SwitchTo().Alert().Text;


                Assert.AreEqual(alertText, actualText);
            }
        }

        [Test]
        [TestCase("buttonTest2", "i m buttonTest2")]
        [TestCase("uploadPictureLinkId", "i m a ref")]
        public void Selenium_ClickOnButtonIntoIFrame_WithSimpleClick_WithChangingPadding(string idButton, string alertText)
        {
            using (var webDriver = WebDriverHelper.CreateSession())
            {
                webDriver.ResizeWindow(SeleniumConfig.BrowserSize);
                webDriver.Navigate().GoToUrl(Path.Combine(ConfigHelper.GetCodeLocation(), _iframeWithComponents));
                var frame = webDriver.FindElement(OpenQA.Selenium.By.Id(_iframeId));
                (webDriver as IJavaScriptExecutor).ExecuteScript($"document.getElementById('{_iframeId}').style.padding = 0");

                webDriver.SwitchTo().Frame(frame);

                var element = By.Id(idButton);
                var webElement = webDriver.FindElement(element);
                if (webElement.Displayed && webElement.Enabled)
                {
                    webDriver.FindElement(element).Click();
                }

                var alert = webDriver.SwitchTo().Alert();
                Assert.IsNotNull(alert);
                var actualText = webDriver.SwitchTo().Alert().Text;


                Assert.AreEqual(alertText, actualText);
            }
        }
    }
}
