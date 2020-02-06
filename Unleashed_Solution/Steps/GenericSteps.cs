using System.Configuration;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class GenericSteps
    {
        private ContextObject _context;

        public GenericSteps(ContextObject context)
        {
            _context = context;
        }

        [Given(@"I launch the Online Inventory Software site")]
        public void GivenILaunchTheOnlineInventorySoftwareSite()
        {
            _context.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["AppUrl"]);
        }

    }
}