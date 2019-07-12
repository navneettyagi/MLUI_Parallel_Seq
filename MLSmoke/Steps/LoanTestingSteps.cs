using MLAutoFramework.Base;
using MLAutoFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using MLAutoFramework.Extensions;
using System.Threading;
using MLAutoFramework.Helpers;
using NUnit.Framework;
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework
{
    [Binding]
    public class LoanTestingSteps: TestBase
    {
        string approvalDecisions = "Approval Decisions";
        string denialDecisions = "Denial Decisions";
        //string RequestedCreditLimitTextField = "RequestedCreditLimit";
        string testApprovedComment = "TEST APPROVED COMMENT";
        string testDeniedComment = "TEST DECLINED COMMENT";
        string approved = "APPROVED";
        string declined = "DECLINED";
        string SSN = "000-00-0001";
        string newCard = "New Card";
        string check = "check";
        string frameName = "dialog-frame";

        private IWebDriver _driver;
        private new ExtentTest test;
        public LoanTestingSteps(IWebDriver driver, ExtentTest test)
        {
            if (Settings.Parallelizable == "Yes")
            {
                _driver = driver;
                this.test = test;
            }
            else if (Settings.Parallelizable == "No")
            {
                _driver = TestBase.driver;
                this.test = test;
            }

        }

        [Given(@"User changed the application status to Approved")]
        public void GivenUserChangedTheApplicationStatusToApproved()
        {
            _driver.FindElement(LoanPage.Loan_Status_DropDown).SelectDropDown(approved);
            _driver.WaitForPageLoad();
        }

        [When(@"User filled all the information and saved the application")]
        public void WhenUserFilledAllTheInformationAndSavedTheApplication()
        {
            IWebElement element;
            //Thread.Sleep(2000);
            //_driver.WaitForObjectAvaialble(WebDriverExtension.Type.Id, RequestedCreditLimitTextField);
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Requested_Credit_Limit_TextField).Clear();
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Purpose_Type_Dropdown).SelectDropDown(newCard);
            test.Log(Status.Info, "User selected new card from dropdown *Page " + _driver.Title);
            _driver.WaitForPageLoad();
            Thread.Sleep(8000);
            _driver.FindElement(LoanPage.SSN_Txt).EnterText(SSN);
            test.Log(Status.Info, "User entered SSN *Page " + _driver.Title);
            _driver.FindElement(LoanPage.FName_Txt).Click();
            _driver.WaitForPageLoad();
            element = _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox).SetCheckBox(check);
            _driver.WaitForPageLoad();
            //Thread.Sleep(5000);
            _driver.FindElement(CreditCardPage.Pull_Credit_Button).Click();
            _driver.WaitForPageLoad();
            Thread.Sleep(5000);
        }
        
        [When(@"User changed the application status to Approved")]
        public void WhenUserChangedTheApplicationStatusToApproved()
        {
            _driver.FindElement(LoanPage.Loan_Status_DropDown).SelectDropDown(approved);
            test.Log(Status.Info, "User changed the dropdown status to Approved *Page " + _driver.Title);
            _driver.WaitForPageLoad();
            //Thread.Sleep(5000);
        }

        [When(@"User navigated to Comments page")]
        public void WhenUserNavigatedToCommentsPage()
        {
            _driver.FindElement(LoanPage.Comments_Link).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User navigated to Comments page *Page " + _driver.Title);
        }


        [When(@"User entered approval comments and saved")]
        public void WhenUserEnteredApprovalCommentsAndSaved()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            _driver.FindElement(LoanPage.Comment_TextField).EnterText(testApprovedComment);
            test.Log(Status.Info, "User entered approval comment *Page " + _driver.Title);
            _driver.FindElement(LoanPage.Approval_Denial_Save_Button).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [When(@"User navigated to Credit Card application")]
        public void WhenUserNavigatedToCreditCardApplication()
        {
            _driver.WaitForPageLoad();
            _driver.HoverAndClick(_driver.FindElement(HomePage.New_App_Focus), _driver.FindElement(HomePage.Credit_Card_Focus));
            _driver.WaitForPageLoad();
            Thread.Sleep(10000);
            test.Log(Status.Info, "User navigated to credit card app *Page " + _driver.Title);
        }

        [When(@"User entered Denial reason and saved")]
        public void WhenUserEnteredDenialReasonAndSaved()
        {
            WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
            _driver.SwitchTo().Frame(frameName);
            _driver.FindElement(LoanPage.Edit_Reasons_Btn).Click();
            _driver.WaitForPageLoad();
            //Thread.Sleep(3000);
            _driver.SwitchTo().DefaultContent();
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            //Thread.Sleep(2000);
            _driver.SwitchTo().Frame(frameName);
            _driver.FindElement(LoanPage.Denial_Reason_Txt).EnterText(testDeniedComment);
            _driver.FindElement(LoanPage.Denial_Save_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Approval_Denial_Save_Button).Click();
            _driver.SwitchTo().DefaultContent();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [When(@"User navigated to Status page")]
        public void WhenUserNavigatedToStatusPage()
        {
            _driver.FindElement(LoanPage.Status_Lnk).Click();
            _driver.WaitForPageLoad();
        }



        [When(@"User changed the application status to Declined")]
        public void WhenUserChangedTheApplicationStatusToDeclined()
        {
            _driver.FindElement(LoanPage.Loan_Status_DropDown).SelectDropDown(declined);
            _driver.WaitForPageLoad();
        }


        [Then(@"Approval comment should be displayed under decision comments")]
        public void ThenApprovalCommentShouldBeDisplayedUnderDecisionComments()
        {
            Assert.IsTrue(_driver.FindElement(CommentsPage.Decision_Comments_Txt).GetText().Contains(testApprovedComment));
            test.Log(Status.Info, "User verified the approval comment *Page " + _driver.Title);
        }

        [Then(@"Status should be changed to approved")]
        public void ThenStatusShouldBeChangedToApproved()
        {

            IWebElement loanStatus = _driver.FindElement(LoanPage.Loan_Status_DropDown);
            Assert.IsTrue(loanStatus.GetTextFromDropDown().ToString().Equals(approved));
        }


        [Then(@"Approval pop up should be displayed")]
        public void ThenApprovalPopUpShouldBeDisplayed()
        {
            _driver.WaitForPageLoad();
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            Assert.IsTrue(_driver.FindElement(LoanPage.Approval_Decisions_Tab).GetText().Equals(approvalDecisions));
            test.Log(Status.Info, "User verified approval pop up window *Page " + _driver.Title);
            _driver.FindElement(LoanPage.Approval_Loan_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [Then(@"Denial Reason pop up should be displayed")]
        public void ThenDenialReasonPopUpShouldBeDisplayed()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            Assert.IsTrue(_driver.FindElement(LoanPage.Loan_Denial_Tab).GetText().Equals(denialDecisions));
            _driver.FindElement(LoanPage.Denial_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [Then(@"Status should be changed to Declined")]
        public void ThenStatusShouldBeChangedToDeclined()
        {
            IWebElement loanStatus = _driver.FindElement(LoanPage.Loan_Status_DropDown);
            Assert.IsTrue(loanStatus.GetTextFromDropDown().ToString().Equals(declined));
        }

        [Then(@"Denial comment should be displayed in Decision Comments")]
        public void ThenDenialCommentShouldBeDisplayedInDecisionComments()
        {
            Assert.IsTrue(_driver.FindElement(CommentsPage.Denial_Comments_Txt).GetText().Contains(testDeniedComment));
        }

        [Then(@"Approval Date should be displayed in status")]
        public void ThenApprovalDateShouldBeDisplayedInStatus()
        {
            var date = DateTime.Now;
            string approvalDate = _driver.FindElement(StatusPage.Approval_Date_Txt).GetAttributeValue("value").Substring(0, 10);
            Console.WriteLine(date);
            Assert.IsTrue(date.ToShortDateString().Equals(approvalDate));
        }

        [Then(@"Declined date should be displayed correctly")]
        public void ThenDeclinedDateShouldBeDisplayedCorrectly()
        {
            var date = DateTime.Now;
            string declinedDate = _driver.FindElement(StatusPage.Declined_Date_Txt).GetAttributeValue("value").Substring(0, 10);
            Assert.IsTrue(date.ToShortDateString().Equals(declinedDate));
        }
    }
}
