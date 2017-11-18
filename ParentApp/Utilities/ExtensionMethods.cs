using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ParentApp.Utilities
{
    public static class ExtensionMethods
    {
        public static void SetText(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void SelectByText(this IWebElement element, string text)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
        }

        public static void SelectByValue(this IWebElement element, string value)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(value);
        }

        public static void ClickOnElement_WithJavascript(this IWebElement element)
        {
            IJavaScriptExecutor js = DriverContext.Driver as IJavaScriptExecutor;
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(180));
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (element != null && js != null && element.Displayed && element.Enabled)
                    {
                        js.ExecuteScript("arguments[0].click();", element);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (System.InvalidOperationException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
    }
}