using MLAutoFramework.Base;
using MLAutoFramework.PageObjects;
using MLAutoFramework.Helpers;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using MLAutoFramework.Extensions;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework
{
    [Binding]
    public class LoanQueues: TestBase
    {
        IWebElement actionElement, usersWithThisAppIconElement;
        
        static string creditCardAppNumber;
        static string vehicleLoanAppNumber;
        static string officersName;
        string assignComment = "Test Assign Comment";
        string SSN = "000-00-0003";
        string newCard = "New Card";
        string check = "check";
        string conditionSetTrue = "Condition Set: True";
        string conditionSetFalse = "Condition Set: False";
        string creditCard = "CREDIT CARD";
        string applicationType = "Application Type";
        string testConditionAgainstAnApp = "Test ConditionSet against an app";
        string alreadyBelongs = "already belongs";
        string main_window = "";

        //Vehicle loan strings
        static string amountRequested = "10000";
        static string loanTerm = "36";
        static string purposeTypeText = "Purchase";
        static string customQuestionText = "Yes";
        static string appId;


        private IWebDriver _driver;
        private new ExtentTest test;
        public LoanQueues(IWebDriver driver, ExtentTest test)
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

        [When(@"User created a new credit card application and navigated to custom app queues")]
        public void WhenUserCreatedANewCreditCardApplicationAndNavigatedToCustomAppQueues()
        {
            IWebElement element;
            _driver.WaitForPageLoad();
            _driver.Hover(_driver.FindElement(HomePage.New_App_Focus));
            _driver.FindElement(HomePage.Credit_Card_Focus).ClickElement();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User created a new credit card application" + _driver.Title);
            Thread.Sleep(2000);
            _driver.WaitForObjectAvaialble(LoanPage.LoanAppNumber);
            _driver.WaitForPageLoad();
            creditCardAppNumber = _driver.FindElement(LoanPage.LoanAppNumber).GetText();
            _driver.FindElement(LoanPage.Requested_Credit_Limit_Txt).Clear();
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Purpose_Type_Dropdown).SelectDropDown(newCard);
            _driver.WaitForPageLoad();
            //Thread.Sleep(8000);
            _driver.FindElement(LoanPage.SSN_Txt).EnterText(SSN);
            _driver.FindElement(LoanPage.FName_Txt).Click();
            _driver.WaitForPageLoad();
            element = _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.Custom_Question_WordOfMouth_SelectBox).SetCheckBox(check);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User filled the credit card app" + _driver.Title);
            _driver.FindElement(CreditCardPage.Pull_Credit_Button).Click();
            _driver.WaitForElementPresentAndEnabled(CreditCardPage.Referred_Products_Tab, 60);
            test.Log(Status.Info, "User navigated to qualification products page" + _driver.Title);
            Thread.Sleep(2000);
            element = _driver.FindElement(HomePage.Setup_Focus);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.HoverAndClick(_driver.FindElement(HomePage.Setup_Focus), _driver.FindElement(HomePage.Custom_App_Queues_Focus));
            _driver.isDialogPresent();
            _driver.WaitForPageLoad();
            
        }

        [When(@"User entered invalid credit card app number and tested")]
        public void WhenUserEnteredInvalidCreditCardAppNumberAndTested()
        {
            _driver.FindElement(CustomAppQueuesPage.Test_ConditionSet_Lnk).Click();
            _driver.WaitForPageLoad();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Application_Number_Txt).EnterText(vehicleLoanAppNumber);
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Test_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User entered an invalid credit card app number and tested" + _driver.Title);
            //Thread.Sleep(5000);
        }

        [When(@"User created a new Vehicle Loan application and navigated to custom app queues")]
        public void WhenUserCreatedANewVehicleLoanApplicationAndNavigatedToCustomAppQueues()
        {
            IWebElement element;
            _driver.WaitForPageLoad();
            _driver.Hover(_driver.FindElement(HomePage.New_App_Focus));
            _driver.FindElement(HomePage.Vehicle_Loan_Focus).ClickElement();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User created a new vehicle loan app" + _driver.Title);
            Thread.Sleep(2000);
            _driver.WaitForObjectAvaialble(LoanPage.LoanAppNumber);
            vehicleLoanAppNumber = _driver.FindElement(LoanPage.LoanAppNumber).GetText();
            _driver.FindElement(LoanPage.Amount_Requested_Txt).Clear();
            _driver.FindElement(LoanPage.Amount_Requested_Txt).EnterText(amountRequested);
            _driver.FindElement(LoanPage.Loan_Term_Txt).Clear();
            _driver.FindElement(LoanPage.Loan_Term_Txt).EnterText(loanTerm);
            _driver.FindElement(LoanPage.Purpose_Type_Ddn).SelectDropDown(purposeTypeText);
            _driver.WaitForPageLoad();
            Thread.Sleep(5000);
            _driver.FindElement(LoanPage.SSN_Txt).EnterText(SSN);
            _driver.FindElement(LoanPage.FName_Txt).Click();
            _driver.WaitForObjectAvaialble(LoanPage.Custom_Question_CheckBox);
            _driver.FindElement(LoanPage.Custom_Question_CheckBox).Click();
            _driver.WaitForObjectAvaialble(LoanPage.Custom_Question_Ddn_First);
            _driver.FindElement(LoanPage.Custom_Question_Ddn_First).SelectDropDown(customQuestionText);
            _driver.FindElement(LoanPage.Custom_Question_Ddn_Second).SelectDropDown(customQuestionText);
            _driver.FindElement(LoanPage.Pull_Credit_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on credit pull & save button" + _driver.Title);
            _driver.WaitForElementPresentAndEnabled(CreditCardPage.Referred_Products_Tab, 60);
            Thread.Sleep(2000);
            element = _driver.FindElement(HomePage.Setup_Focus);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _driver.HoverAndClick(_driver.FindElement(HomePage.Setup_Focus), _driver.FindElement(HomePage.Custom_App_Queues_Focus));
            _driver.isDialogPresent();
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
        }


        [When(@"User navigated to custom app queues")]
        public void WhenUserNavigatedToCustomAppQueues()
        {
            _driver.HoverAndClick(_driver.FindElement(HomePage.Setup_Focus), _driver.FindElement(HomePage.Custom_App_Queues_Focus));
            test.Log(Status.Info, "User navigated to custom app queues" + _driver.Title);
        }
        
        [When(@"User clicked filters link")]
        public void WhenUserClickedFiltersLink()
        {
            _driver.WaitForElementPresentAndEnabled(CustomAppQueuesPage.Filters_Lnk, 60);
            _driver.FindElement(CustomAppQueuesPage.Filters_Lnk).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on filters link" + _driver.Title);
            //Thread.Sleep(3000);
        }

        [When(@"User clicked on assign icon of an application")]
        public void WhenUserClickedOnAssignIconOfAnApplication()
        {
            IList<IWebElement> allRows = _driver.FindElements(HomePage.Working_Queue_Rows_Txt);
            for (int i = 1; i <= allRows.Count; i++)
            {
                IList<IWebElement> allColumns = _driver.FindElements(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr["+ i +"]/td"));
                for (int j = 1; j <= allColumns.Count; j++)
                {
                    string rowValue = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr["+ i +"]/td[" + j + "]")).GetText();
                    if (rowValue.Equals("App #"))
                    {
                        i = i + 1;
                        appId = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                        j = j - 1; 
                        actionElement = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[" + i + "]/td[" + j + "]/span/a[6]/img"));
                        actionElement.Click();
                        break;
                    }
                }
                break;
            }
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on Assign icon of an application" + _driver.Title);
        }

        [When(@"User added a condition")]
        public void WhenUserAddedACondition()
        {            
            _driver.FindElement(CustomAppQueuesPage.Add_Condtion_Icon).Click();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
            _driver.FindElement(CustomAppQueuesPage.Add_Condition_Txt).Clear();
            _driver.FindElement(CustomAppQueuesPage.Add_Condition_Txt).EnterText(applicationType);
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
            _driver.FindElement(CustomAppQueuesPage.Add_Condition_Header_Lbl).Click();
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
            _driver.FindElement(CustomAppQueuesPage.Add_Condition_Ddn3).SelectDropDown(creditCard);
            _driver.FindElement(CustomAppQueuesPage.Add_Condition_Save_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User added a custom app queue condition" + _driver.Title);
            //Thread.Sleep(2000);
        }

        [When(@"User entered valid credit card app number and tested")]
        public void WhenUserEnteredValidCreditCardAppNumberAndTested()
        {
            _driver.FindElement(CustomAppQueuesPage.Test_ConditionSet_Lnk).Click();
            _driver.WaitForPageLoad();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Application_Number_Txt).EnterText(creditCardAppNumber);
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Test_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User entered a valid credit card app number and tested" + _driver.Title);
            //Thread.Sleep(5000);
        }

        [When(@"User verified the same appID on pop up window")]
        public void WhenUserVerifiedTheSameAppIDOnPopUpWindow()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForElementPresentAndEnabled(HomePage.App_Assignment_Number_Txt, 60);
            if (_driver.FindElement(HomePage.App_Assignment_Number_Txt).GetText().Contains(appId))
            {
                _driver.FindElement(HomePage.Officer_Select_Box).Click();
                officersName = _driver.FindElement(HomePage.Officer_Name_Txt).GetText();
            }
        }

        [When(@"User clicked on icon of Users with this App in Their Queue")]
        public void WhenUserClickedOnIconUsersWithThisAppInTheirQueue()
        {
            _driver.WaitForElementPresentAndEnabled(HomePage.App_Assignment_Number_Txt, 60);
            if (_driver.FindElement(HomePage.Already_Assigned_Status_Txt).GetText().Contains(alreadyBelongs))
            {
                _driver.FindElement(HomePage.App_Assignment_Close_Btn).Click();
            }
            else if(_driver.FindElement(HomePage.Assigned_Status_Txt).GetText().Contains(officersName))
            {
                _driver.FindElement(HomePage.App_Assignment_Close_Btn).Click();
            }
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForElementPresentAndEnabled(HomePage.Setup_Focus, 60);
            IList<IWebElement> allColumns = _driver.FindElements(HomePage.Working_Queue_Rows_Txt);
            for (int i = 2; i <= allColumns.Count; i++)
            {
                IList<IWebElement> allRows = _driver.FindElements(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[" + i + "]/td"));
                for (int j = 1; j <= allRows.Count; j++)
                {
                    string rowValue = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                    if (rowValue.Equals(appId))
                    {
                        j = j - 1;
                        usersWithThisAppIconElement = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[" + i + "]/td[" + j + "]/span/a[2]/img"));
                        usersWithThisAppIconElement.Click();
                        test.Log(Status.Info, "User clicked on icon of Users with this App in Their Queue" + _driver.Title);
                        break;
                    }
                }
                break;
            }
        }        
    

        [When(@"User assigned to an officer with a comment")]
        public void WhenUserAssignedToAnOfficerWithAComment()
        {
            _driver.FindElement(HomePage.Assign_To_Officers_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.WaitForElementPresentAndEnabled(HomePage.Assign_To_Officers_Comments_Txt, 60);
            _driver.FindElement(HomePage.Assign_To_Officers_Comments_Txt).EnterText(assignComment);
            _driver.FindElement(HomePage.Assign_To_Officers_Submit_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on Assign to officer submit button" + _driver.Title);
            
            
        }

        [Then(@"Condtion Set: True should be displayed")]
        public void ThenCondtionSetTrueShouldBeDisplayed()
        {
            Assert.IsTrue(_driver.FindElement(CustomAppQueuesPage.TestCondition_Message_Txt).GetText().Equals(conditionSetTrue));
            test.Log(Status.Info, "User verified as Condition Set: True" + _driver.Title);
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }


        [Then(@"A link should be displayed as Test ConditionSet against an app")]
        public void ThenALinkShouldBeDisplayedAsTestConditionSetAgainstAnApp()
        {
            Assert.IsTrue(_driver.FindElement(CustomAppQueuesPage.Test_ConditionSet_Lnk).GetText().Equals(testConditionAgainstAnApp));
            test.Log(Status.Info, "User verified custom app queue condition link" + _driver.Title);
        }

        [Then(@"Condtion Set: False should be displayed")]
        public void ThenCondtionSetFalseShouldBeDisplayed()
        {
            Assert.IsTrue(_driver.FindElement(CustomAppQueuesPage.TestCondition_Message_Txt).GetText().Equals(conditionSetFalse));
            test.Log(Status.Info, "User verified as Condition Set: False" + _driver.Title);
            _driver.FindElement(CustomAppQueuesPage.TestCondition_Cancel_Btn).Click();
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }

        [Then(@"Same App ID should be displayed on pop up window")]
        public void ThenSameAppIDShouldBeDisplayedOnPopUpWindow()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            Assert.IsTrue(_driver.FindElement(HomePage.App_Assignment_Number_Txt).GetText().Contains(appId));
            test.Log(Status.Info, "User verified that same app ID is displayed"+ _driver.Title);
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }
        [Then(@"Message should be displayed as Application added to queues with the officers name")]
        public void ThenMessageShouldBeDisplayedAsApplicationAddedToQueuesWithTheOfficersName()
        {
            _driver.WaitForElementPresentAndEnabled(HomePage.App_Assignment_Number_Txt, 60);
            if (_driver.FindElement(HomePage.Already_Assigned_Status_Txt).Displayed)
            {
                Assert.IsTrue(_driver.FindElement(HomePage.Already_Assigned_Status_Txt).GetText().Contains(alreadyBelongs));
                test.Log(Status.Info, "This application is already assigned" + _driver.Title);
            }
            else
            {
                Assert.IsTrue(_driver.FindElement(HomePage.Assigned_Status_Txt).GetText().Contains(officersName));
                test.Log(Status.Info, "User verified message displayed as application added to queues" + _driver.Title);
            }
           _driver.FindElement(HomePage.App_Assignment_Close_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }
        [Then(@"Working queue Officer's name should be displayed")]
        public void ThenWorkingQueueOfficerSNameShouldBeDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
            IList<IWebElement> columnNames = _driver.FindElements(HomePage.Working_Queue_Rows_Txt);
            for (int i = 1; i <= columnNames.Count; i++)
            {
                string columName = _driver.FindElement(By.XPath(".//table[@id='dg']//tr[1]/td[" + i + "]")).GetText();
                if (columName.Equals(officersName))
                {
                    i = i + 1;
                    Assert.IsTrue(_driver.FindElement(By.XPath(".//table[@id='dg']//tr[1]/td[" + i + "]")).Equals("Y"));
                    test.Log(Status.Info, "User verified officers name assigned to application " + _driver.Title);
                    break;
                }
            }
            _driver.FindElement(HomePage.Officer_Names_Window_Close_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            //Thread.Sleep(2000);
        }
    }
}
