using NUnit.Framework;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Pages;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class ViewProductsSteps
    {
        private ContextObject _context;
        private ViewProductsPage _viewProductsPage;

        public ViewProductsSteps(ContextObject context)
        {
            _context = context;
            _viewProductsPage = new ViewProductsPage(_context);
        }

        [Then(@"newly created product can be searched")]
        public void ThenNewlyCreatedProductCanBeSearched()
        {
            _viewProductsPage.EnterProductSearchCriteria(_context.Product.ProductCode);
            Assert.IsTrue(_viewProductsPage.IsProductDisplayed(_context.Product.ProductCode), $"Product '{_context.Product.ProductCode}' was not found.");
        }

        [Then(@"I delete the newly created product")]
        public void ThenIDeleteTheNewlyCreatedProduct()
        {
            _viewProductsPage.DeleteProduct(_context.Product.ProductCode);
        }

    }
}