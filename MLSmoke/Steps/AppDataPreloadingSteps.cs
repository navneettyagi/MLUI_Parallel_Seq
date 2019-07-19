using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using MLAutoFramework.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System;
using TechTalk.SpecFlow;
using MLAutoFramework.Config;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class AppDataPreloadingSteps : TestBase
    {
        String act_msg = "An invalid SSN was entered. Please double check before continuing.";
        String text = "";
        String existingMemberNumber = "9900";
        String newMemberNumber = "9901";
        String validSSN = "000-00-0001";
        String invalidSSN = "000-00-0012";

        private IWebDriver _driver;
        private new ExtentTest test;
        public AppDataPreloadingSteps(IWebDriver driver, ExtentTest test)
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

        [Given(@"Navigate to Vehicle loan")]
        public void GivenNavigateToVehicleLoan()
        {
            _driver.WaitForPageLoad();
            _driver.HoverAndClick(_driver.FindElement(HomePage.New_App_Focus), _driver.FindElement(HomePage.Vehicle_Loan_Focus));
            
            // Verify that Vehicle page is loaded.
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(VehiclePage.VehicleSectionTitle);
            test.Log(Status.Info, "Selected Vehicle submenu");
            WebElementExtension.AssertElementPresent(_driver.FindElement(VehiclePage.VehicleSectionTitle));
        }

        [When(@"Existing Member number is added")]
        public void WhenExistingMemberNumberIsAdded()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(LoanPage.MemberNumber_MemberN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.MemberNumber_MemberN), existingMemberNumber);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.ClickElement(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"New Member number is added")]
        public void WhenNewMemberNumberIsAdded()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForElementToBeClickable(LoanPage.MemberNumber_MemberN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.MemberNumber_MemberN), newMemberNumber);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.ClickElement(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"Enter a valid SSN")]
        public void WhenEnterAValidSSN()
        {
            _driver.WaitForObjectAvaialble(LoanPage.SSN_Txt);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.SSN_Txt), validSSN);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.ClickElement(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"Enter an invalid SSN")]
        public void WhenEnterAnInvalidSSN()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(LoanPage.SSN_Txt);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.SSN_Txt), invalidSSN);
            _driver.WaitForPageLoad();
        }

        [Then(@"Last Applied Warning message should be displayed")]
        public void ThenLastAppliedWarningMessageShouldBeDisplayed()
        {
            WebElementExtension.AssertElementPresent(_driver.FindElement(LoanPage.AlertContainer1_alertContainer));
            WebElementExtension.AssertElementPresent(_driver.FindElement(LoanPage.Warning_icon));
            _driver.WaitForObjectAvaialble(LoanPage.Alert_Table_message);
            String warning_message = WebElementExtension.GetText(_driver.FindElement(LoanPage.Alert_Table_message));
            Assert.IsTrue(warning_message.Contains(existingMemberNumber));
        }

        [Then(@"Last Applied Warning message should not be displayed")]
        public void ThenLastAppliedWarningMessageShouldNotBeDisplayed()
        {
            _driver.WaitForPageLoad();
            WebElementExtension.AssertTrueIfelementPresent(_driver, LoanPage.AlertContainer1_alertContainer);
        }

        [Then(@"Popup for invalid SSN is captured")]
        public void ThenPopupForInvalidSSNIsCaptured()
        {
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            _driver.AlertTextVerify(_driver.FindElement(LoanPage.TdMemberNumber_Title), act_msg);
        }

        [Then(@"Last Applied SSN Warning message should be displayed")]
        public void ThenLastAppliedSSNWarningMessageShouldBeDisplayed()
        {
            _driver.WaitForObjectAvaialble(LoanPage.SSN_AlertContainer1_alertContainer);
            WebElementExtension.AssertElementPresent(_driver.FindElement(LoanPage.SSN_AlertContainer1_alertContainer));
            WebElementExtension.AssertElementPresent(_driver.FindElement(LoanPage.Warning_icon));
            String warning_message = WebElementExtension.GetText(_driver.FindElement(LoanPage.Alert_Table_message));
            Assert.IsTrue(warning_message.Contains(existingMemberNumber));
        }
    }
}