using MLAutoFramework.PageObjects;
using OpenQA.Selenium;
using MLAutoFramework.Extensions;
using System;
using TechTalk.SpecFlow;
using MLAutoFramework.Helpers;
using System.Threading;
using NUnit.Framework;
using MLAutoFramework.Base;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AventStack.ExtentReports;
using MLAutoFramework.Config;

namespace MLAutoFramework.MLSmoke.Steps
{
    [Binding]
    public class Documents_FeatureSteps : TestBase
    {
        private IWebDriver _driver2;
        string generatedURL;
        string actualFileName;
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        static string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + Settings.TestDataPath;
        static string localpath = new Uri(finalpth).LocalPath;
        string title = "doc";
        string documentType = "doc";
        string fileName = "test";
        string expectedFileName = "test.pdf";
        string commentInTextbox = "test";
        string filePath = localpath+"test.pdf";
        string filePath5MB = localpath + "test5.pdf";
        string filePathJPG = localpath + "JpgFile.jpg";
        string filePathPNG = localpath + "PngFile.png";
        string expectedUploadStatusDisplay = "The file you are transferring is too big. Max file size is 3.91MB.";
        string expectedUploadStatusDisplayJPG = "File type of .JPG not allowed";
        string expectedUploadStatusDisplayPNG = "File type of .PNG not allowed";
        string clientpdfsExpected = "test1test2";
        static string filesAdded = "notexist";
        string filesAddedStatus = "notexist";

        //Vehicle loan strings
        static string amountRequested = "10000";
        static string loanTerm = "36";
        static string purposeTypeText = "Purchase";
        static string customQuestionText = "Yes";
        static string validSsn = "000000001";
        string main_window = "";

        private IWebDriver _driver;
        private new ExtentTest test;
        public Documents_FeatureSteps(IWebDriver driver, ExtentTest test)
        {
            if (Settings.Parallelizable == "Yes")
            {
                _driver = driver;
                this.test = test;
            }
            else if (Settings.Parallelizable == "No")
            {
                _driver = TestBase.driver;
                this.test = test;
            }

        }


        [When(@"User selects Vehicle APP")]
        public void SelectVehicleAPP()
        {
            _driver.WaitForElementPresentAndEnabled(HomePage.NewAPP_Focus, 60);
            _driver.HoverAndClick(_driver.FindElement(HomePage.NewAPP_Focus), _driver.FindElement(HomePage.NewVehicle_Focus));
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Vehicle APP selected " + _driver.Title);
        }


        [When(@"User navigates to letter docs")]
        public void NavigateToLetterDocs()
        {
            _driver.WaitForElementPresentAndEnabled(LoanPage.LetterDocs_Lnk, 60);
            _driver.FindElement(LoanPage.LetterDocs_Lnk).Click();
            _driver.isDialogPresent();
            _driver.isDialogPresent();
            test.Log(Status.Info, "Navigated to letter docs " + _driver.Title);
        }


        [When(@"User Attached document")]
        public void AttachDocument()
        {
            _driver.WaitForPageLoad();
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.AttachDocument_Btn, 60);
            _driver.FindElement(VELetterTemplatesPage.AttachDocument_Btn).Click();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.isDialogPresent();
            _driver.WaitForElementPresentAndEnabled(UploadLoanDocumentPage.Title_Ddn, 60);
            _driver.FindElement(UploadLoanDocumentPage.Title_Ddn).SendKeys(title + Keys.Enter);
            _driver.isDialogPresent();
            _driver.FindElement(UploadLoanDocumentPage.Comments_Txt).EnterText(commentInTextbox);
            _driver.SwitchTo().Frame(_driver.FindElement(UploadLoanDocumentPage.Browse_Iframe));
             _driver.FindElement(UploadLoanDocumentPage.Browse_Btn).UploadDocument(filePath);
            Thread.Sleep(5000);
            _driver.WaitForPageLoad();
            _driver.SwitchTo().DefaultContent();
            _driver.WaitForElementPresentAndEnabled(UploadLoanDocumentPage.Save_Btn, 60);
            _driver.FindElement(UploadLoanDocumentPage.Save_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Document Attached " + _driver.Title);
        }


        [When(@"User Click on Display Link of the uploaded document")]
        public void ClickOnDisplay()
        {
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.Display_Lnk, 60);
            _driver.FindElement(VELetterTemplatesPage.Display_Lnk).Click();
            test.Log(Status.Info, "Display link clicked " + _driver.Title);
        }


        [Then(@"Print button Should be displayed in the Print Preview Window")]
        public void VerifyPrintButton()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.SwitchTo().Frame(PrintPreviewPage.Frame);
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.Print_Btn, 60);
            _driver.FindElement(PrintPreviewPage.Print_Btn).AssertElementPresent();
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.Close_Btn, 60);
            _driver.FindElement(PrintPreviewPage.Close_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            test.Log(Status.Info, "Print button is displayed in the prient preview window " + _driver.Title);
        }

        [Then(@"The same PDF document should be displayed in the scanned /Uploaded documents")]
        public void VerifyPDFDocument()
        {
            Assert.AreEqual(expectedFileName, _driver.FindElement(VELetterTemplatesPage.FileName).GetText());
            test.Log(Status.Info, "Same PDF is displayed in the scanned /uploaded documents " + _driver.Title);
        }


        [When(@"User Attached pdf document of more than 4mb")]
        public void AttachPdfDocument()
        {
            _driver.FindElement(VELetterTemplatesPage.AttachDocument_Btn).Click();
            _driver.WaitForPageLoad();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.isDialogPresent();
            _driver.SwitchTo().Frame(_driver.FindElement(UploadLoanDocumentPage.Browse_Iframe));
            _driver.FindElement(UploadLoanDocumentPage.Browse_Btn).UploadDocument(filePath5MB);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "PDF attahced of more than 4mb " + _driver.Title);
        }


        [Then(@"Pop Up should be displayed as the file you are transferring is too big")]
        public void VerifyPopUp()
        {
            _driver.VerifyAlertText("The file you are transferring is too big");
            _driver.WaitForPageLoad();
            _driver.SwitchTo().DefaultContent();
            _driver.WaitForElementPresentAndEnabled(UploadLoanDocumentPage.Close_Button, 60);
            _driver.FindElement(UploadLoanDocumentPage.Close_Button).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            test.Log(Status.Info, "Pop is displayed as the file you are transferring is too big " + _driver.Title);
        }


        [When(@"Click on show consumer link of the uploaded document  coming in the scanned/uploaded document")]
        public void ShowConsumer()
        {
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.ShowConsumer_Lnk, 60);
            _driver.FindElement(VELetterTemplatesPage.ShowConsumer_Lnk).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Show consumer link clicked " + _driver.Title);
        }


        [Then(@"YES should be displayed In the consumer column of the uploaded document present in the Scanned / uploaded Documents section")]
        public void VerifyConsumerVisibility()
        {
            String consumer_visibility = _driver.FindElement(VELetterTemplatesPage.ConsumerVisibility).GetText();
            Assert.IsTrue(consumer_visibility.StartsWith("YES"));
            test.Log(Status.Info, "Yes is displayed " + _driver.Title);
        }


        [When(@"Copy the generated URL")]
        public void CopyGeneratedURL()
        {
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.RemoteDocUpload_Btn, 60);
            _driver.FindElement(VELetterTemplatesPage.RemoteDocUpload_Btn).Click();
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.WaitForElementPresentAndEnabled(DocumentUploadLinkPage.GenerateLink_Lnk, 60);
            _driver.FindElement(DocumentUploadLinkPage.GenerateLink_Lnk).Click();
            _driver.WaitForElementPresentAndEnabled(DocumentUploadLinkPage.URL, 60);
            generatedURL = _driver.FindElement(DocumentUploadLinkPage.URL).GetText();
            _driver.Close();
            WindowHelper.switchToMainWindow(_driver, main_window);
            test.Log(Status.Info, "Generated URL copied " + _driver.Title);
        }


        [When(@"Open the generated URL")]
        public void OpenURL()
        {
            _driver2 = new InternetExplorerDriver();
            _driver2.Navigate().GoToUrl(generatedURL);
            _driver2.WaitForPageLoad();
            test.Log(Status.Info, "Generated URL opened " + _driver.Title);
        }


        [When(@"Upload the PDF document less than 3.91 mb")]
        public void UploadPDFDocument()
        {
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Lnk, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Lnk).Click();
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
            _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
            _driver2.WaitForPageLoad();
            _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePath);
            _driver2.WaitForPageLoad();
          Thread.Sleep(5000);
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Btn, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Btn).Click();
            _driver2.Close();
            _driver.RefreshPage();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "PDF document uploaded of less than 3.91mb " + _driver.Title);
        }


        [When(@"Upload the PDF document of more than 3.91 mb")]
        public void UploadThePDFDocument()
        {
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Lnk, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Lnk).Click();
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
            _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
            _driver2.WaitForPageLoad();
            _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePath5MB);
            _driver2.WaitForPageLoad();
            test.Log(Status.Info, "PDF document uploaded of more than 3.91mb " + _driver.Title);
        }


        [Then(@"The file you are transferring is too big Max file size is 3.91MB Message should be there")]
        public void UploadStatusDisplay()
        {
            _driver2.FindElement(FileSharePage.UploadStatusDisplay_Lbl).AssertTagText(expectedUploadStatusDisplay);
            _driver2.Close();
            test.Log(Status.Info, "Message is displayed as the file you are transferring is too big Max file size is 3.91MB " + _driver.Title);
        }


        [When(@"Upload the JPG document")]
        public void UploadJPGDocument()
        {
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Lnk, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Lnk).Click();
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
            _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
            _driver2.WaitForPageLoad();
            _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePathJPG);
            _driver2.WaitForPageLoad();
            test.Log(Status.Info, "JPG document uploaded " + _driver.Title);
        }


        [Then(@"File type of JPG not allowed Message should be there")]
        public void VerifyJPGNotAllowed()
        {
            _driver2.FindElement(FileSharePage.UploadStatusDisplay_Lbl).AssertTagText(expectedUploadStatusDisplayJPG);
            _driver2.Close();
            test.Log(Status.Info, "Message is displayed as File type of JPG not allowed " + _driver.Title);
        }


        [When(@"Upload five PDF documents")]
        public void UploadFivePDFDocuments()
        {
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Lnk, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Lnk).Click();
            for (int i = 0; i < 4; i++)
            {
                _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
                _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
                _driver2.WaitForPageLoad();
                _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePath);
                _driver2.WaitForPageLoad();
                Thread.Sleep(5000);
                _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Btn, 60);
                _driver2.FindElement(FileSharePage.SendDocument_Btn).Click();
                _driver2.WaitForElementPresentAndEnabled(FileSharePage.UploadDocument_Btn, 60);
                _driver2.FindElement(FileSharePage.UploadDocument_Btn).Click();
                _driver2.WaitForPageLoad();
            }
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
            _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
            _driver2.WaitForPageLoad();
            _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePath);
            _driver2.WaitForPageLoad();
            Thread.Sleep(5000);
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Btn, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Btn).Click();
            _driver2.WaitForPageLoad();
            test.Log(Status.Info, "Uploaded five pdf document " + _driver.Title);
        }


        [When(@"Close the file share page")]
        public void CloseFileSharePage()
        {
            _driver2.Close();
            test.Log(Status.Info, "File share window closed " + _driver.Title);
        }


        [When(@"Refresh the Letter docs page")]
        public void RefreshLetterDocsPage()
        {
            _driver.RefreshPage();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Letter docs page refreshed " + _driver.Title);
        }


        [Then(@"All the five PDF document should be displayed in the scanned /Uploaded documents")]
        public void VerifyFivePDFDocument()
        {
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.UploadDocuments_TableItems_Arrow, 60);
            _driver.FindElement(VELetterTemplatesPage.UploadDocuments_TableItems_Arrow).Click();
            IList<IWebElement> UploadDocumentsRows_list = _driver.FindElements(VELetterTemplatesPage.UploadDocuments_Rows);
            for (int i = 2; i <= UploadDocumentsRows_list.Count; i++)
            {
                actualFileName = _driver.FindElement(By.XPath(".//table[@id='LDocs_dg']/tbody/tr[" + i + "]/td[3]")).GetText();
                Assert.AreEqual(expectedFileName, actualFileName);
            }
            test.Log(Status.Info, "All the five PDF document are displayed " + _driver.Title);
        }


        [When(@"Upload the PNG Document")]
        public void UploadPNGDocument()
        {
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.SendDocument_Lnk, 60);
            _driver2.FindElement(FileSharePage.SendDocument_Lnk).Click();
            _driver2.WaitForElementPresentAndEnabled(FileSharePage.DocumentType_Ddn, 60);
            _driver2.FindElement(FileSharePage.DocumentType_Ddn).SelectDropDown(documentType);
            _driver2.WaitForPageLoad();
            Console.WriteLine("filePathPNG : "+ filePathPNG);
            _driver2.FindElement(FileSharePage.BrowseFile_Btn).UploadDocument(filePathPNG);
            _driver2.WaitForPageLoad();
            test.Log(Status.Info, "PNG document uploaded " + _driver.Title);
        }


        [Then(@"File type of PNG not allowed Message should be there should be there")]
        public void VerifyPNGNotAllowed()
        {
            _driver2.FindElement(FileSharePage.UploadStatusDisplay_Lbl).AssertTagText(expectedUploadStatusDisplayPNG);
            _driver2.Close();
            test.Log(Status.Info, "Message is displayed as File type of PNG not allowed " + _driver.Title);
        }


        [Then(@"Upload Document button should not be there after uploading five PDFs document")]
        public void VerifyUploadDocumentButton()
        {
            IList<IWebElement> list = _driver2.FindElements(FileSharePage.UploadDocument_Btn);
            if (list.Count > 0)
            {
                Assert.Fail();
            }
            _driver2.Close();
            test.Log(Status.Info, "Upload document button is not present " + _driver.Title);
        }


        [When(@"User navigates to letter docs templates")]
        public void NavigatesToLetterDocsTemplates()
        {
            _driver.WaitForElementPresentAndEnabled(HomePage.Setup_Focus, 60);
            _driver.HoverAndClick(_driver.FindElement(HomePage.Setup_Focus), _driver.FindElement(HomePage.ConfigureSite_Focus));
            _driver.WaitForElementPresentAndEnabled(ConfigureSitePage.ModuleConfiguration_lnk, 60);
            _driver.FindElement(ConfigureSitePage.ModuleConfiguration_lnk).Click();
            _driver.WaitForElementPresentAndEnabled(ModuleConfigurationPage.Letter_Docs_Templates_lnk, 60);
            IWebElement Letter_Docs_Templates_lnk = _driver.FindElement(ModuleConfigurationPage.Letter_Docs_Templates_lnk);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", Letter_Docs_Templates_lnk);
            Letter_Docs_Templates_lnk.Click();
            _driver.WaitForElementPresentAndEnabled(LetterAndTemplatesPage.Documents_Tab, 60);
            _driver.FindElement(LetterAndTemplatesPage.Documents_Tab).Click();
            test.Log(Status.Info, "Navigated to letter docs templates " + _driver.Title);
        }


        [When(@"User Creates a new Vehicle APP")]
        public void CreateVehicleAPP()
        {
            _driver.WaitForElementPresentAndEnabled(LoanPage.LoanAppNumber, 60);
            _driver.FindElement(LoanPage.LoanAppNumber).GetText();
            _driver.WaitForElementPresentAndEnabled(LoanPage.Amount_Requested_Txt, 60);
            _driver.FindElement(LoanPage.Amount_Requested_Txt).EnterText(amountRequested);
            _driver.FindElement(LoanPage.Loan_Term_Txt).EnterText(loanTerm);
            _driver.FindElement(LoanPage.Purpose_Type_Ddn).SelectDropDown(purposeTypeText);
            _driver.WaitForPageLoad();
            _driver.WaitForElementPresentAndEnabled(LoanPage.SSN_Txt, 60);
            _driver.FindElement(LoanPage.SSN_Txt).EnterText(validSsn);
            _driver.FindElement(LoanPage.FName_Txt).Click();
            _driver.WaitForPageLoad();
            _driver.FindElement(LoanPage.FName_Txt).GetAttributeValue("value");
            _driver.FindElement(LoanPage.LName_TextField).GetAttributeValue("value");
            _driver.FindElement(LoanPage.MemberNumber_TextField).GetAttributeValue("value");
            _driver.WaitForElementPresentAndEnabled(LoanPage.Custom_Question_CheckBox, 60);
            _driver.FindElement(LoanPage.Custom_Question_CheckBox).Click();
            _driver.WaitForPageLoad();
            _driver.WaitForElementPresentAndEnabled(LoanPage.Custom_Question_Ddn_First, 60);
            _driver.FindElement(LoanPage.Custom_Question_Ddn_First).SelectDropDown(customQuestionText);
            _driver.FindElement(LoanPage.Custom_Question_Ddn_Second).SelectDropDown(customQuestionText);
            _driver.FindElement(LoanPage.Pull_Credit_Btn).Click();
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Vehicle APP created " + _driver.Title);
        }


        [When(@"User Add PDF in the vehicle module")]
        public void AddPDF()
        {
            if (filesAdded.Equals(filesAddedStatus))
            {

                for (int i = 1; i <= 2; i++)
                {
                    _driver.WaitForElementPresentAndEnabled(LetterAndTemplatesPage.AddNew_Btn, 60);
                    _driver.FindElement(LetterAndTemplatesPage.AddNew_Btn).Click();
                    main_window = WindowHelper.switchToChildWindow(_driver);
                    _driver.WaitForElementPresentAndEnabled(AddPdfPage.PdfTitle_Txt, 60);
                    _driver.FindElement(AddPdfPage.PdfTitle_Txt).EnterText(fileName + i);
                    _driver.SwitchTo().Frame(_driver.FindElement(AddPdfPage.FileUploader_IFrame));
                    _driver.WaitForPageLoad();
                    Thread.Sleep(5000);
                    _driver.FindElement(AddPdfPage.Browse_Btn).UploadDocument(filePath);
                    _driver.WaitForPageLoad();
                    Thread.Sleep(5000);
                    _driver.SwitchTo().DefaultContent();
                    _driver.WaitForElementPresentAndEnabled(AddPdfPage.AppType_VL_Chckbx, 60);
                    _driver.FindElement(AddPdfPage.AppType_VL_Chckbx).Click();
                    IWebElement Save_Btn = _driver.FindElement(AddPdfPage.Save_Btn);
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", Save_Btn);
                    Save_Btn.Click();
                    if (_driver.isAlertPresent())
                    {
                        _driver.isDialogPresent();

                        IWebElement Close_Btn = _driver.FindElement(AddPdfPage.Close_Btn);
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", Close_Btn);
                        Close_Btn.Click();
                    }
                    WindowHelper.switchToMainWindow(_driver, main_window);
                    _driver.WaitForPageLoad();
                }
                filesAdded = "exist";
            }
            test.Log(Status.Info, "PDFs added in the vechicle module " + _driver.Title);
        }


        [When(@"User check the multiple pdf and click on display")]
        public void CheckPDF()
        {
            _driver.WaitForElementPresentAndEnabled(LoanPage.LetterDocs_Lnk, 60);
            _driver.FindElement(LoanPage.LetterDocs_Lnk).Click();
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.PdfMaster_Chckbx, 60);
            _driver.FindElement(VELetterTemplatesPage.PdfMaster_Chckbx).Click();
            _driver.WaitForElementPresentAndEnabled(VELetterTemplatesPage.DisplaySelected_Btn, 60);
            _driver.FindElement(VELetterTemplatesPage.DisplaySelected_Btn).Click();
            test.Log(Status.Info, "Muliple pdfs checked and display button clicked " + _driver.Title);
        }


        [Then(@"Checked PDFs should be displayed")]
        public void VerifyPDFsDisplayed()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.SwitchTo().Frame("body");
            _driver.SwitchTo().Frame("iframe");
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.AllDocuments_Ddn, 60);
            _driver.FindElement(PrintPreviewPage.AllDocuments_Ddn).Click();
            StringBuilder allDocuments = new StringBuilder();
            IList<IWebElement> allDocumentsList = _driver.FindElements(PrintPreviewPage.AllDocuments_Ddn_Options);
            for (int i = 1; i < allDocumentsList.Count; i++)
            {
                allDocuments.Append(allDocumentsList[i].GetText());
            }
            Assert.IsTrue(allDocuments.ToString().Equals(clientpdfsExpected));
            _driver.SwitchTo().DefaultContent();
            _driver.SwitchTo().Frame(PrintPreviewPage.Frame);
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.Close_Btn, 60);
            _driver.FindElement(PrintPreviewPage.Close_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            test.Log(Status.Info, "Multiple PDFs are displayed " + _driver.Title);
        }


        [Then(@"PDFs should be available in Incomplete PDF")]
        public void IncompletePDF()
        {
            main_window = WindowHelper.switchToChildWindow(_driver);
            _driver.SwitchTo().Frame(PrintPreviewPage.Frame);
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.SaveAsIncomplete_Btn, 60);
            _driver.FindElement(PrintPreviewPage.SaveAsIncomplete_Btn).Click();
            _driver.WaitForElementPresentAndEnabled(PrintPreviewPage.Close_Btn, 60);
            _driver.FindElement(PrintPreviewPage.Close_Btn).Click();
            WindowHelper.switchToMainWindow(_driver, main_window);
            _driver.WaitForPageLoad();
            StringBuilder IncompletePDFs = new StringBuilder();
            IList<IWebElement> IncompletePDFsList = _driver.FindElements(VELetterTemplatesPage.IncompletePDFs);
            for (int i = 0; i < IncompletePDFsList.Count; i++)
            {
                IncompletePDFs.Append(IncompletePDFsList[i].GetText());
            }
            Assert.IsTrue(IncompletePDFs.ToString().Equals(clientpdfsExpected));
            test.Log(Status.Info, "PDF available as incomplete " + _driver.Title);
        }


        [When(@"User Opens the PDF document in NG Mapper")]
        public void NGMapper()
        {
            _driver.FindElement(LetterAndTemplatesPage.Mapping_Lnk).Click();
            _driver.WaitForPageLoad();
            main_window = WindowHelper.switchToChildWindow(_driver);
            test.Log(Status.Info, "PDF document opened in NG Mapper " + _driver.Title);
        }


        [Then(@"PDF document should be opened in PDF Mapper")]
        public void PDFMapper()
        {
            _driver.FindElement(PDFMapperPage.PageTitle).AssertElementPresent();
            _driver.WaitForElementPresentAndEnabled(PDFMapperPage.Close_Btn, 60);
            _driver.FindElement(PDFMapperPage.Close_Btn).Click();
            _driver.isDialogPresent();
            WindowHelper.switchToMainWindow(_driver, main_window);
            test.Log(Status.Info, "PDF document opened in PDF Mapper  " + _driver.Title);
        }
    }
}
