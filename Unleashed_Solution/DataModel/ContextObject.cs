using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;

namespace Unleashed_Solution.DataModel
{
    public class ContextObject
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public Product Product { get; set; }
        public IRestClient restClient { get; set; }
        public IRestRequest restRequest { get; set; }
        public IRestResponse restResponse { get; set; }
    }
}