using SeleniumFramework.Base;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;  // For ExtentSparkReporter
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumFramework.Pages
{
    public class MatchingEnginePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions actions;
        private readonly ExtentTest test;

        public MatchingEnginePage(IWebDriver driver, WebDriverWait wait, Actions actions, ExtentTest test)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.test = test;
        }

        // Wait and expand the 'Modules' in the header section Click on 'Repertoire Management Module' from the menu
        private IWebElement modulesMenu => wait.Until(drv => drv.FindElement(By.XPath("//a[@class= 'navbar-link is-active']")));

        public void NavigateMainMenu()
        {
            driver.Navigate().GoToUrl("https://www.matchingengine.com/");
            test.Log(AventStack.ExtentReports.Status.Info, "Navigated to Matching Engine");
               
            // Perform the hover action
            actions.MoveToElement(modulesMenu).Perform();
            test.Log(AventStack.ExtentReports.Status.Info, "Expanded the 'Modules' in the header section");
        }
    }
}
