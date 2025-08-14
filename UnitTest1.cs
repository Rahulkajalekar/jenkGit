using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace GithubActionsTestProj
{
    public class Tests
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

            ExtentReportManager.test = ExtentReportManager.extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--disable-gpu");
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://playwright.dev");

            
        }

        [Test]
        public void verifyPalywrightPage()
        {

            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Get started')]")));
            IWebElement getStarted = driver.FindElement(By.XPath("//a[contains(text(),'Get started')]"));

            if (getStarted.Text.ToUpper().Equals("GET STARTE"))
            {
                ExtentReportManager.test.Pass("Title contains GET STARTED");
            }
            else
            {
                ExtentReportManager.test.Fail("Title does not contain GET STARTED");
            }
            Assert.IsTrue(getStarted.Displayed,"Get Started Not Found.");
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