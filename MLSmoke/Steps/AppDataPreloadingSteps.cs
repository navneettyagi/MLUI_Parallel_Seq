using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using MLAutoFramework.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace SRSAutoFramework.Steps
{
    [Binding]
    public class AppDataPreloadingSteps : TestBase
    {
        // ************
        // Input Data
        // ************
        String act_msg = "An invalid SSN was entered. Please double check before continuing.".ToLower();
        String text = "";
        String existingMemberNumber = "9900";
        String newMemberNumber = "9901";
        String validSSN = "000-00-0001";
        String invalidSSN = "000-00-0012";

        // ************
        private IWebDriver _driver;

        public AppDataPreloadingSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"Navigate to Vehicle loan")]
        public void GivenNavigateToVehicleLoan()
        {
            _driver.WaitForPageLoad();
            _driver.Hover(_driver.FindElement(HomePage.MouseHover_NewApp));
            WebElementExtension.Click(_driver.FindElement(HomePage.MouseHover_NewApp_Vehicle));

            // Verify that Vehicle page is loaded.
            _driver.WaitForPageLoad();
            test.Log(LogStatus.Info, "Selected Vehicle submenu");
            WebElementExtension.AssertElementPresent(_driver.FindElement(VehiclePage.VehicleSectionTitle));
        }

        [When(@"Existing Member number is added")]
        public void WhenExistingMemberNumberIsAdded()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(LoanPage.MemberNumber_MemberN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.MemberNumber_MemberN), existingMemberNumber);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.Click(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"New Member number is added")]
        public void WhenNewMemberNumberIsAdded()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForElementToBeClickable(LoanPage.MemberNumber_MemberN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.MemberNumber_MemberN), newMemberNumber);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.Click(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"Enter a valid SSN")]
        public void WhenEnterAValidSSN()
        {
            _driver.WaitForObjectAvaialble(LoanPage.Sa_SSN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.Sa_SSN), validSSN);
            _driver.WaitForObjectAvaialble(LoanPage.TdMemberNumber_Title);
            WebElementExtension.Click(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            _driver.WaitForPageLoad();
        }

        [When(@"Enter an invalid SSN")]
        public void WhenEnterAnInvalidSSN()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(LoanPage.Sa_SSN);
            WebElementExtension.EnterText(_driver.FindElement(LoanPage.Sa_SSN), invalidSSN);
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
            WebElementExtension.Click(_driver.FindElement(LoanPage.TdMemberNumber_Title));
            System.Threading.Thread.Sleep(2000);
            IAlert alert = _driver.SwitchTo().Alert();
            System.Threading.Thread.Sleep(2000);
            text = alert.Text.ToLower();
            test.Log(LogStatus.Info, "Popup Text captured is :-");
            test.Log(LogStatus.Info, text);
            alert.Accept();
            Assert.IsTrue(text.Equals(act_msg), "Error Message of the Popup did not matched.");

            /*_driver.AlertTextVerify(_driver.FindElement(LoanPage.TdMemberNumber_Title), "An invalid SSN was entered. Please double check before continuing.");
            Assert.IsTrue(text.Equals(act_msg), "Error Message of the Popup did not matched.");*/

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
