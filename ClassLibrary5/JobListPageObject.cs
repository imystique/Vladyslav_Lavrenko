using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using NUnit.Framework;

namespace ClassLibrary5
{
    public class JobListPageObject
    {
        private IWebDriver webDriver;

        //private string Current_URL = webDriver.Url;
        private By deleteButton = By.XPath("//*[@id='btnDelete']");
        private By addButton = By.XPath("//*[@id='btnAdd']");
        private By myjobtitle_field = By.XPath("//*[contains(text(),'My Job Title')]");
        //private By myjobtitle_checkbox = ;
        private By okButton = By.XPath("//*[@id='dialogDeleteBtn']");

        public JobListPageObject(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public EditPageObject AddButton()
        {
            webDriver.FindElement(addButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            return new EditPageObject(webDriver);
        }

        public void DeleteButton()
        {
            webDriver.FindElement(deleteButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public EditPageObject MyJobTitle_Field()
        {
            webDriver.FindElement(myjobtitle_field).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            return new EditPageObject(webDriver);
        }

        public void MyJobCheckBox_Field(string url)
        {
            string a = url.Substring(url.Length - 2);
            string Path = "//*[@id='ohrmList_chkSelectRecord_" + a + "'" + "]";
            webDriver.FindElement(By.XPath(Path)).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public void Popup_OK_Window()
        {
            webDriver.FindElement(okButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

    }
}
