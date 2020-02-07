using OpenQA.Selenium;
using System.Threading;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Pages
{
    public class ViewProductsPage
    {
        private ContextObject _context;

        public ViewProductsPage(ContextObject context)
        {
            _context = context;
        }

        #region WEB ELEMENTS
        private readonly By edtProdCode = By.CssSelector("#ProductFilter");
        private readonly By elemProductRows = By.CssSelector("tr[id*=ProductList_DXDataRow]");
        private readonly By btnDialogYes = By.XPath("//*[@id='generic-confirm-dialog']//a[text()='Yes']");
        #endregion

        public bool IsProductDisplayed(string prodCode)
        {
            var isProductFound = false;
            var productRows = _context.Driver.FindElements(elemProductRows);

            foreach(var product in productRows)
            {
                if (product.Text.Contains(prodCode))
                {
                    isProductFound = true;
                    break;
                }
            }

            return isProductFound;
        }

        public void DeleteProduct(string prodCode)
        {
            var elemTooltipDelete = By.XPath($"//tr[contains(@id,'ProductList_DXDataRow')]//a[text()='{prodCode}']/ancestor::tr[contains(@id,'ProductList_DXDataRow')]//a[@class='list-action']/following-sibling::div[@class='tooltip']//*[@class='list-action-box-Content']//a[text()='Delete' and not(@id='bulkDelete')]");
            IJavaScriptExecutor js = (IJavaScriptExecutor)_context.Driver;
            js.ExecuteScript("arguments[0].click();", _context.Driver.FindElement(elemTooltipDelete));
            _context.Driver.FindElement(btnDialogYes).Click();
        }

        public void EnterProductSearchCriteria(string prodCode)
        {
            _context.Driver.FindElement(edtProdCode).SendKeys(prodCode);
            Thread.Sleep(2000); //TO EXECUTE SEARCH PROPERLY
            _context.Driver.FindElement(edtProdCode).SendKeys(Keys.Enter);
            Thread.Sleep(2000); //TO PREVENT STALE ELEMENT EXCEPTION
        }
    }
}