using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SayHelloTest_Selenium
{
    [TestClass]
    public class UnitTest1
    {
        private static string driverFolder = "C:\\Users\\xnikm\\Documents\\SeleniumWebdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new FirefoxDriver(driverFolder);

        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }



        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);

            IWebElement inputElement = _driver.FindElement(By.Id("name"));
            inputElement.SendKeys("Hans");

            IWebElement btn = _driver.FindElement(By.CssSelector("[name='Show']"));
            btn.Click();


            IWebElement output = _driver.FindElement(By.CssSelector("output"));
            string text = output.Text;

            Assert.AreEqual("Hans", text);

        }
    }
}
