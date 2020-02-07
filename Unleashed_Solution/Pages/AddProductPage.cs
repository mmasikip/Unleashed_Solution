using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Utilities;

namespace Unleashed_Solution.Pages
{
    public class AddProductPage
    {
        private ContextObject _context;

        public AddProductPage(ContextObject context)
        {
            _context = context;
        }

        #region WEB ELEMENTS
        private readonly By edtProdCode = By.CssSelector("#Product_ProductCode");
        private readonly By edtProdDesc = By.CssSelector("#Product_ProductDescription");
        private readonly By edtProdBarcode = By.CssSelector("#Product_Barcode");
        private readonly By lstProdUnitMeasure = By.CssSelector("#Product_UnitOfMeasureId");
        private readonly By lstProdGroup = By.CssSelector("#Product_ProductGroupId");
        private readonly By lstProdDefaultLabelTemplate = By.CssSelector("#Product_LabelLayoutId");
        #endregion

        public void EnterProductDetails(string prodCode, string prodDesc, string prodBarcode, string prodUnitMeasure, string prodGroup, string prodDefaultLabelTemplate)
        {
            _context.Product = new Product();

            var tempProdCode = prodCode.ToLower().Equals("random") ? StringHelper.GenerateRandomString(6) : prodCode;
            _context.Driver.FindElement(edtProdCode).SendKeys(tempProdCode);
            _context.Product.ProductCode = tempProdCode;

            _context.Driver.FindElement(edtProdDesc).SendKeys(prodDesc);
            _context.Product.ProductDescription = prodDesc;

            if (!string.IsNullOrEmpty(prodBarcode))
            {
                var tempProdBarcode = prodBarcode.ToLower().Equals("random") ? StringHelper.GenerateRandomString(10) : prodBarcode;
                _context.Driver.FindElement(edtProdBarcode).SendKeys(tempProdBarcode);
                _context.Product.ProductBarcode = tempProdBarcode;
            }
            
            if (!string.IsNullOrEmpty(prodUnitMeasure))
            {
                var selectProdUnitMeasure = new SelectElement(_context.Driver.FindElement(lstProdUnitMeasure));
                selectProdUnitMeasure.SelectByText(prodUnitMeasure);
                _context.Product.ProductUnitMeasure = prodUnitMeasure;
            }

            if (!string.IsNullOrEmpty(prodGroup))
            {
                var selectProdGroup = new SelectElement(_context.Driver.FindElement(lstProdGroup));
                selectProdGroup.SelectByText(prodGroup);
                _context.Product.ProductGroup = prodGroup;
            }

            if (!string.IsNullOrEmpty(prodDefaultLabelTemplate))
            {
                var selectProdDefaultLabelTemplate = new SelectElement(_context.Driver.FindElement(lstProdDefaultLabelTemplate));
                selectProdDefaultLabelTemplate.SelectByText(prodDefaultLabelTemplate);
                _context.Product.ProductDefaultLabelTemplate = prodDefaultLabelTemplate;
            }
        }
    }
}