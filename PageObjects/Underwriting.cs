using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class Underwriting
    {
        public static By NewAppMenu = By.XPath("//img[@class='rollover' and @alt='New App']");

        public static By VehicleSubmenu = By.XPath("//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[6]/a");

        public static By AmountRequestedTextBox = By.Id("AmountRequested");

        public static By LoanTermTextBox = By.Id("LoanTerm");

        public static By PurposeTypeDropdown = By.Id("RequestType_RequestType");

        public static By SSNTextBox = By.Id("sa_SSN");

        public static By FirstNameTextBox = By.Id("sa_FName");

        public static By CustomQuestionCheckBox = By.Id("CQuest_rpt_ctl01_SingleCustomQuestion_chkAnswer_0");

        public static By CustomQuestionDropdown_First = By.Id("CQuest_rpt_ctl03_SingleCustomQuestion_drpAnswer");

        public static By CustomQuestionDropdown_Second = By.Id("CQuest_rpt_ctl04_SingleCustomQuestion_drpAnswer");

        public static By PullCreditButton = By.Id("runcredit_btnSavePullCredit");

        public static By ContinueWithoutApprovalLink = By.Id("PreQualifications_lbtnContinueWithoutPreapproval");

        public static By ViewCreditNavigationLink = By.Id("pre_lab_credit_linkViewBorrowerCredit");

        public static By ApplicantInfoLink = By.Id("pre_lab_lbtnShortApp");

        public static By CreditScoreApplicantInfo = By.Id("pre_sb_ctl01_PrimaryCreditScore");

        public static By QualifiedProductAcceptButton = By.Id("products_rptPass_ctl00_dgRates_ctl02_btnAccept");

        public static By UnderWwritingTable = By.Id("ufo_calc_tblBorrower");

        public static By ViewCreditSSN = By.XPath("//*[text()='000-00-0001']");

        public static By CrossQualificationSummaryLink = By.Id("pre_lab_CrossQualifyButtonSummary1_lbtnCrossQALL");

        public static String Frm_name_PreQualifiedProduct_dialog = "dialog-frame";

        public static By BtnClosePreQualifiedProduct_dialog = By.Id("ctl00_Buttons_closeButton");

        public static By RevolvingAccountPreQualifiedProduct = By.XPath("//table[@id='tblRevolving']/tbody/tr/td[1]");

    }
}
