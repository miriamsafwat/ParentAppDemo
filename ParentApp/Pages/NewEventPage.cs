using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ParentApp.Utilities;
using System.Threading;
using System;

namespace ParentApp.Pages
{
    public class NewEventPage : Page
    {
        #region Properties

        [FindsBy(How = How.Id, Using = "_title")]
        private IWebElement txtTitle { get; set; }

        [FindsBy(How = How.Id, Using = "_date")]
        private IWebElement txtDate { get; set; } // 12/Nov/2018

        [FindsBy(How = How.XPath, Using = "//span[@title='Next Month']")]
        private IWebElement btnNextMonth { get; set; }

        //[FindsBy(How = How.XPath, Using = "//td[contains(.,'15')]")]
        //private IWebElement btnDay { get; set; } // 12/Nov/2018
        // driver.FindElement(By.XPath("//td[@data-day='11/30/2017']"));
        [FindsBy(How = How.XPath, Using = "//td[@data-day='11/30/2017']")]
        private IWebElement btnDay { get; set; } // 12/Nov/2018

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Start Time')]")]
        private IWebElement ddlStartTime { get; set; }

        // driver.FindElement(By.XPath("//a[contains(.,'  12:00 am')]"));
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'12:00 am')]")]
        private IWebElement itemStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'End Time')]")]
        private IWebElement ddlEndTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='_select_endtime']/ul/li/a[contains(.,'12:15 am')]/label[text()='12:15 am']")]
        private IWebElement itemEndTime { get; set; }

        [FindsBy(How = How.Id, Using = "_reply_date")]
        private IWebElement replyDate { get; set; }

        [FindsBy(How = How.Id, Using = "_recipients")]
        private IWebElement txtRecipients { get; set; }

        // text-suggestion text-selected
        [FindsBy(How = How.ClassName, Using = "text-list")]
        private IWebElement txtSuggestion { get; set; }

        [FindsBy(How = How.Id, Using = "_send")]
        private IWebElement btnCreate { get; set; }

        [FindsBy(How = How.ClassName, Using = "intercom-avatar")]
        private IWebElement btnChat { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'my event')]")]
        private IWebElement createdEvent { get; set; }

        #endregion Properties

        public void FillEvent()
        {
            Thread.Sleep(7000);

            // iframe
            DriverContext.Driver.SwitchTo().Frame("intercom-launcher-discovery-frame");
            btnChat.Click();
            Thread.Sleep(2000);
            btnChat.Click();

            DriverContext.Driver.SwitchTo().ParentFrame();

            txtTitle.SetText("My Event");

            Thread.Sleep(2000);
            txtDate.Click();

            Thread.Sleep(2000);
            ddlStartTime.Click();
            Thread.Sleep(2000);
            itemStartTime.Click();
            //ddlStartTime.SelectByText("12:00 am");
            Thread.Sleep(2000);
            ddlEndTime.Click();
            Thread.Sleep(2000);
            itemEndTime.ClickOnElement_WithJavascript();
            Thread.Sleep(2000);
            replyDate.Click();

            txtRecipients.SetText("Mobile teacher");
            Thread.Sleep(2000);
            txtSuggestion.Click();
        }

        public void CreateEvent()
        {
            btnCreate.Click();
        }

        public bool IsEventExists()
        {
            WaitUntil.ElementNotExist(By.ClassName("sk-circle12 sk-child"));
            Thread.Sleep(2000);
            WaitUntil.ElementExists(By.ClassName("oc-border-separate"));
            return createdEvent.Displayed;
        }
    }
}