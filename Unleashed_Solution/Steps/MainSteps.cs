using NUnit.Framework;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Pages;
using System.Linq;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class MainSteps
    {
        private ContextObject _context;
        private MainPage _mainPage;

        public MainSteps(ContextObject context)
        {
            _context = context;
            _mainPage = new MainPage(_context);
        }

        [When(@"I navigate using left navigation menu: (.*)")]
        public void WhenINavigateUsingLeftNavigationMenuInventoryProductsAddProduct(string navigationPath)
        {
            if (!navigationPath.Contains(">"))
                Assert.Fail("Expected value for 'navigationPath' is incorrect. Path should have '>'.");

            var listNavigation = navigationPath.Split('>').ToList();

            _mainPage.NavigateLeftMenu(listNavigation);
        }
    }
}