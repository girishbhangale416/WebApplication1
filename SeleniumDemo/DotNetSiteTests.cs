using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Demo.SeleniumTests
{
    [TestClass]
    public class DotNetSiteTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestGetStarted()
        {
           
            using (var driver = GetDriver())
            {
                //Navigate to DotNet website
                driver.Navigate().GoToUrl(Enviroment.GetEnviromentVariable("appUrl"));

                driver.FindElement(By.XPath("//a[@href='/counter']")).Click();
                driver.FindElement(By.XPath("//button[text()='Increment']")).Click();
                var count = driver.FindElement(By.XPath("//p[text()='Current count: ']/strong")).Text;
                

                // verify the title is the expected value "Next steps"
                Assert.AreEqual(count, "1");
            }
        }

        [TestMethod]
        public void TestGetStarted2()
        {

            using (var driver = GetDriver())
            {
                //Navigate to DotNet website
                driver.Navigate().GoToUrl(Enviroment.GetEnviromentVariable("appUrl"));

                driver.FindElement(By.XPath("//a[@href='/counter']")).Click();
                driver.FindElement(By.XPath("//button[text()='Increment']")).Click();
                driver.FindElement(By.XPath("//button[text()='Increment']")).Click();
                var count = driver.FindElement(By.XPath("//p[text()='Current count: ']/strong")).Text;


                // verify the title is the expected value "Next steps"
                Assert.AreEqual(count, "1");
            }
        }

        private ChromeDriver GetDriver()
        {
            var options = new ChromeOptions();

            if(bool.Parse((string)TestContext.Properties["headless"]))
            {
                options.AddArgument("headless");
            }

            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }
    }
}