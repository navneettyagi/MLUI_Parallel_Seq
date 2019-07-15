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
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework.Steps
{
    [Binding]
    public class ReportsSteps:TestBase
    {        
        public String customReportTitle = "Test Amount Approved";
        String amountApproved = "Amount Approved";
        String customReportName;
        Actions action;
        SelectElement select;

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
            _driver.WaitForPageLoad();
            _driver.WaitForObjectAvaialble(HomePage.MainContent_lblWelcome);
            _driver.FindElement(HomePage.MainContent_lblWelcome).AssertElementPresent();
        }

        [Given(@"User navigated to Reports page")]
        public void GivenUserNavigatedToReportsPage()
        {

            _driver.HoverAndClick(_driver.FindElement(HomePage.MouseHover_Tools), _driver.FindElement(HomePage.MouseHover_Reports));
            _driver.WaitForPageLoad();
            _driver.HoverAndClick(_driver.FindElement(HomePage.MouseHover_RunSchedule), _driver.FindElement(HomePage.MouseHover_RunSchedule));
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User navigated to reports *Page " + _driver.Title);
        }
        [Given(@"User selected Approved Loans Pre-built reports in XLS format")]
        public void GivenUserSelectedApprovedLoansPre_BuiltReportsInXLSFormat()
        {
            _driver.FindElement(ReportsPage.Approved_Loans_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            select = new SelectElement(_driver.FindElement(ReportsPage.Display_Ddn));
            select.SelectByText("XLS");
            _driver.WaitForPageLoad();
        }


        [Given(@"User selected Pre-built Credit Score reports")]
        public void GivenUserSelectedPre_BuiltCreditScoreReports()
        {
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.Credit_Score_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User selected Pre-built credit score reports *Page " + _driver.Title);
        }

        [Given(@"User selected Branch Activities Pre-built reports for Mortgage Loan")]
        public void GivenUserSelectedBranchActivitiesPre_BuiltReportsForMortgageLoan()
        {
            _driver.FindElement(ReportsPage.Branch_Activites_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.App_Type_Ddn).SelectDropDown("Mortgage");
            _driver.WaitForPageLoad();
        }


        [Given(@"User selected pre-built Credit Score Reports for Vehicle Loan")]
        public void GivenUserSelectedPre_BuiltCreditScoreReportsForVehicleLoan()
        {
            _driver.FindElement(ReportsPage.Credit_Score_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            select = new SelectElement(_driver.FindElement(ReportsPage.App_Type_Ddn));
            _driver.WaitForPageLoad();
            select.SelectByText("Vehicle");
            _driver.WaitForPageLoad();
        }

        [Given(@"User designed a custom report as Amount Approved")]
        public void GivenUserDesignedACustomReportAsAmountApproved()
        {
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown("Custom");
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.Custom_Report_Manage_Btn).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.add_NewCustomReport_Button).Click();
            _driver.WaitForPageLoad();
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
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
            _driver.WaitForPageLoad();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
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
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown("Custom");
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
                    break;
                }
            }
        }

        [Given(@"User selected Dealership Production Pre-built reports")]
        public void GivenUserSelectedDealershipProductionPre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Dealership_Production_Radio_Btn).Click();
            _driver.WaitForPageLoad();
        }


        [Given(@"User selected Credit Score Reports in PDF format for Vehicle Loan")]
        public void GivenUserSelectedCreditScoreReportsInPDFFormatForVehicleLoan()
        {
            _driver.FindElement(ReportsPage.Credit_Score_Radio_Btn).Click();
            _driver.WaitForPageLoad();
            select = new SelectElement(_driver.FindElement(ReportsPage.Display_Ddn));
            _driver.WaitForPageLoad();
            select.SelectByText("PDF");
            _driver.WaitForPageLoad();
        }

        [Given(@"User selected Funding Source Pre-built reports")]
        public void GivenUserSelectedFundingSourcePre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Funding_Source_Radio_Btn).Click();
            _driver.WaitForPageLoad();
        }


        [Given(@"User selected Funded Loans Pre-built reports")]
        public void GivenUserSelectedFundedLoansPre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Funded_Loans_Radio_Btn).Click();
            _driver.WaitForPageLoad();
        }


        [Given(@"User selected Approved Loans Pre-built reports")]
        public void GivenUserSelectedApprovedLoansPre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Approved_Loans_Radio_Btn).Click();
            _driver.WaitForPageLoad();
        }

        [When(@"User ran Pre-built reports")]
        public void WhenUserRanPre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Show_Report_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on show button *Page " + _driver.Title);
        }

        [When(@"User ran Approved Loans Pre-built reports in XLS format")]
        public void WhenUserRanApprovedLoansPre_BuiltReportsInXLSFormat()
        {
            _driver.FindElement(ReportsPage.Show_Report_Btn).Click();
            Thread.Sleep(5000);
            //To-do: Exclude autoIT script
            Process.Start("C://Users//tgundarapu//Documents//ClickOnSave.exe");
            _driver.WaitForPageLoad();
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);

            //To-do: Excel downloand and open file at run time
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver,main_window);
        }

        [When(@"User designed a custom report for Credit Score")]
        public void WhenUserDesignedACustomReportForCreditScore()
        {
            _driver.FindElement(ReportsPage.Report_Type_Ddn).SelectDropDown("Custom");
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.Custom_Report_Manage_Btn).Click();
            _driver.ExtraWait();
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.add_NewCustomReport_Button).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "User clicked on new custom report button *Page " + _driver.Title);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            action = new Actions(_driver);
            _driver.FindElement(ReportsPage.textBox_Report_Title).EnterText(customReportTitle);
            test.Log(Status.Info, "User entered custom report title *Page " + _driver.Title);
            _driver.FindElement(ReportsPage.add_NewColumn_Link).Click();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.general_Loan_Fields)).Build().Perform();
            _driver.WaitForPageLoad();
            action.MoveToElement(_driver.FindElement(ReportsPage.approved_Amount)).Click().Build().Perform();
            test.Log(Status.Info, "User selected approved amount value  *Page " + _driver.Title);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.btnRunReport).SendKeys(Keys.Enter);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame(0);
            _driver.WaitForPageLoad();
            _driver.FindElement(ReportsPage.ButtonSave).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
        }
        [Given(@"User selected Branch Activities Pre-built reports")]
        public void GivenUserSelectedBranchActivitiesPre_BuiltReports()
        {
            _driver.FindElement(ReportsPage.Branch_Activites_Radio_Btn).Click();
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Branch Activities Pre-built reports")]
        public void ThenUserVerifiedBranchActivitiesPre_BuiltReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> branchActivities = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(branchActivities[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(branchActivities[0].GetText().Contains("Branch Statistic"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Pre-built Credit Score reports")]
        public void ThenUserVerifiedPre_BuiltCreditScoreReports()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.Nobr_Tags);
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()),"Date not matched");
            test.Log(Status.Info, "User verified credit score reports *Page " + _driver.Title);
            for (int i=0; i<creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals("NA"))
                {
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }

            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
           
        }

        [Then(@"User verified Credit Score reports for Vehicle Loan")]
        public void ThenUserVerifiedCreditScoreReportsForVehicleLoan()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.Nobr_Tags);
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            for (int i = 0; i < creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals("NA"))
                {
                    Console.WriteLine("Credit Score is dispalying NA");
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }

            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Approved Loans reports")]
        public void ThenUserVerifiedApprovedLoansReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> creditScores = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(creditScores[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            for (int i = 0; i < creditScores.Count; i++)
            {
                if (creditScores[i].GetText().Equals("NA"))
                {
                    Console.WriteLine("Credit Score is dispalying NA");
                    Assert.IsTrue(!creditScores[i].GetText().Equals("NA"));
                }
            }
            
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Credit Score custom report creation")]
        public void ThenUserVerifiedCreditScoreCustomReportCreation()
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
            test.Log(Status.Info, "User verified created custom report *Page " + _driver.Title);
        }

        [Then(@"User verified Credit Score reports with PDF format for Vehicle Loan")]
        public void ThenUserVerifiedCreditScoreReportsWithPDFFormatForVehicleLoan()
        {
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();

            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            // To-do: PDF downloading at run time
            String pdfData = PdfHelper.GetAllTextFromPDF(_driver, "C://Users//tgundarapu//Desktop//Viewer_pdf.pdf");
            Assert.IsTrue(pdfData.Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
        }

        [Then(@"User verified Approved Loans reports in XLS format")]
        public void ThenUserVerifiedApprovedLoansReportsInXLSFormat()
        {
            // To-do: Excel reading from downloaded document 
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Branch Activities Pre-built reports for Mortgage Loan")]
        public void ThenUserVerifiedBranchActivitiesPre_BuiltReportsForMortgageLoan()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1"); 
            IList<IWebElement> branchActivitiesMortgageLoan = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(branchActivitiesMortgageLoan[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(branchActivitiesMortgageLoan[0].GetText().Contains("Branch Statistic  - Mortgage Loan"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Dealership Production Pre-built reports")]
        public void ThenUserVerifiedDealershipProductionPre_BuiltReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> dealershipProduction = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(dealershipProduction[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(dealershipProduction[0].GetText().Contains("Indirect Dealer Production Report"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Funded Loans Pre-built reports")]
        public void ThenUserVerifiedFundedLoansPre_BuiltReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> fundedLoans = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(fundedLoans[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(fundedLoans[0].GetText().Contains("Funded"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Funding Source Pre-built reports")]
        public void ThenUserVerifiedFundingSourcePre_BuiltReports()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> fundingSource = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(fundingSource[2].GetText().Contains("From " + firstDayOfMonth.ToShortDateString() + " - " + lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(fundingSource[0].GetText().Contains("Credit Card Funding Summary"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }

        [Then(@"User verified Amount Approved custom report")]
        public void ThenUserVerifiedAmountApprovedCustomReport()
        {
            var date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string main_window = "";
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().Frame("frame1");
            IList<IWebElement> amountApproved = _driver.FindElements(ReportsPage.Nobr_Tags);
            Assert.IsTrue(amountApproved[2].GetText().Contains(firstDayOfMonth.ToShortDateString() +" To "+ lastDayOfMonth.ToShortDateString()));
            Assert.IsTrue(amountApproved[0].GetText().Contains("Amount Approved"));
            _driver.SwitchTo().DefaultContent();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
        }
    }
}
