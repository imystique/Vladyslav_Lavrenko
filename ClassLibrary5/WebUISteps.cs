using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary5
{
    [Binding, Scope(Feature ="WebUI")]
    public class WebUISteps
    {

        private string Current_URL;
        private static IWebDriver webDriver = new ChromeDriver(@"C:\WebDriver");
        MainMenuPageObject MainPage;
        DashboardPageObject Dashboard;
        JobListPageObject JobList;
        EditPageObject EditPage;

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        [Given(@"I navigate to the ""(.*)"" page")]
        public void GivenINavigateToThePage(string p0)
        {
            MainPage = new MainMenuPageObject(webDriver);
            MainPage.OpenPage(p0);
        }

        [When(@"I enter username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string p0, string p1)
        {
            MainPage.SendKeys(p0, p1);
        }

        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            Dashboard = MainPage.LgnButton();
        }

        [When(@"I go to ""(.*)"" page")]
        public void WhenIGoToJobPage(string p0)
        {
            JobList = Dashboard.GoToJobPage();
        }

        [When(@"I press Add button")]
        public void WhenIPressAddButton()
        {
            EditPage = JobList.AddButton();
        }

        [When(@"I fill in the following:")]
        public void WhenIFillInTheFollowing(Table table)
        {
            var job = table.CreateInstance<(string Job_Title, string Job_Description, string Note)>();
            EditPage.Fill_The_Following(job.Job_Title, job.Job_Description, job.Note);
        }

        [When(@"I press Save button")]
        public void WhenIPressSaveButton()
        {
            JobList = EditPage.SaveButton();
        }

        [When(@"I click on My Job Title in Job Title table")]
        public void WhenIClickOnMyJobTitleInJobTitleTable()
        {
            EditPage = JobList.MyJobTitle_Field();
        }

        [When(@"I press Edit button")]
        public void WhenIPressEditButton()
        {
            EditPage.EditButton();
        }

        [When(@"I change Job Description field from Some Description to ""(.*)""")]
        public void WhenIChangeJobDescriptionFieldFromSomeDescriptionTo(string p0)
        {
            Current_URL = webDriver.Url;
            EditPage.Change_Job_Description_Field(p0);
        }

        [When(@"I select My Job Title field in Job Description table")]
        public void WhenISelectMyJobTitleFieldInJobDescriptionTable()
        {
            JobList.MyJobCheckBox_Field(Current_URL);
        }

        [When(@"I press Delete button")]
        public void WhenIPressDeleteButton()
        {
            JobList.DeleteButton();
        }

        [When(@"I press OK button in popup window")]
        public void WhenIPressOKButtonInPopupWindow()
        {
            JobList.Popup_OK_Window();
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            string WelcomeName = webDriver.Url;
            string welcome = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";
            Assert.AreNotEqual(WelcomeName, welcome);
        }

        [Then(@"Job Title table should contain My Job Title")]
        public void ThenJobTitleTableShouldContainMyJobTitle()
        {
            bool Element = webDriver.FindElement(By.XPath("//*[contains(text(),'My Job Title')]")).Displayed;
            Assert.AreEqual(true, Element);
            //Thread.Sleep(500);
        }

        [Then(@"Job Description table should contain Some Another Description field")]
        public void ThenJobDescriptionTableShouldContainSomeAnotherDescriptionField()
        {
            bool Element = webDriver.FindElement(By.XPath("//*[contains(text(),'Some Another Description')]")).Displayed;
            Assert.AreEqual(true, Element);
        }

        [Then(@"I should not see My Job Title field in Job Description table")]
        public void ThenIShouldNotSeeMyJobTitleFieldInTable()
        {
            var Elements = webDriver.FindElements(By.XPath("//*[contains(text(),'My Job Title')]"));
            Assert.IsTrue(Elements.Count == 0);
        }

    }
}