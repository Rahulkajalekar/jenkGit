using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace GithubActionsTestProj
{
    public class UnitTest2
    {


        IWebDriver driver;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentReportManager.createReport();
        }


        [SetUp]
        public void Setup()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            ExtentReportManager.test = ExtentReportManager.extent.CreateTest($"{GetType().Name} - {testName}");
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--disable-gpu");
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://playwright.dev");
            //////

        }

        [Test]
        public void TC01_verifyPalywrightPageTitle_TS02()
        {

            String getTitle = driver.Title;

            if (getTitle.ToUpper().Equals("Fast and reliable end-to-end testing for modern web apps | Playwright"))
            {
                ExtentReportManager.test.Pass("Title contains Fast and reliable");
            }
            else
            {
                ExtentReportManager.test.Fail("Title does not contain Fast and reliable");
            }

        }

        [Test]
        public void TC02_verifyPalywrightPage_TS02()
        {

            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Get started')]")));
            IWebElement getStarted = driver.FindElement(By.XPath("//a[contains(text(),'Get started')]"));

            if (getStarted.Text.ToUpper().Equals("GET STARTED"))
            {
                ExtentReportManager.test.Pass("Title contains GET STARTED");
            }
            else
            {
                ExtentReportManager.test.Fail("Title does not contain GET STARTED");
            }
            Assert.IsTrue(getStarted.Displayed, "Get Started Not Found.");
        }


        [TearDown]
        public void tearDown()
        {

            driver.Quit();
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ExtentReportManager.test.Fail("Test failed: " + TestContext.CurrentContext.Result.Message);
            }
        }


        [OneTimeTearDown]
        public void TearDownReport()
        {
            ExtentReportManager.FlushReport();
        }





    }
}