using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Pages
{
    public class AddSalesOrderPage
    {
        private ContextObject _context;

        public AddSalesOrderPage(ContextObject context)
        {
            _context = context;
        }

        #region WEB ELEMENTS
        private readonly By edtCustCodeSearch = By.CssSelector("#CustomerSearchCode");
        private readonly By edtSelectedCustCode = By.CssSelector("#SelectedCustomerCode");
        private readonly By edtProductAddLine = By.CssSelector("#ProductAddLine");
        private readonly By edtProductAddQuantity = By.CssSelector("#QtyAddLine");
        private readonly By btnCustSearch = By.CssSelector("#CustomerSearchButton");
        private readonly By btnAddOrderLine = By.CssSelector("#btnAddOrderLine");
        #endregion

        public void SelectCustomerCode(string custCode)
        {
            _context.Driver.FindElement(btnCustSearch).Click();

            var searchCustCodeElement = _context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(edtCustCodeSearch));
            searchCustCodeElement.SendKeys(custCode);
            searchCustCodeElement.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            var customers = _context.Driver.FindElements(By.XPath($"//a[text()='{custCode}']"));

            if (customers.Count > 0)
            {
                customers[0].Click();
                Thread.Sleep(2000); //TO AVOID STALE ELEMENT EXCEPTION
            }
            else
            {
                Assert.Fail($"Customer with Customer Code '{custCode}' was not found.");
            }
        }

        public void AddProduct(string prodCode, int quantity)
        {
            _context.Driver.FindElement(edtProductAddLine).SendKeys(prodCode);
            _context.Driver.FindElement(edtProductAddLine).SendKeys(Keys.Tab);
            Thread.Sleep(2000); //TO ALLOW FOR PRODUCT TO LOAD
            _context.Driver.FindElement(edtProductAddQuantity).SendKeys(quantity.ToString());
            _context.Driver.FindElement(btnAddOrderLine).Click();
            Thread.Sleep(2000); //TO ALLOW FOR SALES ORDER TO LOAD
        }

        public void ClickConfirmationButton(string buttonText)
        {
            var btnDialog = By.XPath($"//*[@id='generic-confirm-dialog']//a[text()='{buttonText}']");
            _context.Driver.FindElement(btnDialog).Click();
        }
    }
}