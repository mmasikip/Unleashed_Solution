using OpenQA.Selenium.Chrome;
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
        }

        [AfterScenario]
        public void Cleanup()
        {
            _context.Driver.Quit();
        }
    }
}