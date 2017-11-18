using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParentApp.Pages;
using System.Threading;
using ParentApp.Utilities;

namespace ParentApp
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            DriverContext driver = new DriverContext(DriverContext.BrowserType.Firefox);
        }

        [TestMethod]
        public void CreateNewEvent()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login();

            MainPage mainPage = new MainPage();
            mainPage.ClickOnKidsNursery();

            mainPage.ClickOnCalendar();
            mainPage.ClickOnCreateEvent();
            mainPage.ClickOnNewEvent();

            WaitUntil.PageLoads();

            NewEventPage newEventPage = new NewEventPage();
            newEventPage.FillEvent();
            newEventPage.CreateEvent();

            Assert.IsTrue(newEventPage.IsEventExists());
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            DriverContext.Driver.Close();
        }
    }
}