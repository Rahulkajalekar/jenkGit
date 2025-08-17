using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubActionsTestProj
{
    [TestFixture]
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ExtentReportManager.CreateReport();
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentReportManager.FlushReport();
        }
    }
}
