using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary5
{
    public class EditPageObject
    {
        private IWebDriver webDriver;

        private By Job_Title = By.XPath("//*[@id='jobTitle_jobTitle']");
        private By Job_Description = By.XPath("//*[@id='jobTitle_jobDescription']");
        private By Note = By.XPath("//*[@id='jobTitle_note']");
        private By saveButton = By.XPath("//*[@id='btnSave']");
        private By editButton = By.ClassName("editButton");

        public EditPageObject(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public void Fill_The_Following(string title, string description, string note)
        {
            webDriver.FindElement(Job_Title).SendKeys(title);
            webDriver.FindElement(Job_Description).SendKeys(description);
            webDriver.FindElement(Note).SendKeys(note);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public JobListPageObject SaveButton()
        {
            webDriver.FindElement(saveButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            return new JobListPageObject(webDriver);
        }

        public void EditButton()
        {
            webDriver.FindElement(editButton).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public void Change_Job_Description_Field(string new_description)
        {
            webDriver.FindElement(Job_Description).Clear();
            webDriver.FindElement(Job_Description).SendKeys(new_description);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }


    }
}
