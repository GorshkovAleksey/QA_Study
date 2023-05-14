using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        private string[] tabNames =
        {
            "bank-overview", "accounts-index", "statements-statement", "payments-form",
             "deposits-index", "overview"
        };

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://idemo.bspb.ru/");
            driver.Manage().Window.Size = new System.Drawing.Size(1400, 824);
            FillField("username", "demo");
            FillField("password", "demo");
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(1000);
            FillField("otpCode", "0000");
            driver.FindElement(By.Id("login-otp-button")).Click();
        }

        [Test]
        public void Test1()
        {
            CheckTabs(tabNames);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private void FillField(string fieldName, string fieldValue)
        {
            var field = driver.FindElement(By.Name(fieldName));
            field.Clear();
            field.SendKeys(fieldValue);
        }

        private void CheckTabs(string[] tabNames)
        {
            foreach (string tabName in tabNames)
            {
                //Thread.Sleep(500);
                var tab = driver.FindElement(By.Id(tabName));
                Assert.IsNotNull(tab, $"Ёлемент {tabName} не найден!");
            }
        }
    }
}