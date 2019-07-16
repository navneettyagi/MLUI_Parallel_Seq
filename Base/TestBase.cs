using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using AventStack.ExtentReports;
using MLAutoFramework.Config;
using MLAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using MLAutoFramework.Extensions;
using TechTalk.SpecFlow;

namespace MLAutoFramework.Base
{
    public class TestBase: ExtentReportBase //UnitTestBase
    {
        
        public static IReadOnlyCollection<IWebElement> element;
        //public static string main_window;
        private static string _SnapShotFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        IEnumerable<int> _browserInstance;
        public string CurrentBrowser { get; set; }
        //Comment static IWebDriver for parallel execution
        public static IWebDriver driver { get; set; }

        //Uncomment for parallel execution
        private IWebDriver _driver { get; set; }

        //Open desired browser
        private IWebDriver zOpenBrowser(String Browser)//we dont want user to invoke browser 
        {
            switch (Browser.ToUpper())//To hadle any case mistmatch
            {
                //case BrowserType.IE:
                case "IE":
                    // http://stackoverflow.com/questions/14952348/not-able-to-launch-ie-browser-using-selenium2-webdriver-with-java
                    //Please follow above instructions above to setup IE 

                    _driver = new InternetExplorerDriver();
                    break;

                case "FIREFOX":
                    _driver = new FirefoxDriver();
                    break;

                case "CHROME":
                    _driver = new ChromeDriver();
                    break;

                case "SAFARI":
                    _driver = new SafariDriver();
                    break;

                case "EDGE":
                    _driver = new EdgeDriver();
                    break;

                case "OPERA":
                    _driver = new OperaDriver();
                    break;

                default:
                    _driver = new ChromeDriver();
                    break;
            }
            return _driver;
        }
        

        //Set up test environment, i.e., create instance of Extent report and log file
        public void TestSetUp(string TestScriptName, bool useTestData = true)
        {
            try
            {
                string testDatafileName = string.Empty;
                if (useTestData)
                {
                    StartReport();
                }
                LogHelper.CreateLogFile(TestScriptName);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }

        
        //Open browser, and create instance of extent test
        public IWebDriver StartTestExecution(String Browser, IWebDriver _driver)
        {
            try
            {
                CurrentBrowser = Browser;
                _browserInstance = GetCurrentBrowserInstances(Browser);                
                _driver = zOpenBrowser(Browser);
                MaximizeBrowser();
                DeleteAllCookies();
                _driver.WaitForPageLoad();
                return _driver;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }


        public ExtentTest CreateExtentObjectParallel(String Browser, ExtentTest test)
        {
            var testname = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testname+"_"+ Browser);
            return test;
        }       


        public ExtentTest CreateExtentObjectSequential(String Browser, ExtentTest test, String scenario)
        {
            try
            {
                var testname = scenario;
                test = extent.CreateTest(testname + "_" + Browser);
                return test;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }


        //Delete cookies, flush extent report, and kill process
        public void TestCleanUp()
        {
            try
            {
                DeleteAllCookies();
                if (_driver != null)
                {
                    //ExtentReportBase.StopReport(_driver);
                    Process[] FirefoxDriverProcesses = Process.GetProcessesByName("firefox");

                    foreach (var FirefoxDriverProcess in FirefoxDriverProcesses)
                    {
                        FirefoxDriverProcess.Kill();
                    }
                    _driver.Quit();
                    CloseBrowser(CurrentBrowser);
                }
                //_driver.Dispose();
                LogHelper.Write("Closed the Browser");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }


        //Kill process and close browser
        public void CloseBrowser(string browser)
        {
            IEnumerable<int> currentInstance;
            var currentBrowserInstances = GetCurrentBrowserInstances(browser);
            if (_browserInstance != null && _browserInstance.Any())
            {
                currentInstance = currentBrowserInstances.Except(_browserInstance);
            }
            else
            {
                currentInstance = currentBrowserInstances;
            }

            foreach (int instance in currentInstance)
            {
                Process.GetProcessById(instance).Kill();
                _driver.Dispose();
            }
        }


        //Get current browser instance
        private IEnumerable<int> GetCurrentBrowserInstances(string browser)
        {
            string processName = string.Empty;
            List<int> pIdList = null;
            switch (browser.ToUpper())
            {
                case "IE":
                    processName = "iexplore";
                    break;
                case "CHROME":
                    processName = "Chrome";
                    break;
                case "FIREFOX":
                    processName = "Firefox";
                    break;

            }
            if (!string.IsNullOrEmpty(processName))
            {
                Process[] processArray = Process.GetProcessesByName(processName);
                if (processArray != null && processArray.Length > 0)
                {
                    pIdList = new List<int>();
                    foreach (Process p in processArray)
                    {
                        pIdList.Add(p.Id);
                    }
                }
            }
            return pIdList;
        }


        //Clear IE cache
        public void ClearIECache()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            _driver = new InternetExplorerDriver(options);
        }


        //Launch URL
        public void NavigateToURL(IWebDriver _driver)
        {
            //string URL = "https://beta.loanspq.com/login.aspx?enc2=36aNbmudSLCCMdjJoYQn6iT9nG7GRjqBbkIAMYcy9aM";
            //**Me Make comment

            string AbsoluteURL = Settings.AbsoluteURL;
            string URL = Settings.AUT;
            //string MachineName = System.Environment.MachineName;
            string Environment = Settings.Environment;
            URL = "https://" + Environment + "." + URL;
            if ((!String.IsNullOrEmpty(AbsoluteURL)))
            {
                _driver.Navigate().GoToUrl(AbsoluteURL);
            }
            else
            {
                _driver.Navigate().GoToUrl(URL);
            }
            _driver.WaitForPageLoad();
            LogHelper.Write("Navigated to the URL");
        }


        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = null;
            if (Settings.ExecutingBrowser == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            browsers = Settings.ExecutingBrowser.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }
        }


        //Navigate Forward
        public void NavigateForward()
        {
            _driver.Navigate().Forward();
        }


        //Navigate Back
        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }


        //Refresh web page
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }


        //Maximize the browser
        public void MaximizeBrowser()
        {
            _driver.Manage().Window.Maximize();
        }


        //Delete all Cookies
        public void DeleteAllCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }


        //Resize browser in Apple tab size
        public void ResizeBrowserToTabSize()
        {
            //DriverContext.Driver.Manage().Window.Size = new Size(960, 640);
            ResizeBrowser(960, 640);
        }


        //Populate Excel data in Data Table
        public void PopulateExcelData(string testScripName)
        {
            if (Settings.TestDataPath == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + Settings.TestDataPath + testScripName + ".xlsx";
            string testDatafileName = new Uri(finalpth).LocalPath;
            ExcelHelper.PopulateInCollection(testDatafileName);
        }


        //Resize browser in resired size
        public void ResizeBrowser(int width, int height)
        {
            _driver.Manage().Window.Size = new System.Drawing.Size(width, height);
        }

        //Testing Extent
        /*internal class ExtentManager
        {
            private static readonly ExtentReports _instance =
                new ExtentReports("Extent.Net.html", DisplayOrder.OldestFirst);

            static ExtentManager() { }

            private ExtentManager() { }

            public static ExtentReports Instance
            {
                get
                {
                    return _instance;
                }
            }
        }*/
    }
}
