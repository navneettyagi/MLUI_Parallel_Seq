using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class CustomAppQueuesPage
    {
        public static By Filters_Lnk = By.Id("ctl00_bc_dg_ctl02_lbtnFilters");

        //Ready for funding queue filters page 
        public static By Add_Condtion_Icon = By.Id("ctl00_bc_ConditionSet_Edit_CSRoot_AddConditionLink");

        public static By Test_ConditionSet_Lnk = By.Id("ctl00_bc_ConditionSet_Edit_lnkTest");


        //Add Condtion new window objects

        public static By Add_Condition_Txt = By.Id("ctl00_bc_ConditionSet_Edit_ConditionEdit_drpSystemField-input");

        public static By Application_Type_Lnk = By.LinkText("Application Type");

        public static By Add_Condition_Ddn2 = By.Id("ctl00_bc_ConditionSet_Edit_ConditionEdit_drpOperator");

        public static By Add_Condition_Ddn3 = By.Id("ctl00_bc_ConditionSet_Edit_ConditionEdit_drpValue");

        public static By Add_Condition_Save_Btn = By.Id("ctl00_bc_ConditionSet_Edit_ConditionEdit_btnAddCondition");

        public static By Add_Condition_Header_Lbl = By.Id("ctl00_bc_ConditionSet_Edit_ConditionEdit_lblAddConditionHeader");

        //Test Condition window objects

        public static By TestCondition_Application_Number_Txt = By.Id("ctl00_bc_ConditionSet_Edit_ConditionTest_txtLoanNumber");

        public static By TestCondition_Test_Btn = By.Id("ctl00_bc_ConditionSet_Edit_ConditionTest_btnTest");

        public static By TestCondition_Cancel_Btn = By.Id("ctl00_bc_ConditionSet_Edit_ConditionTest_btnClose");

        public static By TestCondition_Message_Txt = By.Id("ctl00_bc_ConditionSet_Edit_ConditionTest_lblMsg");
        
    }
}
