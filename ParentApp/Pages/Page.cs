using OpenQA.Selenium.Support.PageObjects;
using ParentApp.Utilities;

namespace ParentApp.Pages
{
    public abstract class Page
    {
        public Page()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}