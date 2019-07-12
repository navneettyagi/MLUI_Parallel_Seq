using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class StatusPage
    {
        public static By Approval_Date_Txt = By.Id("ApprovalDate");

        public static By Declined_Date_Txt = By.Id("DeclinedDate");
    }
}
