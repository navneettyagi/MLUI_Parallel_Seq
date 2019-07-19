using OpenQA.Selenium;

namespace MLAutoFramework.PageObjects
{
    class HomePage
    {
        public static By MainContent_lblWelcome = By.Id("ctl00_MainContent_lblWelcome");

        public static By KeySearch_Txt = By.Id("ctl00_h_ctl00_qs_txtQuickLoanNumber");

        public static By Search_Btn = By.XPath(".//img[@src='/Lender/images/headerbutton_search.gif']");

        public static By SearchBy_Ddn = By.Id("ctl00_h_ctl00_qs_SearchBy");

        public static By Exit_Btn = By.XPath(".//*[contains(@id,'ibtnLogout')]");

        public static By Qs_ibtnLogout = By.XPath(".//*[contains(@id,'ibtnLogout')]");

        public static By MyWorkingQueue_Rows = By.XPath(".//table[@id='ctl00_MainContent_dg']//tr");

        public static By App_Column = By.XPath(".//table[@id='ctl00_MainContent_dg']//tr[1]/td");

        public static By MouseHover_Tools = By.XPath("//*[@class='rollover'][@alt='Tools']");

        public static By MouseHover_Reports = By.XPath(".//a[contains(@href,'ProgramSearch.aspx')]/parent::li/following-sibling::li[1]/img");

        public static By MouseHover_RunSchedule = By.XPath(".//a[@href='/lender/reports/newreports.aspx']");

        public static By ViewAPP = By.XPath(".//img[@title='View App']");

        public static By Roolover_NewAPP = By.XPath(".//img[@class='rollover' and @alt='New App']");

        public static By Vehicle_Loan_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[6]/a");

        public static By Home_Equity_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[3]/a");

        public static By New_App_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']");

        public static By Credit_Card_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[2]/a");

        public static By Setup_Focus = By.XPath(".//img[@class='rollover' and @alt='Setup']");

        public static By Custom_App_Queues_Focus = By.XPath(".//img[@class='rollover' and @alt='Setup']//following-sibling::ul/li[4]/a");

        public static By Working_Queue_Rows_Txt = By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr");

        public static By Loan_Officer_Column_Name_Txt = By.XPath(".//table[@id='dg']//tr");

        public static By NewAPP_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']");

        public static By NewVehicle_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[6]/a");

        public static By Main_Focus = By.XPath(".//img[@class='rollover' and @alt='Main']");

        public static By HomeEquity_Focus = By.XPath(".//img[@class='rollover' and @alt='New App']//following-sibling::ul/li[3]/a");

        public static By ViewAPP_Img = By.XPath(".//img[@title='View App']");

        public static By ConfigureSite_Focus = By.XPath(".//img[@class='rollover' and @alt='Setup']//following-sibling::ul/li[2]/a");

        public static By CurrentVersion = By.XPath(".//table[@id='Table2']/tbody/tr[3]/td/div//font");
             
        //public static By App_Action_Icon = By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[2]/td[1]/span/a[6]/img");

        public static By Users_With_This_App__Icon = By.XPath(".//table[@id='ctl00_MainContent_wq_dg']//tr[2]/td[1]/span/a[2]/img");

        //Application assignment new window objects
        public static By App_Assignment_Number_Txt = By.Id("ctl00_PageTitle_LoanNumber");

        public static By Officer_Select_Box = By.XPath(".//table[@id='ctl00_bc_dgLoanOfficers']//tbody/tr[3]/td[1]/input");

        public static By Officer_Name_Txt = By.XPath(".//table[@id='ctl00_bc_dgLoanOfficers']//tbody/tr[3]/td[2]");

        public static By Assign_To_Officers_Btn = By.Id("ctl00_bc_btnAssignOfficer");

        public static By Assign_To_Officers_Comments_Txt = By.Id("ctl00_bc_Comments");

        public static By Assign_To_Officers_Submit_Btn = By.Id("ctl00_bc_btnSubmit");

        public static By Assigned_Status_Txt = By.Id("ctl00_bc_Status");

        public static By Already_Assigned_Status_Txt = By.Id("ctl00_bc_labelError");

        public static By App_Assignment_Close_Btn = By.Id("ctl00_Buttons_btnClose");

        //Users with this app in their queue window objects
        public static By Officer_Names_Window_Close_Btn = By.XPath("//input[@type='button' and @value='Close']");

    }
}
