using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Unleashed_Solution.DataModel
{
    public class ContextObject
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public Product Product { get; set; }
    }
}