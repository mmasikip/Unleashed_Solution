using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution
{
    [Binding]
    public class WebDriverSupport
    {
        private ContextObject _context;

        public WebDriverSupport(ContextObject context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void InjectDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            _context.Driver = new ChromeDriver(options);
            _context.Wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(60));
            _context.Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void Cleanup()
        {
            _context.Driver.Quit();
        }
    }
}