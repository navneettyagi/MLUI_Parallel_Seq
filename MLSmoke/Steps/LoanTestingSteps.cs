using MLAutoFramework.Base;
using MLAutoFramework.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using NUnit.Framework;
using AventStack.ExtentReports;
using System.Threading;
using MLAutoFramework.Config;

namespace MLAutoFramework
{
    [Binding]
    public class LoanTestingSteps: TestBase
    {
        string approvalDecisions = "Approval Decisions";
        string denialDecisions = "Denial Decisions";
        string testApprovedComment = "TEST APPROVED COMMENT";
        string testDeniedComment = "TEST DECLINED COMMENT";
        string approved = "APPROVED";
        string declined = "DECLINED";
        string SSN = "000-00-0003";
        string newCard = "New Card";
        string check = "check";
        string frameName = "dialog-frame";
        string main_window = "";

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
            _driver.WaitForObjectAvaialble(LoanPage.Requested_Credit_Limit_Txt);
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Requested_Credit_Limit_Txt).Clear();
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Purpose_Type_Dropdown).SelectDropDown(newCard);
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.SSN_Txt).EnterText(SSN);
            test.Log(Status.Info, "User entered SSN in SSN text box" + _driver.Title);
            _driver.FindElement(LoanPage.FName_Txt).Click();
            _driver.WaitForElementPresentAndEnabled(LoanPage.Custom_Question_WordOfMouth_SelectBox, 60);
            element = _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox).SetCheckBox(check);
            _driver.WaitForElementPresentAndEnabled(CreditCardPage.Pull_Credit_Button, 60);
            test.Log(Status.Info, "User filled all the information" + _driver.Title);
            _driver.FindElement(CreditCardPage.Pull_Credit_Button).Click();
            test.Log(Status.Info, "User clicked on credit pull & save button" + _driver.Title);
            _driver.WaitForElementPresentAndEnabled(CreditCardPage.Referred_Products_Tab, 60);
            test.Log(Status.Info, "User navigated to qualification products page" + _driver.Title);
            Thread.Sleep(2000);
        }
        
        [When(@"User changed the application status to Approved")]
        public void WhenUserChangedTheApplicationStatusToApproved()
        {
            IWebElement element = _driver.FindElement(LoanPage.Loan_Status_DropDown);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.FindElement(LoanPage.Loan_Status_DropDown).SelectDropDown(approved);
            test.Log(Status.Info, "User changed the loan status to approved" + _driver.Title);
        }

        [When(@"User navigated to Comments page")]
        public void WhenUserNavigatedToCommentsPage()
        {
            _driver.FindElement(LoanPage.Comments_Link).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User navigated to Comments page" + _driver.Title);
        }


        [When(@"User entered approval comments and saved")]
        public void WhenUserEnteredApprovalCommentsAndSaved()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            _driver.WaitForElementPresentAndEnabled(LoanPage.Approval_Denial_Save_Button, 60);
            _driver.FindElement(LoanPage.Comment_TextField).EnterText(testApprovedComment);
            test.Log(Status.Info, "User entered approval comment" + _driver.Title);
            _driver.FindElement(LoanPage.Approval_Denial_Save_Button).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [When(@"User navigated to Credit Card application")]
        public void WhenUserNavigatedToCreditCardApplication()
        {
            _driver.WaitForPageLoad();
            _driver.HoverAndClick(_driver.FindElement(HomePage.New_App_Focus), _driver.FindElement(HomePage.Credit_Card_Focus));
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User created a credit card application" + _driver.Title);
        }

        [When(@"User entered Denial reason and saved")]
        public void WhenUserEnteredDenialReasonAndSaved()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            _driver.FindElement(LoanPage.Edit_Reasons_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.SwitchTo().DefaultContent();
            main_window = WindowHelper.switchToChildWindow(_driver);
            //Thread.Sleep(2000);
            _driver.SwitchTo().Frame(frameName);
            _driver.FindElement(LoanPage.Denial_Reason_Txt).EnterText(testDeniedComment);
            test.Log(Status.Info, "User entered denial reason" + _driver.Title);
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
            test.Log(Status.Info, "User clicked on status link" + _driver.Title);
            _driver.WaitForElementPresentAndEnabled(StatusPage.Approval_Date_Txt, 60);
        }



        [When(@"User changed the application status to Declined")]
        public void WhenUserChangedTheApplicationStatusToDeclined()
        {
            _driver.FindElement(LoanPage.Loan_Status_DropDown).SelectDropDown(declined);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected loan status to Declined" + _driver.Title);
        }


        [Then(@"Approval comment should be displayed under decision comments")]
        public void ThenApprovalCommentShouldBeDisplayedUnderDecisionComments()
        {
            Assert.IsTrue(_driver.FindElement(CommentsPage.Decision_Comments_Txt).GetText().Contains(testApprovedComment));
            test.Log(Status.Info, "User verified approval comment" + _driver.Title);
        }

        [Then(@"Status should be changed to approved")]
        public void ThenStatusShouldBeChangedToApproved()
        {

            IWebElement loanStatus = _driver.FindElement(LoanPage.Loan_Status_DropDown);
            Assert.IsTrue(loanStatus.GetTextFromDropDown().ToString().Equals(approved));
            test.Log(Status.Info, "User verified as loan status changed to approved" + _driver.Title);
        }


        [Then(@"Approval pop up should be displayed")]
        public void ThenApprovalPopUpShouldBeDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            _driver.WaitForElementPresentAndEnabled(LoanPage.Approval_Decisions_Tab, 60);
            Assert.IsTrue(_driver.FindElement(LoanPage.Approval_Decisions_Tab).GetText().Equals(approvalDecisions));
            test.Log(Status.Info, "This verified the pop up" + _driver.Title);
            _driver.FindElement(LoanPage.Approval_Loan_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [Then(@"Denial Reason pop up should be displayed")]
        public void ThenDenialReasonPopUpShouldBeDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(frameName);
            Assert.IsTrue(_driver.FindElement(LoanPage.Loan_Denial_Tab).GetText().Equals(denialDecisions));
            test.Log(Status.Info, "User verified denial pop up is displayed" + _driver.Title);
            _driver.FindElement(LoanPage.Denial_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [Then(@"Status should be changed to Declined")]
        public void ThenStatusShouldBeChangedToDeclined()
        {
            IWebElement loanStatus = _driver.FindElement(LoanPage.Loan_Status_DropDown);
            Assert.IsTrue(loanStatus.GetTextFromDropDown().ToString().Equals(declined));
            test.Log(Status.Info, "User verified status changed to Declined" + _driver.Title);
        }

        [Then(@"Denial comment should be displayed in Decision Comments")]
        public void ThenDenialCommentShouldBeDisplayedInDecisionComments()
        {
            Assert.IsTrue(_driver.FindElement(CommentsPage.Denial_Comments_Txt).GetText().Contains(testDeniedComment));
            test.Log(Status.Info, "User verified Denial comment" + _driver.Title);
        }

        [Then(@"Approval Date should be displayed in status")]
        public void ThenApprovalDateShouldBeDisplayedInStatus()
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string approvalDate = _driver.FindElement(StatusPage.Approval_Date_Txt).GetAttributeValue("value").Substring(0, 10);
            Assert.IsTrue(date.Equals(approvalDate));
            test.Log(Status.Info, "User verified approval date" + _driver.Title);
        }

        [Then(@"Declined date should be displayed correctly")]
        public void ThenDeclinedDateShouldBeDisplayedCorrectly()
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string declinedDate = _driver.FindElement(StatusPage.Declined_Date_Txt).GetAttributeValue("value").Substring(0, 10);
            Assert.IsTrue(date.Equals(declinedDate));
            test.Log(Status.Info, "User verified declined date" + _driver.Title);
        }
    }
}
