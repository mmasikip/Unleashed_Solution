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
        private readonly By elemNotificationMessage = By.CssSelector(".ui-pnotify-text");
        #endregion

        public bool IsNotificationMessageDisplayed(string notificationMessage)
        {
            if (_context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elemNotificationMessage)).Displayed)
            {
                return _context.Driver.FindElement(elemNotificationMessage).Text.Equals(notificationMessage);
            }
            else
            {
                return false;
            }
        }

        public string GetPageTitle()
        {
            return _context.Driver.Title;
        }

        public void NavigateLeftMenu(List<string> listNavigation)
        {
            var txtLevelOneMenuItem = listNavigation[0];
            var txtLevelTwoMenuItem = listNavigation[1];
            var txtLevelThreeMenuItem = listNavigation[2];

            if (!IsLevelOneMenuExpanded(txtLevelOneMenuItem))
                ClickLevelOneMenu(txtLevelOneMenuItem);

            if (!IsLevelTwoMenuExpanded(txtLevelTwoMenuItem))
                ClickLevelTwoMenu(txtLevelTwoMenuItem);
            
            ClickLevelThreeMenu(txtLevelThreeMenuItem);
        }

        public void ClickButton(string buttonName)
        {
            var btnElement = By.XPath($"//a[contains(@class,'fm-button') and text()='{buttonName}']");
            _context.Driver.FindElement(btnElement).Click();
        }

        private bool IsLevelOneMenuExpanded(string menu)
        {
            var menuItem = By.XPath($"//ul[contains(@class,'level-1-side-menu')]/li/a/span[text()='{menu}']/following-sibling::span/i");
            return _context.Driver.FindElement(menuItem).GetAttribute("class").ToLower().Contains("expanded");
        }

        private void ClickLevelOneMenu(string menu)
        {
            var menuItem = By.XPath($"//ul[contains(@class,'level-1-side-menu')]/li/a/span[text()='{menu}']/parent::a");
            _context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(menuItem));
            _context.Driver.FindElement(menuItem).Click();
        }

        private bool IsLevelTwoMenuExpanded(string menu)
        {
            var menuItem = By.XPath($"//ul[contains(@class,'level-2-side-menu')]/li/a/span[text()='{menu}']/following-sibling::span/i");
            return _context.Driver.FindElement(menuItem).GetAttribute("class").ToLower().Contains("expanded");
        }

        private void ClickLevelTwoMenu(string menu)
        {
            var menuItem = By.XPath($"//ul[contains(@class,'level-2-side-menu')]/li/a/span[text()='{menu}']/parent::a");
            _context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(menuItem));
            _context.Driver.FindElement(menuItem).Click();
        }
        
        private void ClickLevelThreeMenu(string menu)
        {
            var menuItem = By.XPath($"//ul[contains(@class,'level-3-side-menu')]/li/a/span[text()='{menu}']/parent::a");
            _context.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(menuItem));
            _context.Driver.FindElement(menuItem).Click();
        }
    }
}