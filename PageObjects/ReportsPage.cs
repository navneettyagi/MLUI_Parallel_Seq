using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class ReportsPage
    {
        public static By Report_Type_Ddn = By.Id("ctl00_bc_ddlReportType");

        public static string frame1 = "frame1";

        //Standard Report objects
        public static By Approved_Loans_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl01_rdo");

        public static By Credit_Score_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl03_rdo");

        public static By Show_Report_Btn = By.Id("ctl00_bc_btnRunReport");

        public static By Dealership_Production_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl06_rdo");

        public static By Funded_Loans_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl07_rdo");

        public static By Funding_Source_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl08_rdo");

        public static By App_Type_Ddn = By.Id("ctl00_bc_LoanType");

        public static By Display_Ddn = By.Id("ctl00_bc_ExportOption");

        public static By Branch_Activites_Radio_Btn = By.Id("ctl00_bc_lstPrebuildReports_ctl02_rdo");

        //Standard report new window objects
        public static By Nobr_Tags = By.TagName("nobr");

        public static By Credit_Score_Lbl = By.XPath(".//span/nobr[text()='MARISOL']/parent::span[1]/following-sibling::span[2]/nobr");


        //Custom Reports objects
       
        public static By Custom_Report_Manage_Btn = By.Id("ctl00_bc_lbtnManageCustomReports");

        public static By Custom_Reports_All = By.TagName("label");


        //Manage Custom Reports page objects
        public static By Reports_Page_Link = By.Id("ctl00_Pagehistory2_PageHistory_ctl01_PageHistoryStep");

        public static By add_NewCustomReport_Button = By.XPath("//input[@type='button'][@value='Add New Custom Report']");

        public static By table_CustomReports = By.XPath(".//table[@id='ctl00_bc_dg']/tbody/tr");

        //Custome Reports Designer New Window Objects
        public static By textBox_Report_Title = By.Id("TextBoxReportTitle");

        public static By add_NewColumn_Link = By.LinkText("[Click here to add new column]");

        public static By general_Loan_Fields = By.XPath("//a[@id='QueryColumns_entities_t_4']/img");

        public static By approved_Amount = By.XPath("//a[@id='QueryColumns_entities_t_64']/img");

        public static By btnRunReport = By.Id("btnRunReport");

        public static By ButtonSave = By.Id("ButtonSave");

    }
}
