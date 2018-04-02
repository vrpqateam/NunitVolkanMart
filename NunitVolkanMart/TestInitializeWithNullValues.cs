using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NunitVolkanMart
{

    [TestFixture]
    public class TestInitializeWithNullValues : ReportingTasks
    {


        [TestCase("Chrome")]
        [TestCase("Firefox")]
        
        public void TestNameNull(string Browsertype)
        {

            switch (Browsertype)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new RemoteWebDriver(new Uri(defaultGridUrl), new FirefoxOptions());

                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                  //     driver = new RemoteWebDriver(new Uri(defaultGridUrl), new );
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {

                    
                    //    System.setProperty("webdriver.chrome.driver", "/path to/chromedriver.exe");
                        driver = new RemoteWebDriver(new Uri(defaultGridUrl), new ChromeOptions());
                    }
                    break;
            }


            driver.Url = "https://apportal.westeurope.cloudapp.azure.com";
        }


        }

}

