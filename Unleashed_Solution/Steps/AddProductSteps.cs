using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Pages;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class AddProductSteps
    {
        private ContextObject _context;
        private AddProductPage _addProductPage;

        public AddProductSteps(ContextObject context)
        {
            _context = context;
            _addProductPage = new AddProductPage(_context);
        }

        [When(@"I enter Product Details:")]
        public void WhenIEnterProductDetails(Table productDetails)
        {
            productDetails.Rows[0].TryGetValue("Product Code", out string prodCode);
            productDetails.Rows[0].TryGetValue("Product Description", out string prodDesc);
            productDetails.Rows[0].TryGetValue("Barcode", out string prodBarcode);
            productDetails.Rows[0].TryGetValue("Unit Of Measure", out string prodUnitMeasure);
            productDetails.Rows[0].TryGetValue("Product Group", out string prodGroup);
            productDetails.Rows[0].TryGetValue("Default Label Template", out string prodDefaultLabelTemplate);

            _addProductPage.EnterProductDetails(prodCode, prodDesc, prodBarcode, prodUnitMeasure, prodGroup, prodDefaultLabelTemplate);
        }

    }
}