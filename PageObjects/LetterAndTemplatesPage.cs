using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class LetterAndTemplatesPage
    {
        public static By Documents_Tab = By.Id("TAB_Documents");

        public static By AddNew_Btn = By.Id("ctl00_bc_btnAddClientPDF");

        public static By Mapping_Lnk = By.Id("ctl00_bc_dgClientPDF_ctl03_HyperLink3");
    }
}
