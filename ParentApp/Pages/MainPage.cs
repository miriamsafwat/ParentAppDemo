using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ParentApp.Utilities;
using System.Threading;

namespace ParentApp.Pages
{
    public class MainPage : Page
    {
        #region Properties

        [FindsBy(How = How.XPath, Using = "//h4[contains(.,'Kids Nursery Live')]")]
        private IWebElement lnkKidsNursery { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Calendar')]")]
        private IWebElement lnkCalendar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create Event')]")]
        private IWebElement lnkCreateEvent { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'New event')]")]
        private IWebElement lnkNewEvent { get; set; }

        [FindsBy(How = How.ClassName, Using = "intercom-avatar")]
        private IWebElement btnChat { get; set; }

        #endregion Properties

        public void ClickOnKidsNursery()
        {
            lnkKidsNursery.Click();
        }

        public void ClickOnCalendar()
        {
            lnkCalendar.Click();
        }

        public void ClickOnCreateEvent()
        {
            WaitUntil.ElementExists(By.ClassName("intercom-launcher-discovery-frame"));
            DriverContext.Driver.SwitchTo().Frame("intercom-launcher-discovery-frame");
            btnChat.Click();
            Thread.Sleep(2000);
            btnChat.Click();

            DriverContext.Driver.SwitchTo().ParentFrame();

            WaitUntil.ElementExists(By.XPath("//a[contains(.,'Create Event')]"));
            lnkCreateEvent.Click();
        }

        public void ClickOnNewEvent()
        {
            WaitUntil.ElementExists(By.XPath("//span[contains(.,'New event')]"));
            lnkNewEvent.Click();
        }
    }
}