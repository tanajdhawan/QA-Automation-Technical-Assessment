using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;  // For ExtentSparkReporter
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace SeleniumFramework.Base
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected Actions actions;
        protected WebDriverWait wait;
        protected static ExtentReports extent;
        protected static ExtentSparkReporter sparkReporter;
        protected ExtentTest test;

        public BaseTest()
        {
            // Initialize the Chrome WebDriver
            driver = new ChromeDriver();
            actions = new Actions(driver);

            // Initialize WebDriverWait with a timeout of 10 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Set up the path for the ExtentReports
            string reportDirectory = @"C:\Users\dhawa\Desktop\SeleniumFramework\TestReports";

            Console.WriteLine(reportDirectory);
            // Ensure the directory exists
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            // Setup ExtentReports for HTML reporting (this is done once)
            if (extent == null)
            {
                // Set up the Spark Reporter for generating HTML reports
                sparkReporter = new ExtentSparkReporter(Path.Combine(reportDirectory, "TestReport.html"));

                // Optionally configure the report properties
                sparkReporter.Config.DocumentTitle = "Test Automation Report";
                sparkReporter.Config.ReportName = "Matching Engine Test Automation";

                // Attach the reporter to the ExtentReports instance
                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);

                // Add system info (optional)
                extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                extent.AddSystemInfo("Host Name", Environment.MachineName);
                extent.AddSystemInfo("Browser", "Chrome");
            }
        }

        // Method to start the ExtentTest for each test
        public void StartTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        // Dispose is called after each test is executed
        public void Dispose()
        {
            // Quit the browser after the test
            driver.Quit();

            // Flush the report to generate the output file
            extent.Flush();
        }
    }
}
