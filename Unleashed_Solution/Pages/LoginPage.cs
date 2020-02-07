using OpenQA.Selenium;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Pages
{
    public class LoginPage
    {
        private ContextObject _context;

        public LoginPage(ContextObject context)
        {
            _context = context;
        }

        #region WEB ELEMENTS
        private readonly By edtEmail = By.CssSelector("#username");
        private readonly By edtPassword = By.CssSelector("#password");
        private readonly By btnLogin = By.CssSelector("#btnLogOn");
        #endregion

        public bool Login(string email, string password)
        {
            _context.Driver.FindElement(edtEmail).SendKeys(email);
            _context.Driver.FindElement(edtPassword).SendKeys(password);
            _context.Driver.FindElement(btnLogin).Click();
            return _context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Dashboard"));
        }
    }
}