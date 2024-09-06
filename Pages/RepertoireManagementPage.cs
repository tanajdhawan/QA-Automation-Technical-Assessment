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
    public class RepertoireManagementPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions actions;
        private readonly ExtentTest test;

        public RepertoireManagementPage (IWebDriver driver, WebDriverWait wait, Actions actions, ExtentTest test)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.test = test;
        }

        //Hover on Modules and click on "Repertoire Management Module"//a[contains(@class, 'navbar-item') and text()='Repertoire Management Module']
        private IWebElement MenuClick => wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@class, 'navbar-item') and text()='Repertoire Management Module']")));

        public void ModuleClick()
        {
            MenuClick.Click();        
            test.Log(AventStack.ExtentReports.Status.Info, "Clicked Repertoire Management Module"); 
        }
        
        public void ScrollToAdditionalInformation(){
            // Scroll to the 'Additional Features' section
            IWebElement additionalFeaturesSection = wait.Until(drv => drv.FindElement(By.XPath("//h2[text()='Additional Features']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", additionalFeaturesSection);
            test.Log(AventStack.ExtentReports.Status.Info, "Scrolled to Additional Features");
        }
        
        public void ClickOnProductSupported(){
            // Click on 'Products Supported'
            IWebElement productsSupportedLink = wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Products Supported']")));
            productsSupportedLink.Click();
            test.Log(AventStack.ExtentReports.Status.Info, "Clicked to Products Supported");
        }

        public void AssertProductSupported(){
           
            // Assert on the list of supported products //h3[text()='Specific Text']/following-sibling::ul
            IWebElement productsSupportedList = wait.Until(drv => drv.FindElement(By.XPath("//h3[text()='There are several types of Product Supported:']/following-sibling::div[1]")));
            Assert.NotEmpty(productsSupportedList.FindElements(By.TagName("li")));

            var productStr = "";
            // Optionally print out the list items for debugging
            foreach (var item in productsSupportedList.FindElements(By.TagName("li")))
            {
               productStr = productStr + (item.Text) + "; ";
            }
            test.Log(AventStack.ExtentReports.Status.Info, "Found Supported Products:" + productStr);

            test.Pass("Supported Product validated successfully.");
        }
    }
}
