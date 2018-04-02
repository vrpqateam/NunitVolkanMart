using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Utils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.ViewDefs;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace NunitVolkanMart
{
    [SetUpFixture]
    public abstract class ReportingTasks
    {
       
            protected ExtentReports _extent;
            protected ExtentTest _test;
            protected RemoteWebDriver driver;
            protected const string defaultBaseUrl = "http://localhost:5001";
            protected const string defaultGridUrl = "http://127.0.0.1:4444/wd/hub";
    
            [OneTimeSetUp]
            protected void Setup()
            {
                var dir = TestContext.CurrentContext.TestDirectory + "\\";
                string reportpath = Path.GetFullPath(Path.Combine(dir, @"..\..\..\Reports\"));
                var fileName = this.GetType().ToString() + ".html";
                var htmlReporter = new ExtentHtmlReporter(reportpath + fileName);
            

            _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }

            [OneTimeTearDown]
            protected void TearDown()
            {
                _extent.Flush();
            }

      

            [SetUp]
            public void BeforeTest()
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

       
        }


            [TearDown]
            public void AfterTest()
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
                Status logstatus;

                switch (status)
                {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;

            }

                _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
                _extent.Flush();
                 driver.Quit();
                driver = null;
        }
        }




    }
