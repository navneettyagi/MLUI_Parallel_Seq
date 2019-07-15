using NUnit.Framework;
using OpenQA.Selenium;
using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using MLAutoFramework.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class SearchBy_FeatureSteps : TestBase
    {
        private IWebDriver _driver;
        private new ExtentTest test;
        public SearchBy_FeatureSteps(IWebDriver driver, ExtentTest test)
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

        static int j;
        static string vehicleLoanAppNumber;
        static string firstName;
        static string lastName;
        static string memberNumber;
        static string universalLoanID;

        static string application = "notexist";
        string expectedHeadings = "Loan Info,Custom Questions,Comments,Borrower Info,Liabilities,Assets,Underwriting Info,Disbursements,";
        string invalidMemberNumber = "0000";
        string invalidAppNumnber = "0000";
        string validSsn = "000000001";
        string invalidSsn = "000000000";
        string invalidFirstName = "INVALID";
        string invalidLastName = "INVALID";
        string invalidUniversalLoanID = "000000";
        string noResultFound = "No result found";
        string nameColumn = "Name";
        string sSNColumn = "SSN";
        string memberNumberColoumn = "Member";
        string vehileApplicationStatus = "notexist";
        string homeequityApplicationStatus = "notexist";


        //Home Equity variables

        string SSN = "000000001";
        string purpose = "Home Equity Loan";
        string reason = "PURCHASE";
        string rateType = "FIXED";
        string amtRequested = "50000";
        string estPropertyValue = "50000";
        string valueSource = "BRIDGE LOAN";
        string interviewMethod = "FACE TO FACE";
        string occupancyStatus = "PRIMARY RESIDENCE";
        string propertyType = "2 UNIT";
        string state = "CA";

        //Vehicle loan strings
        string amountRequested = "10000";
        string loanTerm = "36";
        string purposeTypeText = "Purchase";
        string customQuestionText = "Yes";




        [Given(@"User Login successfully")]
        public void GivenUserLoginSuccessfully()
        {


        }


        [When(@"User Created a new Vehicle Loan APP")]
        public void CreateNewVehicleLoanAPP()
        {
            if (application.Equals(vehileApplicationStatus))
            {
                _driver.WaitForPageLoad();
                _driver.HoverAndClick(_driver.FindElement(HomePage.NewAPP_Focus), _driver.FindElement(HomePage.NewVehicle_Focus));
                _driver.isDialogPresent();
                _driver.ExtraWait();
                _driver.WaitForPageLoad();
                vehicleLoanAppNumber = _driver.FindElement(LoanPage.Sb_LoanNumber).GetText();
                _driver.FindElement(LoanPage.Amount_Requested_Txt).EnterText(amountRequested);
                _driver.FindElement(LoanPage.Loan_Term_Txt).EnterText(loanTerm);
                _driver.FindElement(LoanPage.Purpose_Type_Ddn).SelectDropDown(purposeTypeText);
                _driver.WaitForPageLoad();
                _driver.FindElement(LoanPage.SSN_Txt).EnterText(validSsn);
                _driver.FindElement(LoanPage.FName_Txt).Click();
                _driver.WaitForPageLoad();
                firstName = _driver.FindElement(LoanPage.FName_Txt).GetAttributeValue("value");
                lastName = _driver.FindElement(LoanPage.LName_TextField).GetAttributeValue("value");
                memberNumber = _driver.FindElement(LoanPage.MemberNumber_TextField).GetAttributeValue("value");
                _driver.FindElement(LoanPage.Custom_Question_CheckBox).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(LoanPage.Custom_Question_Ddn_First).SelectDropDown(customQuestionText);
                _driver.FindElement(LoanPage.Custom_Question_Ddn_Second).SelectDropDown(customQuestionText);
                _driver.FindElement(LoanPage.Pull_Credit_Btn).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomePage.Main_Focus).Click();
               // _driver.WaitForPageLoad();
                _driver.isDialogPresent();
                _driver.WaitForPageLoad();
                application = "exist";
                test.Log(Status.Info, "Vehicle loan application created " + _driver.Title);
            }

        }


        [When(@"User selects the Loan APP Number from the drop down")]
        public void SelectTheLoanAPPNumber()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("Loan App Number");
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Loan APP Number selected from the dropdown " + _driver.Title);
        }


        [When(@"User enters valid APP number and Click Search")]
        public void EntersValidAPPNumbe()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(vehicleLoanAppNumber);
            _driver.FindElement(HomePage.Search_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Valid App number entered " + _driver.Title);
        }


        [When(@"User enters invalid APP number and Click Search")]
        public void EnterInvalidAPPNumber()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidAppNumnber);
            test.Log(Status.Info, "Invalid APP Number Entered " + _driver.Title);
        }

        [When(@"User selects the First Name from the drop down")]
        public void SelectTheFirstName()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("First Name");
            test.Log(Status.Info, "First Name selected from the dropdown " + _driver.Title);
        }


        [When(@"User enters valid first name and Click Search")]
        public void EnterValidFirstName()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(firstName);
            _driver.FindElement(HomePage.Search_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Valid first name entered " + _driver.Title);
        }


        [When(@"User enters invalid first name and Click Search")]
        public void EnterInvalidFirstName()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidFirstName);
            test.Log(Status.Info, "Invalid first name Entered " + _driver.Title);
        }


        [When(@"User selects the Last Name from the drop down")]
        public void SelectTheLastName()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("Last Name");
            test.Log(Status.Info, "Last Name selected from the dropdown " + _driver.Title);
        }


        [When(@"User enters valid last name and Click Search")]
        public void EnterValidLasstName()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(lastName);
            _driver.FindElement(HomePage.Search_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Valid last name entered " + _driver.Title);
        }


        [When(@"User enters invalid last name and Click Search")]
        public void EnterInvalidLastNam()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidLastName);
            test.Log(Status.Info, "Invalid last name Entered " + _driver.Title);
        }


        [Then(@"Same APP number should be displayed in the loaded Application")]
        public void VerifyAPPNumber()
        {
            _driver.WaitForPageLoad();
            //Fail test intentially
            _driver.FindElement(LoanPage.LoanAppNumber).AssertTagText(vehicleLoanAppNumber);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Application loaded with the same app number " + _driver.Title);
        }


        [Then(@"Pop up should be displayed as No Results found")]
        public void VerifyPopUp()
        {
            _driver.AlertTextVerify(_driver.FindElement(HomePage.Search_Btn), noResultFound);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Pop up verified with no results found  " + _driver.Title);
        }


        [Then(@"Same first name APP should be displayed in the name column of the results found")]
        public void VerifyFirstName()
        {
            IList<IWebElement> MyWorkingQueueRowslist = _driver.FindElements(HomePage.MyWorkingQueue_Rows);
            IList<IWebElement> APPcolumns = _driver.FindElements(HomePage.App_Column);
            for (j = 1; j <= APPcolumns.Count; j++)
            {

                string columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains(nameColumn))
                    break;
            }
            for (int i = 2; i <= MyWorkingQueueRowslist.Count; i++)
            {
                string firstname = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]/a")).GetText();
                Assert.IsTrue(firstname.EndsWith(firstName));
            }
            test.Log(Status.Info, "Entered first name app displayed " + _driver.Title);
        }


        [Then(@"Same last name APP should be displayed in the name column of the results found")]
        public void VerifyLastName()
        {
            IList<IWebElement> MyWorkingQueueRowslist = _driver.FindElements(HomePage.MyWorkingQueue_Rows);
            IList<IWebElement> APPcolumns = _driver.FindElements(HomePage.App_Column);
            for (j = 1; j <= APPcolumns.Count; j++)
            {
                string columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains(nameColumn))
                    break;
            }

            for (int i = 2; i <= MyWorkingQueueRowslist.Count; i++)
            {
                String lastname = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                Assert.IsTrue(lastname.StartsWith(lastName));
            }
            test.Log(Status.Info, "Entered last name app displayed " + _driver.Title);
        }


        [When(@"User selects the SSN from the drop down")]
        public void SelectSSN()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("SSN");
            test.Log(Status.Info, "SSN selected from the drop down " + _driver.Title);
        }


        [When(@"User enters valid SSN and Click Search")]
        public void EnterValidSSN()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(validSsn);
            _driver.FindElement(HomePage.Search_Btn).Click();
            test.Log(Status.Info, "Entered valid SSN " + _driver.Title);
        }


        [Then(@"Same SSN APP should be displayed in the Last 4 SSN column of the results found")]
        public void VerifySSN()

        {
            IList<IWebElement> MyWorkingQueueRowslist = _driver.FindElements(HomePage.MyWorkingQueue_Rows);
            IList<IWebElement> APPcolumns = _driver.FindElements(HomePage.App_Column);
            for (j = 1; j <= APPcolumns.Count; j++)
            {
                string columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains(sSNColumn))
                    break;
            }
            for (int i = 2; i <= MyWorkingQueueRowslist.Count; i++)
            {
                string ssn = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                int ssnLength = validSsn.Length;
                StringBuilder last_four_ssn = new StringBuilder();
                for (int k = ssnLength - 4; k < ssnLength; k++)
                {
                    char[] valid_ssn_array = validSsn.ToCharArray();
                    string char_ssn = valid_ssn_array.GetValue(k).ToString();
                    last_four_ssn.Append(char_ssn);
                }
                Assert.IsTrue(ssn.EndsWith(last_four_ssn.ToString()));
            }
            test.Log(Status.Info, "Entered ssn app displayed " + _driver.Title);
        }


        [When(@"User enters invalid SSN and Click Search")]
        public void EnterInvalidSSN()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidSsn);
            test.Log(Status.Info, "Invalid SSN entered " + _driver.Title);
        }


        [When(@"User selects the Member Number from the drop down")]
        public void SelectMemberNumber()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("Member Number");
            test.Log(Status.Info, "Member number selected from the drop down " + _driver.Title);
        }


        [When(@"User enters valid Member Number and Click Search")]
        public void EnterValidMemberNumber()
        {
            _driver.WaitForPageLoad();
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(memberNumber);
            _driver.FindElement(HomePage.Search_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Valid member number entered " + _driver.Title);
        }


        [Then(@"Same Member Number APP should be displayed in the Member column of the results found")]
        public void VerifyMemberNumber()
        {
            IList<IWebElement> MyWorkingQueueRowslist = _driver.FindElements(HomePage.MyWorkingQueue_Rows);
            IList<IWebElement> APPcolumns = _driver.FindElements(HomePage.App_Column);
            for (j = 1; j <= APPcolumns.Count; j++)
            {
                string columName = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td[" + j + "]")).GetText();
                if (columName.Contains(memberNumberColoumn))
                    break;
            }
            for (int i = 2; i <= MyWorkingQueueRowslist.Count; i++)
            {
                string ssn = _driver.FindElement(By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[" + i + "]/td[" + j + "]")).GetText();
                Assert.IsTrue(ssn.StartsWith(memberNumber));
            }
            test.Log(Status.Info, "Entered member number app displayed " + _driver.Title);
        }


        [When(@"User enters invalid Member Number and Click Search")]
        public void EnterInvalidMemberNumber()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidMemberNumber);
            test.Log(Status.Info, "Invalid Member number entered  " + _driver.Title);
        }


        [When(@"User selects the Universal Loan ID from the drop down")]
        public void SelectUniversalLoanID()
        {
            _driver.FindElement(HomePage.SearchBy_Ddn).SelectDropDown("Universal Loan ID");
            test.Log(Status.Info, "Universal Loan ID selected from the drop down " + _driver.Title);
        }


        [When(@"User enters valid Universal ID and Click Search")]
        public void EnterValidUniversalID()
        {
            // Thread.Sleep(90000);
            //  Thread.Sleep(20000);
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(universalLoanID);
            // Thread.Sleep(90000);
            // Thread.Sleep(20000);
            _driver.FindElement(HomePage.Search_Btn).Click();
            test.Log(Status.Info, "Valid universal loan Id entered " + _driver.Title);
        }


        [When(@"User navigates to HDMA information page")]
        public void NavigateMDAInfo()
        {
            _driver.WaitForPageLoad();
            _driver.FindElement(HEEasyApplicationPage.HMDAInfo_Lnk).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Navigated to HDMA info page " + _driver.Title);
        }





        [Then(@"Same Universal loan ID should be displayed in the universal Loan identifier text box")]
        public void VerifyUniversalLoanID()
        {
            Assert.AreEqual(_driver.FindElement(HEHMDAIformationPgae.UniversalLoanIdentifier).GetAttributeValue("value"), universalLoanID);
            test.Log(Status.Info, "Entered universal loan id app displayed " + _driver.Title);
        }


        [When(@"User enters invalid Universal Loan ID and Click Search")]
        public void EntenInvalidUniversalLoanID()
        {
            _driver.FindElement(HomePage.KeySearch_Txt).EnterText(invalidUniversalLoanID);
            test.Log(Status.Info, "Invalid Universal loan Id entered " + _driver.Title);

        }


        [When(@"In Action \? column click the View APP icon")]
        public void AppIcon()
        {
            _driver.FindElement(HomePage.ViewAPP_Img).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "View app icon clicked " + _driver.Title);
        }


        [Then(@"APP should be displayed with all the Headings")]
        public void VerifyHeadings()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            IList<IWebElement> Headings_Lnk = _driver.FindElements(LoanViewPage.Headings_Lnk);
            StringBuilder anchorHeadings = new StringBuilder();
            foreach (IWebElement head in Headings_Lnk)
            {
                String heading = head.GetText().ToString();
                anchorHeadings.Append(heading + ",");
            }
            Assert.IsTrue(expectedHeadings.Equals(anchorHeadings.ToString()));
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            test.Log(Status.Info, "All the headings are displayed " + _driver.Title);
        }


        [When(@"User created a new Home Equity application")]
        public void CreateANewHomeEquityApp()
        {
            if (application.Equals(homeequityApplicationStatus))
            {
                _driver.WaitForPageLoad();
                _driver.HoverAndClick(_driver.FindElement(HomePage.NewAPP_Focus), _driver.FindElement(HomePage.HomeEquity_Focus));
                _driver.WaitForPageLoad();
                IWebElement element = _driver.FindElement(LoanPage.SSN_Txt);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                _driver.FindElement(LoanPage.SSN_Txt).EnterText(SSN);
                _driver.FindElement(LoanPage.FName_Txt).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Purpose_Ddn).SelectDropDown(purpose);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Reason_Ddn).SelectDropDown(reason);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Rate_Type_Ddn).SelectDropDown(rateType);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Amt_Requested_Txt).EnterText(amtRequested);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Est_Property_Value_Txt).EnterText(estPropertyValue);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Value_Source_Ddn).SelectDropDown(valueSource);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Interview_Method_Ddn).SelectDropDown(interviewMethod);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Occupancy_Status_Ddn).SelectDropDown(occupancyStatus);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Property_Type_Ddn).SelectDropDown(propertyType);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_State_Ddn).SelectDropDown(state);
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Ethnicity_Radio_Btn).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Sex_Radio_Btn).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Race_Radio_Btn).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Sex_Male_Select_Box).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Race_American_Indian_Select_Box).Click();
                _driver.WaitForPageLoad();
                _driver.FindElement(HomeEquityPage.HE_Ethnicity_Not_Hispanic_Select_Box).Click();
                _driver.WaitForPageLoad();
                IWebElement pullCredit = _driver.FindElement(LoanPage.Pull_Credit_Btn);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", pullCredit);
                _driver.FindElement(LoanPage.Pull_Credit_Btn).Click();
                _driver.WaitForPageLoad();
                _driver.ExtraWait();
                test.Log(Status.Info, "Home equity application created " + _driver.Title);

                _driver.WaitForPageLoad();
                _driver.FindElement(HEEasyApplicationPage.HMDAInfo_Lnk).Click();
                _driver.WaitForPageLoad();
                test.Log(Status.Info, "Navigated to HDMA info page " + _driver.Title);

                universalLoanID = _driver.FindElement(HEHMDAIformationPgae.UniversalLoanIdentifier).GetAttributeValue("value");

                Console.WriteLine(universalLoanID);
                IWebElement ReviewAndSave_Btn = _driver.FindElement(HEHMDAIformationPgae.ReviewAndSave_Btn);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", ReviewAndSave_Btn);
                ReviewAndSave_Btn.Click();
                IWebElement Main_Focus = _driver.FindElement(HomePage.Main_Focus);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", Main_Focus);
                Main_Focus.Click();
                _driver.isDialogPresent();
                _driver.WaitForPageLoad();
                application = "exist";
                test.Log(Status.Info, "Home equity app saved " + _driver.Title);

            }
        }
    }
}
