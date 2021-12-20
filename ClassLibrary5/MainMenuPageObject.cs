using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit;
using NUnit.Framework;

namespace ClassLibrary5
{
    public class MainMenuPageObject
    {

        private IWebDriver webDriver;

        private By Login = By.Id("txtUsername");
        private By Password = By.Id("txtPassword");
        private By LoginButton = By.Id("btnLogin");

        public MainMenuPageObject(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public void OpenPage(string url)
        {
            //webDriver = new ChromeDriver(@"C:\WebDriver");
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public void SendKeys(string login, string password)
        {
            webDriver.FindElement(Login).SendKeys(login);
            webDriver.FindElement(Password).SendKeys(password);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public DashboardPageObject LgnButton()
        {
            webDriver.FindElement(LoginButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            return new DashboardPageObject(webDriver);
        }

    }
}
