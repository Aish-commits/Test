using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GitDemo
{
    class ExtentReportsDemo
    {
        public ExtentReports extent = null;
        public ExtentTest Test = null;
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Automation\C-sharp\Project\GitDemo\GitDemo\Execution Reports\ExtentReportsDemo.html");
            extent.AttachReporter(htmlReporter);
        }
        [Test]
        public void FormSubmission()
        {
            try
            {
                Test = extent.CreateTest("TC-1: Form Submission", "This is a Form Submission Test").Info("Test Started");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Form");
                Test.Log(Status.Info, "URL Loaded");
                driver.FindElement(By.Id("firstname")).SendKeys("Aish");
                Test.Log(Status.Info, "FirstName entered successfully");
                driver.Quit();
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail,e.ToString());
                throw;
            }
        }
        [Test]
        public void FormSubmission1()
        {
            try
            {
                Test = extent.CreateTest("TC-2: Form Submission", "This is a Form Submission Test").Info("Test Started");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Form");
                Test.Log(Status.Info, "URL Loaded");
                driver.FindElement(By.Id("firstname1")).SendKeys("Aish");
                Test.Log(Status.Info, "FirstName entered successfully");
                driver.Quit();
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, e.ToString());
                throw;
            }
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
