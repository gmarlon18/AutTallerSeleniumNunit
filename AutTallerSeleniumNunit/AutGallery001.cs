using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutTallerSeleniumNunit
{
    [TestFixture]
    public class AUT001
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void TheAUT001Test()
        {
            driver.Navigate().GoToUrl("http://tallerselenium.azurewebsites.net/Home/Index");
            driver.FindElement(By.XPath("//a[contains(text(),'Galería')]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("mountain")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(text(),'next')]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(text(),'next')]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(text(),'previous')]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(text(),'Close')]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
