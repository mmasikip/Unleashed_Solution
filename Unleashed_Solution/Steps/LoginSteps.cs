using NUnit.Framework;
using TechTalk.SpecFlow;
using Unleashed_Solution.DataModel;
using Unleashed_Solution.Pages;

namespace Unleashed_Solution.Steps
{
    [Binding]
    public class LoginSteps
    {
        private ContextObject _context;
        private LoginPage _loginPage;

        public LoginSteps(ContextObject context)
        {
            _context = context;
            _loginPage = new LoginPage(_context);
        }

        [Given(@"I login using credentials:")]
        public void GivenILoginUsingCredentials(Table credentials)
        {
            credentials.Rows[0].TryGetValue("Email", out string email);
            credentials.Rows[0].TryGetValue("Password", out string password);

            Assert.IsTrue(_loginPage.Login(email, password), "Login was not successful.");
        }

    }
}