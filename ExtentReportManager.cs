using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace GithubActionsTestProj
{
    public static class ExtentReportManager
    {
        public static ExtentReports extent;

        [ThreadStatic] // each test thread gets its own ExtentTest
        public static ExtentTest test;

        public static void CreateReport()
        {
            if (extent == null) // make sure we don’t recreate
            {
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
                Directory.CreateDirectory(outputDir);

                string reportFile = Path.Combine(outputDir, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                var htmlReporter = new ExtentSparkReporter(reportFile);

                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
