using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class PrintPreviewPage
    {
        public static By Print_Btn = By.Id("btnPrint");

        public static By Close_Btn = By.Id("btnClose");

        public static string Frame = "menu";

        public static By AllDocuments_Ddn_Options = By.XPath(".//select[@class='document-selection ng-pristine ng-valid']//option");

        public static By AllDocuments_Ddn = By.XPath(".//select[@class='document-selection ng-pristine ng-valid']");

        public static By SaveAsIncomplete_Btn = By.Id("btnIncomplete");
    }
}
