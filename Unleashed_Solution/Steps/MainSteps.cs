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
        [Then(@"I navigate using left navigation menu: (.*)")]
        public void WhenINavigateUsingLeftNavigationMenuInventoryProductsAddProduct(string navigationPath)
        {
            if (!navigationPath.Contains(">"))
                Assert.Fail("Expected value for 'navigationPath' is incorrect. Path should have '>'.");
            
            var listNavigation = navigationPath.Split('>').Select(p => p.Trim()).ToList();

            _mainPage.NavigateLeftMenu(listNavigation);
        }

        [When(@"I am on the '(.*)' page")]
        [Then(@"I am on the '(.*)' page")]
        public void WhenIAmOnThePage(string pageName)
        {
            Assert.AreEqual(pageName, _mainPage.GetPageTitle(), $"'{pageName}' page is not displayed.");
        }

        [When(@"I click '(.*)' button")]
        public void WhenIClickButton(string buttonName)
        {
            _mainPage.ClickButton(buttonName);
        }

        [Then(@"notification message '(.*)' is displayed")]
        public void ThenNotificationMessageIsDisplayed(string notificationMessage)
        {
            Assert.IsTrue(_mainPage.IsNotificationMessageDisplayed(notificationMessage), $"Notification message '{notificationMessage}' is not displayed.");
        }
    }
}