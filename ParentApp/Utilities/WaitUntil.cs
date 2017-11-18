using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentApp.Utilities
{
    internal class WaitUntil
    {
        internal static void PageLoads()
        {
            new WebDriverWait(DriverContext.Driver,
                TimeSpan.FromMinutes(5.0))
                        .Until(d => ((IJavaScriptExecutor)DriverContext.Driver)
                        .ExecuteScript("return document.readyState")
                        .Equals("complete"));
        }

        internal static void ElementExists(By element)
        {
            new WebDriverWait(DriverContext.Driver, TimeSpan.FromMinutes(5.0)).Until(ExpectedConditions.ElementExists(element));
        }

        internal static void ElementNotExist(By element)
        {
            new WebDriverWait(DriverContext.Driver, TimeSpan.FromMinutes(5.0)).Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }
    }
}