using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Base;
using SeleniumFramework.Pages;
using System;
using Xunit;

namespace SeleniumFramework.Tests
{
    public class MatchingEngineTest : BaseTest
    {
        [Fact]
        public async Task VerifySupportedProducts()
        {

            // Start the test in ExtentReports
            StartTest("Verify Supported Products in MatchingEngine");

            try
            {
                var matchingEngine = new MatchingEnginePage(driver, wait, actions, test);

                var repertoireManagement = new RepertoireManagementPage(driver, wait, actions, test);

                matchingEngine.NavigateMainMenu();

                repertoireManagement.ModuleClick();                

                // Delay for 5 seconds
                await Task.Delay(5000); // 5000 milliseconds = 5 seconds
                test.Log(AventStack.ExtentReports.Status.Info, "Delay for 5 seconds");

                repertoireManagement.ScrollToAdditionalInformation();  

                repertoireManagement.ClickOnProductSupported();  
                
                repertoireManagement.AssertProductSupported();                 
            }
            
            catch (Exception ex)
            {
                // Log failure if an exception occurs
                test.Fail($"Test failed with exception: {ex.Message}");
                throw;
            }
        }
    }
}
