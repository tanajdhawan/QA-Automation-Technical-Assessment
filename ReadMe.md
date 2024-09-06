
<!-- ABOUT THE PROJECT -->
## About The Assesment

Selenium web browser testing framework in .NET Core with Selenium WebDriver and XUnit (for writing test cases).
Coding test


[![Project Screen Shot][project-screenshot]


### Prerequisites
* .NET Core 5.0 SDK.
* Visual Studio or Visual Studio Code.
* Selenium WebDriver 
* Browser Driver (like ChromeDriver)


### Built With .Net Core Libraries

Below libraries are used  for the project 

* dotnet new xunit -n SeleniumFramework
* dotnet add package Selenium.WebDriver
* dotnet add package Selenium.WebDriver.ChromeDriver
* dotnet add package Selenium.Support
* dotnet add package ExtentReports


<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation


1. Clone the repo
   ```sh
   git clone https://github.com/github_username/repo_name.git
   ```
2. Build Tests
   ```
   dotnet build
   ```
3. Run Tests
   ```
   dotnet test
   ```
5. For Errors
   ```
   dotnet restore 
   ```




<!-- USAGE EXAMPLES -->
## Project Structure

1. Base Folder > BaseTest.cs
    ```
    ExtentHtmlReporter: Configured to generate an HTML report file (TestReport.html). Can update the path @"C:\Users\NetCoreSeliniumUni\SeleniumFramework\TestReports";
    ```
    ```
    ExtentReports: A static instance of ExtentReports to maintain and generate the report.
    StartTest: A method that starts the test recording.
    Dispose: The Dispose() method not only quits the browser but also flushes the Extent report after each test.
    ```
    [![Base Test Page Screen Shot][basetest-screenshot]
    
2. Pages Folder > MatchingEnginePage.cs
    ```
    NavigateMainMenu
    ```
    [![Matching Engine Page Screen Shot][matchengpage-screenshot]
    RepertoireManagementPage.cs
    ```
    ModuleClick
    ScrollToAdditionalInformation
    ClickOnProductSupported
    AssertProductSupported
    ```
    [![Repertoire Module Page Screen Shot][repemoduletpage-screenshot]

3. Test > MatchingEngineTest.cs
    ```
    [Fact]
    public async Task VerifySupportedProducts()
    Entry test case
    ```
    [![Matching Engine Screen Shot][matchengtest-screenshot]

3. TestReports > TestReport.html
    ```
    Sample report for each test
    ```
    [![Report Screen Shot][report-screenshot]




[report-screenshot]: Images/TestReport.JPG
[project-screenshot]: Images/ProjectStructure.JPG
[basetest-screenshot]: Images/BaseTest.JPG
[matchengpage-screenshot]: Images/MatchingEnginePage.JPG
[matchengtest-screenshot]: Images/MatchingEngineTest.JPG
[repemoduletpage-screenshot]: Images/RepertoireModule.JPG
