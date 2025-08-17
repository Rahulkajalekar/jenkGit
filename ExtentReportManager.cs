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
            if (extent == null)
            {
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
                Directory.CreateDirectory(outputDir);

                string timestampedReport = Path.Combine(outputDir, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                string latestReport = Path.Combine(outputDir, "ExtentReport_LATEST.html");

                var htmlReporter = new ExtentSparkReporter(timestampedReport);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);

                var newhtmlreporter = new ExtentSparkReporter(latestReport);
                extent.AttachReporter(newhtmlreporter);

                //// Also copy the same report as LATEST.html after flush
                //AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                //{
                //    try
                //    {
                //        if (File.Exists(timestampedReport))
                //            File.Copy(timestampedReport, latestReport, true);
                //    }
                //    catch { }
                //};
            }
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
