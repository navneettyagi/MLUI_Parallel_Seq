using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class UploadLoanDocumentPage
    {
        public static By Title_Ddn = By.XPath(".//select[@id='ctl00_bc_Title']/following-sibling::input");

        public static By Browse_Btn = By.XPath(".//input[@type='file']");

        public static By Comments_Txt = By.Id("ctl00_bc_Comments");

        public static By Save_Btn = By.Id("ctl00_Buttons_btnSave");

        public static By Browse_Iframe = By.Id("ctl00_bc_FileAttached_ctl01");

        public static By Close_Button = By.XPath(".//input[@value='Close']");
    }
}
