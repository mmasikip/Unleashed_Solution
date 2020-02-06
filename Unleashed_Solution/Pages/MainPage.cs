using OpenQA.Selenium;
using System.Collections.Generic;
using Unleashed_Solution.DataModel;

namespace Unleashed_Solution.Pages
{
    public class MainPage
    {
        private ContextObject _context;

        public MainPage(ContextObject context)
        {
            _context = context;
        }

        #region WEB ELEMENTS
        private readonly By edtEmail = By.CssSelector("#username");
        #endregion

        public void NavigateLeftMenu(List<string> listNavigation)
        {

        }

        public bool IsMenuExpanded(string menu)
        {
            By menuItem = By.XPath("//");

            return true;
        }
    }
}