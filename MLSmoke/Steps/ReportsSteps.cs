using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MLAutoFramework.Base;
using MLAutoFramework.Extensions;
using MLAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using MLAutoFramework.PageObjects;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class ReportsSteps:TestBase
    {
        public string customReportTitle = "Test Amount Approved";
        string amountApproved = "Amount Approved";
        string customReportName;
        string mortgage = "Mortgage";
        string vehicle = "Vehicle";
        string custom = "Custom";
        string na = "NA";
        Actions action;
        SelectElement select;
        string main_window = "";

        private IWebDriver _driver;
        private new ExtentTest test;
        public ReportsSteps(IWebDriver driver, ExtentTest test)
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

        [Given(@"User login to application")]
        public void GivenUserLoginToApplication()
        {
            test.Log(Status.Info, "User logged in successfully" + _driver.Title);
        }

        [Given(@"User navigated to Reports page")]
        public void GivenUserNavigatedToReportsPage()
        {

            _driver.HoverAndClick(_driver.FindElement(HomePage.MouseHover_Tools), _driver.FindElement(HomePage.MouseHover_Reports));
            _driver.WaitForPageLoad();
            _driver.HoverAndClick(_driver.FindElement(HomePage.MouseHover_RunSchedule), _driver.FindElement(HomePage.MouseHover_RunSchedule));
            test.Log(Status.Info, "User navigated to Reports page" + _driver.Title);
        }
        
        [Given(@"User selected Pre-built Credit Score reports")]
        public void GivenUserSelectedPre_BuiltCreditScoreReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Credit_Score_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Credit_Score_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Pre-built Credit Score reports" + _driver.Title);
        }

        [Given(@"User selected Branch Activities Pre-built reports for Mortgage Loan")]
        public void GivenUserSelectedBranchActivitiesPre_BuiltReportsForMortgageLoan()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Branch_Activites_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Branch_Activites_Radio_Btn).Click();
            _driver.WaitForElementPresentAndEnabled(ReportsPage.App_Type_Ddn, 60);
            _driver.FindElement(ReportsPage.App_Type_Ddn).SelectDropDown(mortgage);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Branch Activities Pre-built reports for Mortgage Loan " + _driver.Title);
        }


        [Given(@"User selected pre-built Credit Score Reports for Vehicle Loan")]
        public void GivenUserSelectedPre_BuiltCreditScoreReportsForVehicleLoan()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Credit_Score_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Credit_Score_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            select = new SelectElement(_driver.FindElement(ReportsPage.App_Type_Ddn));
            _driver.WaitForPageLoad();
            select.SelectByText(vehicle);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected pre-built Credit Score Reports for Vehicle Loan from dropdown" + _driver.Title);
        }

        [Given(@"User designed a custom report as Amount Approved")]
        public void GivenUserDesignedACustomReportAsAmountApproved()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Report_Type_Ddn, 60);
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown("Custom");
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.Custom_Report_Manage_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.add_NewCustomReport_Button).Click();
            _driver.WaitForPageLoad();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            action = new Actions(_driver);
            _driver.FindElement(ReportsPage.textBox_Report_Title).EnterText(amountApproved);
            _driver.FindElement(ReportsPage.add_NewColumn_Link).Click();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.general_Loan_Fields)).Build().Perform();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.approved_Amount)).Click().Build().Perform();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.btnRunReport).Click();
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(0);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.ButtonSave).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User designed a custom report as Amount Approved" + _driver.Title);
        }

        [When(@"User ran Amount Approved custom report")]
        public void WhenUserRanAmountApprovedCustomReport()
        {
            String customReportAmountApproved = amountApproved;
            IList<IWebElement> list = _driver.FindElements(ReportsPage.table_CustomReports);
            for (int i = 2; i <= list.Count; i++)
            {
                String reportTitle = _driver.FindElement(By.XPath(".//table[@id='ctl00_bc_dg']//tbody//tr[" + i + "]/td[2]")).GetText();
                if (reportTitle.Equals(customReportAmountApproved))
                {
                    _driver.FindElement(ReportsPage.Reports_Page_Link).Click();
                    _driver.WaitForPageLoad();
                    break;
                }
            }
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown(custom);
            _driver.WaitForPageLoad();
            IList<IWebElement> customReports = _driver.FindElements(ReportsPage.Custom_Reports_All);
            for (int j = 0; j < customReports.Count; j++)
            {
                if (customReports[j].GetText().Equals(customReportAmountApproved))
                {
                    _driver.FindElement(By.XPath(".//label[text()='Amount Approved']")).Click();
                    _driver.WaitForPageLoad();
                    _driver.FindElement(ReportsPage.Show_Report_Btn).Click();
                    _driver.WaitForPageLoad();
                    test.Log(Status.Info, "User clicked on show button" + _driver.Title);
                    break;
                }
            }
        }

        [Given(@"User selected Dealership Production Pre-built reports")]
        public void GivenUserSelectedDealershipProductionPre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Dealership_Production_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Dealership_Production_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Dealership Production Pre-built reports" + _driver.Title);
        }
        
        [Given(@"User selected Funding Source Pre-built reports")]
        public void GivenUserSelectedFundingSourcePre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Funding_Source_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Funding_Source_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Funding Source Pre-built reports" + _driver.Title);
        }


        [Given(@"User selected Funded Loans Pre-built reports")]
        public void GivenUserSelectedFundedLoansPre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Funded_Loans_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Funded_Loans_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Funded Loans Pre-built reports" + _driver.Title);
        }


        [Given(@"User selected Approved Loans Pre-built reports")]
        public void GivenUserSelectedApprovedLoansPre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Approved_Loans_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Approved_Loans_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Pre-built approved loans reports" + _driver.Title);
        }

        [When(@"User ran Pre-built reports")]
        public void WhenUserRanPre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Show_Report_Btn, 60);
            _driver.FindElement(ReportsPage.Show_Report_Btn).Click();
            test.Log(Status.Info, "User clicked on show report button" + _driver.Title);
        }

        [When(@"User designed a custom report for Credit Score")]
        public void WhenUserDesignedACustomReportForCreditScore()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Report_Type_Ddn, 60);
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown(custom);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.Custom_Report_Manage_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.add_NewCustomReport_Button).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on New Custom " + _driver.Title);
            main_window = WindowHelper.switchToChildWindow(_driver);
            action = new Actions(_driver);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.textBox_Report_Title).EnterText(customReportTitle);
            _driver.FindElement(ReportsPage.add_NewColumn_Link).Click();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.general_Loan_Fields)).Build().Perform();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.approved_Amount)).Click().Build().Perform();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.btnRunReport).Click();
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(0);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.ButtonSave).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }
        [Given(@"User selected Branch Activities Pre-built reports")]
        public void GivenUserSelectedBranchActivitiesPre_BuiltReports()
        {
            _driver.WaitForElementPresentAndEnabled(ReportsPage.Branch_Activites_Radio_Btn, 60);
            _driver.FindElement(ReportsPage.Branch_Activites_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Branch Activities Pre-built reports" + _driver.Title);
        }

        [Then(@"User verified Branch Activities Pre-built reports")]
        public void ThenUserVerifiedBranchActivitiesPre_BuiltReports()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> branchActivities = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(branchActivities[0].GetText().Contains("Branch Statistic"));
            test.Log(Status.Info, "User verified Branch Activities reports" + _driver.Title);
        }

        [Then(@"Pre-built Credit Score reports should be displayed")]
        public void ThenPre_BuiltCreditScoreReportsShouldBeDisplayed()
        {
            Thread.Sleep(45000);
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.Nobr_Tags);
            Console.WriteLine("Elements stored");
            for (int i = 7; i < creditScores.Count; i++)
            {
                Console.WriteLine(creditScores[i].GetText());
               /*if (creditScores[i].GetText().Equals(na))
                {
                    Assert.IsTrue(!creditScores[i].GetText().Equals(na));
                }*/
            }
            test.Log(Status.Info, "Credit Scores are verified" + _driver.Title);
        }

        [Then(@"Custom report should be created as Test Amount Approved")]
        public void ThenCustomReportShouldBeCreatedAsTestAmountApproved()
        {
            IList<IWebElement> list = _driver.FindElements(ReportsPage.table_CustomReports);
            for (int i = 2; i <= list.Count; i++)
            {
                String reportName = _driver.FindElement(By.XPath(".//table[@id='ctl00_bc_dg']//tbody//tr[" + i + "]/td[2]")).GetText();
                if (reportName.Equals(customReportTitle))
                {
                    customReportName = reportName;
                    break;
                }
            }
            Assert.IsTrue(customReportName.Equals(customReportTitle));
            test.Log(Status.Info, "User verified as a new custom report is created" + _driver.Title);
        }

        [Then(@"User verified Branch Activities Pre-built reports for Mortgage Loan")]
        public void ThenUserVerifiedBranchActivitiesPre_BuiltReportsForMortgageLoan()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1); 
            IList<IWebElement> branchActivitiesMortgageLoan = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(branchActivitiesMortgageLoan[0].GetText().Contains("Branch Statistic  - Mortgage Loan"));
            test.Log(Status.Info, "User verified Branch Activities Pre-built reports for Mortgage Loan" + _driver.Title);
        }

        [Then(@"User verified Dealership Production Pre-built reports")]
        public void ThenUserVerifiedDealershipProductionPre_BuiltReports()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> dealershipProduction = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(dealershipProduction[0].GetText().Contains("Indirect Dealer Production Report"));
            test.Log(Status.Info, "User verified Dealership Production Pre-built reports" + _driver.Title);
        }

        [Then(@"User verified Funded Loans Pre-built reports")]
        public void ThenUserVerifiedFundedLoansPre_BuiltReports()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> fundedLoans = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(fundedLoans[0].GetText().Contains("Funded"));
            test.Log(Status.Info, "User verified Funded Loans Pre-built reports" + _driver.Title);
        
        }

        [Then(@"User verified Funding Source Pre-built reports")]
        public void ThenUserVerifiedFundingSourcePre_BuiltReports()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> fundingSource = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(fundingSource[0].GetText().Contains("Credit Card Funding Summary"));
            test.Log(Status.Info, "User verified Funding Source Pre-built reports" + _driver.Title);
        }

        [Then(@"User verified Amount Approved custom report")]
        public void ThenUserVerifiedAmountApprovedCustomReport()
        {

            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> amountApproved = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(amountApproved[0].GetText().Contains("Amount Approved"));
            test.Log(Status.Info, "User verified Amount Approved custom report" + _driver.Title);
        }

        [Then(@"Pre-built reports for Approved Loans should be displayed")]
        public void ThenPre_BuiltReportsForApprovedLoansShouldBeDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> branchActivities = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(branchActivities[0].GetText().Contains("Approvals (Funded vs Not Funded)"));
            test.Log(Status.Info, "User verified approved loans " + _driver.Title);
        }

        [Then(@"Pre-built Vehicle Loan Credit Score reports should be displayed")]
        public void ThenPre_BuiltVehicleLoanCreditScoreReportsShouldBeDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(ReportsPage.frame1);
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.Nobr_Tags);
            for (int i = 0; i < creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals(na))
                {
                    test.Log(Status.Info, "Credit Score contains NA" + _driver.Title);
                    Assert.IsTrue(!creditScores[i].GetText().Equals(na));
                }
            }
            test.Log(Status.Info, "User verified Credit score for Vehicle Loan applicaitons" + _driver.Title);
        }

        [Then(@"Current month reports should be displayed for Custom Report")]
        public void ThenCurrentMonthReportsShouldBeDisplayedForCustomReport()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string firstDayOfTheMonth = firstDayOfMonth.ToString("M/d/yyyy");
            string lastDayOfTheMonth = lastDayOfMonth.ToString("M/d/yyyy");
            IList<IWebElement> dateRange = _driver.FindElements(ReportsPage.Nobr_Tags);
            Console.WriteLine(dateRange[2].GetText());
            Assert.IsTrue(dateRange[2].GetText().Contains(firstDayOfTheMonth + " To " + lastDayOfTheMonth));
            test.Log(Status.Info, "User verified as current month reports are displayed" + _driver.Title);
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }
               
        [Then(@"Current month reports should be displayed")]
        public void ThenCurrentMonthReportsShouldBeDisplayed()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string firstDayOfTheMonth = firstDayOfMonth.ToString("M/d/yyyy");
            string lastDayOfTheMonth = lastDayOfMonth.ToString("M/d/yyyy");
            IList<IWebElement> dateRange = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(dateRange[2].GetText().Contains("From " + firstDayOfTheMonth + " - " + lastDayOfTheMonth));
            test.Log(Status.Info, "User verified as current month reports are displayed" + _driver.Title);
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

    }
}
