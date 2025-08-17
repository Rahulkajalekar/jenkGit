using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.WaitHelpers;

namespace GithubActionsTestProj
{
    public class UnitTest1 : TestBase
    {
        IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://playwright.dev");

            // ✅ Create a new test node for each test case
            var testName = TestContext.CurrentContext.Test.Name;
            ExtentReportManager.test = ExtentReportManager.extent.CreateTest($"{GetType().Name} - {testName}");
        }

        [Test]
        public void TC01_verifyPlaywrightPageTitle()
        {
            string title = driver.Title;

            if (title.Contains("Playwright"))
                ExtentReportManager.test.Pass("Title contains Playwright");
            else
                ExtentReportManager.test.Fail("Title does not contain Playwright");
        }

        [Test]
        public void TC02_verifyPlaywrightPage()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Get started')]")));
            IWebElement getStarted = driver.FindElement(By.XPath("//a[contains(text(),'Get started')]"));

            if (getStarted.Text.ToUpper().Equals("GET STARTED"))
                ExtentReportManager.test.Pass("Button text is GET STARTED");
            else
                ExtentReportManager.test.Fail("Button text mismatch");

            Assert.IsTrue(getStarted.Displayed, "Get Started Not Found.");
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ExtentReportManager.test.Fail("Test failed: " + TestContext.CurrentContext.Result.Message);
            }

            driver.Quit();
        }


    }
}
