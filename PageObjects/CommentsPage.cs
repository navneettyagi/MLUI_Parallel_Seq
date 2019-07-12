using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class CommentsPage
    {
        public static By Decision_Comments_Txt = By.Id("lc_DecisionComments");

        public static By Denial_Comments_Txt = By.Id("lc_rptApproveDeny_ctl00_ApprovalDenialReasons");
    }
}
