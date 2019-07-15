using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class LoanPage
    {
        public static By App_Number_Txt = By.Id("pre_sb_LoanNumber");

        public static By MemberNumber_MemberN = By.Id("ali_MemberNumber_MemberN");

        public static By TdMemberNumber_Title = By.Id("ali_tdMemberNumber_Title");

        public static By Sb_LoanNumber = By.Id("pre_sb_LoanNumber");

        public static By Sa_FName = By.Id("sa_FName");

        public static By Sa_LName = By.Id("sa_LName");

        public static By Loan_Status_DropDown = By.Id("pre_sb_ls_cboLoanStatus");

        public static By Requested_Credit_Limit_TextField = By.Id("RequestedCreditLimit");

        public static By SSN_Txt = By.Id("sa_SSN");

        public static By MemberNumber_TextField = By.Id("ali_MemberNumber_MemberN");

        public static By Purpose_Type_Dropdown = By.Id("RequestType_RequestType");

        public static By FName_Txt = By.Id("sa_FName");

        public static By LName_TextField = By.Id("sa_LName");

        public static By Custom_Question_CheckBox = By.Id("CQuest_rpt_ctl01_SingleCustomQuestion_chkAnswer_0");

        public static By Custom_Question_WordOfMouth_SelectBox = By.Id("CQuest_rpt_ctl01_SingleCustomQuestion_chkAnswer_0");

        public static By Comments_Link = By.LinkText("Comments"); 

        public static By Status_Lnk = By.LinkText("Status");

        //Qualifying products page objects

        public static By Continue_Without_Preapproval_Lnk = By.Id("PreQualifications_lbtnContinueWithoutPreapproval");

        //Approval Loan window objects
        public static By Comment_TextField = By.Id("ctl00_bc_Comment");

        public static By Approval_Denial_Save_Button = By.Id("ctl00_Buttons_btnSave");

        public static By Approval_Decisions_Tab = By.Id("TAB_divDecisions");

        public static By Approval_Loan_Cancel_Btn = By.Id("ctl00_Buttons_btnClose");

        //Denial Loan window objects

        public static By Loan_Denial_Tab = By.Id("TAB_divDecisions");

        public static By Edit_Reasons_Btn = By.Id("ctl00_bc_rptApplicants_ctl00_editReasons");

        public static By Denial_Reason_Txt = By.Id("ctl00_bc_ApprovalDenialReasons");

        public static By Denial_Save_Btn = By.Id("ctl00_bc_btnSave");

        public static By Denial_Cancel_Btn = By.Id("ctl00_Buttons_btnCancel");

        //Vehicle Loan application page objects

        public static By Amount_Requested_Txt = By.Id("AmountRequested");

        public static By Loan_Term_Txt = By.Id("LoanTerm");

        public static By Purpose_Type_Ddn = By.Id("RequestType_RequestType");

        public static By Custom_Question_Ddn_First = By.Id("CQuest_rpt_ctl03_SingleCustomQuestion_drpAnswer");

        public static By Custom_Question_Ddn_Second = By.Id("CQuest_rpt_ctl04_SingleCustomQuestion_drpAnswer");

        public static By Pull_Credit_Btn = By.Id("runcredit_btnSavePullCredit");

        public static By ViewCreditNavigationLink = By.Id("pre_lab_credit_linkViewBorrowerCredit");

        public static By ApplicantInfoLink = By.Id("pre_lab_lbtnShortApp");

        public static By CreditScoreApplicantInfo = By.Id("pre_sb_ctl01_PrimaryCreditScore");

        public static By QualifiedProductAcceptButton = By.Id("products_rptPass_ctl00_dgRates_ctl02_btnAccept");

        public static By UnderWwritingTable = By.Id("ufo_calc_tblBorrower");

        public static By ViewCreditSSN = By.XPath("//*[text()='000-00-0001']");

        public static By CrossQualificationSummaryLink = By.Id("pre_lab_CrossQualifyButtonSummary1_lbtnCrossQALL");

        public static By BtnClosePreQualifiedProduct_dialog = By.Id("ctl00_Buttons_closeButton");

        public static By RevolvingAccountPreQualifiedProduct = By.XPath("//table[@id='tblRevolving']/tbody/tr/td[1]");

        public static By LoanAppNumber = By.Id("pre_sb_LoanNumber");

        public static By LetterDocs_Lnk = By.Id("pre_lab_lbtnLetters");        
    }
}
