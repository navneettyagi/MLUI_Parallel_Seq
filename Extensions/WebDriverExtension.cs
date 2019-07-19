using OpenQA.Selenium;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MLAutoFramework.Helpers;
using MLAutoFramework.Config;

namespace MLAutoFramework.Extensions
{
    public static class WebDriverExtension
    {

        public static void WaitForPageLoad(this IWebDriver driver)
        {
            Thread.Sleep(5000);
            int waitTime = 180;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Initially bellow given if condition will check ready state of page.
            if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            {
                return;
            }

            //This loop will rotate for 'waitTime' times to check If page Is ready after every 1 second.
            //You can replace your value with 'waitTime' If you wants to Increase or decrease wait time.
            for (int i = 0; i < waitTime; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
                //To check page ready state.
                if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    break;
                }
            }
        }

        //Wait for page load
        /*public static void WaitForPageLoad(this IWebDriver driver)
        {
            Thread.Sleep(5000);
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";
            }, 120);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> Condition, int timeOuts)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return Condition(arg);
                    }

                    catch
                    {
                        return false;
                    }

                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOuts)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }*/


        //Use this wait statement for all the editboxes & tables
        public static void WaitForObjectAvaialble(this IWebDriver driver, By element)
        {
            try
            {

                IWebElement elementDefault = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                       .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }



        //Use this wait statement before clicking on any Buttons, links, Dropdowns, Checkboxes, column headers, images, icons 
        //or on any element where you need to perform click operation
        public static void WaitForElementToBeClickable(this IWebDriver driver, By element)
        {
            try
            {

                IWebElement elementDefault = new WebDriverWait(driver, TimeSpan.FromSeconds(100))
                       .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Use this wait statement if the objects are loaded with the iFrame
        public static void WaitForiFrameLoad(this IWebDriver driver)
        {
            IWebElement iFrameHost = new WebDriverWait(driver, TimeSpan.FromSeconds(100))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("iFrameHost")));
            driver.SwitchTo().DefaultContent(); // you are now outside both frames
            driver.SwitchTo().Frame(iFrameHost);
        }


        public static void WaitForiDashLoad(this IWebDriver driver)
        {
            try
            {
                IWebElement iFrameHost = new WebDriverWait(driver, TimeSpan.FromSeconds(100))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Settings.iDashXPath)));
                driver.SwitchTo().DefaultContent(); // you are now outside both frames
                driver.SwitchTo().Frame(iFrameHost);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //TODO: Remove Throw ex, every test case should have assert to check validity
                throw ex;
            }
        }


        //Use this wait statements if the page has to make ajax calls for certain objects to load.
        public static void WaitForAjaxLoad(this IWebDriver browser, bool pageHasJQuery = true)
        {
            while (true)
            {
                var ajaxIsComplete = false;

                if (pageHasJQuery)
                    ajaxIsComplete = (bool)(browser as IJavaScriptExecutor).ExecuteScript("if (!window.jQuery) { return false; } else { return jQuery.active == 0; }");
                else
                    ajaxIsComplete = (bool)(browser as IJavaScriptExecutor).ExecuteScript("return document.readyState == 'complete'");

                if (ajaxIsComplete)
                    break;

                Thread.Sleep(100);
            }
        }

        public static void WaitForElementPresentAndEnabled(this IWebDriver driver, By locator, int secondsToWait)
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, secondsToWait))
               .Until(d => d.FindElement(locator).Enabled
                   && d.FindElement(locator).Displayed
             );
        }


        //Get current URL
        public static string GetCurrentURL(this IWebDriver driver)
        {
            return driver.Url;
        }


        public enum Type
        {
            Id,
            CssSelector,
            XPath,
            ClassName,
            Name,
            LinkText,
            IWebElement
        }


        //JavaScript Executer
        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }


        public static void ExtraWait(this IWebDriver driver)
        {
            Thread.Sleep(5000);
        }
    }
}
