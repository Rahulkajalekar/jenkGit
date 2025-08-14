

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace GithubActionsTestProj
{
    public class ExtentReportManager
    {

        public static ExtentReports extent;
        public static ExtentTest test;



        public static void createReport()
        {

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
            Directory.CreateDirectory(outputDir);

            var htmlReporter = new ExtentSparkReporter(Path.Combine(outputDir, "ExtentReport.html"));
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);






        }


        public static void FlushReport()
        {
            extent.Flush();
        }












    }
}
