using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class FileSharePage
    {
        public static By SendDocument_Lnk = By.Id("btnUploadDocumentLink");

        public static By DocumentType_Ddn = By.Id("DocumentTypeDropDown");

        public static By BrowseFile_Btn = By.Id("fileInput");

        public static By SendDocument_Btn = By.Id("btnSend");

        public static By UploadStatusDisplay_Lbl = By.XPath(".//span[@class='c-uploaderStatusDisplay-errorLabel']");

        public static By UploadDocument_Btn = By.Id("btnUpload");
    }
}
