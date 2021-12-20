using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary5
{
    public class DashboardPageObject
    {
        private IWebDriver webDriver;

        public DashboardPageObject(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public JobListPageObject GoToJobPage()
        {
            webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/viewJobTitleList");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            return new JobListPageObject(webDriver);
        }


    }
}
