using NUnit.Framework;
using RestSharp;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class ApiSteps
    {
        private ContextObject _context;

        public ApiSteps(ContextObject context)
        {
            _context = context;
        }

        [Given(@"I have REST Client")]
        public void GivenIHaveRESTClient()
        {
            _context.restClient = new RestClient();
        }

        [Given(@"I set Base Url (.*)")]
        public void GivenISetBaseUrlSalesOrdersBfbeeaceeeeec(string endPointRequest)
        {
            _context.restClient.BaseUrl = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"] + endPointRequest);
        }

        [Given(@"I initialize my request")]
        public void GivenIInitializeMyRequest()
        {
            _context.restRequest = new RestRequest();
        }

        [Given(@"I add header '(.*)' with value '(.*)'")]
        public void GivenIAddHeaderWithValue(string header, string value)
        {
            _context.restRequest.AddHeader(header, value);
        }

        [Given(@"I set my api-auth-id header value")]
        public void GivenISetMyApi_Auth_IdHeaderValue()
        {
            _context.restRequest.AddHeader("api-auth-id", ConfigurationManager.AppSettings["ApiId"]);
        }

        [Given(@"I set my api-auth-signature header value")]
        public void GivenISetMyApi_Auth_SignatureHeaderValue()
        {
            var sig = GetSignature("", ConfigurationManager.AppSettings["ApiKey"]);
            _context.restRequest.AddHeader("api-auth-signature", sig);
        }

        [When(@"I make a GET request")]
        public void WhenIMakeAGETRequest()
        {
            _context.restRequest.Method = Method.GET;
            _context.restResponse = _context.restClient.Execute(_context.restRequest);
        }

        [Then(@"response status returns '(.*)'")]
        public void ThenResponseStatusReturns(string status)
        {
            Assert.AreEqual(status, _context.restResponse.StatusDescription, "Expected response status is not found.");
        }

        private static string GetSignature(string args, string privatekey)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] key = encoding.GetBytes(privatekey);
            var myhmacsha256 = new HMACSHA256(key);
            byte[] hashValue = myhmacsha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myhmacsha256.Clear();
            return hmac64;
        }
    }
}