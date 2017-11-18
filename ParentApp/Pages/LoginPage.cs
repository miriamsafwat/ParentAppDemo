using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ParentApp.Utilities;

namespace ParentApp.Pages
{
    public class LoginPage : Page
    {
        #region Properties

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "_submit")]
        private IWebElement btnLogin { get; set; }

        #endregion Properties

        public void Login()
        {
            DriverContext.Driver.Navigate().GoToUrl("https://staging.parent.eu/login");

            txtUsername.SetText("demo@parent.eu");
            txtPassword.SetText("123456");

            btnLogin.Click();
        }
    }
}