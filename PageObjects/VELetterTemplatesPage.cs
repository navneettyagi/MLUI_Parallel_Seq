using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class VELetterTemplatesPage
    {
        public static By AttachDocument_Btn = By.Id("LDocs_btnAttachDoc");

        public static By Display_Lnk = By.Id("LDocs_dg_ctl02_lnkDisplay");

        public static By FileName = By.XPath(".//table[@id='LDocs_dg']//tr[2]/td[2]");

        public static By ShowConsumer_Lnk = By.Id("LDocs_dg_ctl02_btnShowC");

        public static By ConsumerVisibility = By.XPath(".//table[@id='LDocs_dg']//tr[2]/td[5]");

        public static By RemoteDocUpload_Btn = By.Id("LDocs_RemoteDocUploadButton_btnRequestDocUpload");

        public static By UploadDocuments_TableItems_Arrow = By.XPath(".//table[@id='LDocs_dg']/tbody/tr[2]/td[1]");

        public static By UploadDocuments_Rows = By.XPath(".//table[@id='LDocs_dg']//tr");

        public static By PdfMaster_Chckbx = By.Id("PDFs_rptPDF_ctl00_lstPDF_ctl01_ctlMaster");

        public static By DisplaySelected_Btn = By.Id("PDFs_btnDisplaySelected");

        public static By ClientPDF_Lnk = By.XPath(".//a[contains(@href,'javascript:editClientPDF')]");

        public static By IncompletePDFs = By.XPath(".//table[@id='ILL_lstPDF']/tbody/tr[2]/td/ul/li");



    }
}
