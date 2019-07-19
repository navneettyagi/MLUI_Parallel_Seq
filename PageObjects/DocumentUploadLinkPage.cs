using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class DocumentUploadLinkPage
    {

        public static By GenerateLink_Lnk = By.Id("lnkGenerateLink");

        public static By URL = By.XPath(".//span[@class='link']");
    }
}
