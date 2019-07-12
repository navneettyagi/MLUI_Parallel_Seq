using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class AddPdfPage
    {
        public static By PdfTitle_Txt = By.Id("ctl00_bc_Title");

        public static By FileUploader_IFrame = By.Id("ctl00_bc_FileUploader_ctl00");

        public static By Browse_Btn = By.XPath(".//input[@type='file']");

        public static By AppType_VL_Chckbx = By.Id("ctl00_bc_rptLoanTypeCheckboxes_ctl05_chkLoanType");

        public static By Save_Btn = By.Id("ctl00_Buttons_cmdSave");
    }
}
