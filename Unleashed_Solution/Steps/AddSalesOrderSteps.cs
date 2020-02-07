using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Pages;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class AddSalesOrderSteps
    {
        private ContextObject _context;
        private AddSalesOrderPage _addSalesOrderPage;

        public AddSalesOrderSteps(ContextObject context)
        {
            _context = context;
            _addSalesOrderPage = new AddSalesOrderPage(_context);
        }

        [When(@"I select Customer Code '(.*)' on Add Sales Order page")]
        public void WhenISelectCustomerCodeOnAddSalesOrderPage(string custCode)
        {
            _addSalesOrderPage.SelectCustomerCode(custCode);
        }

        [When(@"I add Product Code and Quantity of '(.*)'")]
        public void WhenIAddProductCodeAndQuantityOf(int quantity)
        {
            _addSalesOrderPage.AddProduct(_context.Product.ProductCode, quantity);
        }

        [When(@"I click '(.*)' on confirmation window")]
        public void WhenIClickOnConfirmationWindow(string buttonText)
        {
            _addSalesOrderPage.ClickConfirmationButton(buttonText);
        }

    }
}