using OpenQA.Selenium;
using System;
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
        private readonly By elemColumnHeaderRow = By.CssSelector("tr[id*='ProductList_DXHeadersRow']");
        private readonly By elemProductRows = By.CssSelector("tr[id*=ProductList_DXDataRow]");
        private readonly By btnDialogYes = By.XPath("//*[@id='generic-confirm-dialog']//a[text()='Yes']");
        #endregion

        public string GetFirstProductCode()
        {
            var productRows = _context.Driver.FindElements(elemProductRows);

            if (productRows.Count.Equals(0))
            {
                Thread.Sleep(2000); //WAIT FOR PRODUCTS TO BE DISPLAYED
                productRows = _context.Driver.FindElements(elemProductRows);
            }

            return productRows[0].FindElements(By.CssSelector("td"))[GetColumnHeaderIndex("Product Code")].Text;
        }

        public double GetFirstProductQtyOnHand()
        {
            var productRows = _context.Driver.FindElements(elemProductRows);

            if (productRows.Count.Equals(0))
            {
                Thread.Sleep(2000); //WAIT FOR PRODUCTS TO BE DISPLAYED
                productRows = _context.Driver.FindElements(elemProductRows);
            }

            return Convert.ToDouble(productRows[0].FindElements(By.CssSelector("td"))[GetColumnHeaderIndex("Qty On Hand")].Text);
        }

        private int GetColumnHeaderIndex(string columnName)
        {
            var returnIndex = 0;
            var columns = _context.Driver.FindElement(elemColumnHeaderRow).FindElements(By.XPath("./td"));

            for (var i = 0; i < columns.Count; i++)
            {
                if (columns[i].Text.ToLower().Contains(columnName.ToLower()))
                {
                    returnIndex = i;
                    break;
                }
            }

            return returnIndex;
        }

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