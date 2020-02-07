using NUnit.Framework;
using System;
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

        [Then(@"I search for the noted Product Code")]
        public void ThenISearchForTheNotedProductCode()
        {
            _viewProductsPage.EnterProductSearchCriteria(_context.Product.ProductCode);
        }

        [Then(@"I validate Qty On Hand is reduced by '(.*)'")]
        public void ThenIValidateQtyOnHandIsReducedBy(int quantity)
        {
            var expectedQtyOnHand = _context.Product.ProductQuantityOnHand - Convert.ToDouble(quantity);
            var actualQtyOnHand = _viewProductsPage.GetFirstProductQtyOnHand();
            Assert.AreEqual(expectedQtyOnHand, actualQtyOnHand, "Qty On Hand value is incorrect.");
        }

        [Then(@"I delete the newly created product")]
        public void ThenIDeleteTheNewlyCreatedProduct()
        {
            _viewProductsPage.DeleteProduct(_context.Product.ProductCode);
        }

        [When(@"I noted the first product's Product Code and Qty On Hand")]
        public void WhenINotedTheFirstProductSProductCodeAndQtyOnHand()
        {
            _context.Product = new Product();
            _context.Product.ProductCode = _viewProductsPage.GetFirstProductCode();
            _context.Product.ProductQuantityOnHand = _viewProductsPage.GetFirstProductQtyOnHand();
        }

    }
}