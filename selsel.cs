using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //go to web page
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            webDriver.Manage().Window.Maximize();

            //send keys
            webDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            webDriver.FindElement(By.Id("password")).SendKeys("secret_sauce");

            //click into element
            webDriver.FindElement(By.CssSelector("#login-button")).Click();

            //add 3 items
            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack")).Click();
            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light")).Click();
            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-fleece-jacket")).Click();

            //shopping cart and checkout
            webDriver.FindElement(By.CssSelector("#shopping_cart_container")).Click();
            webDriver.FindElement(By.CssSelector("#checkout")).Click();

            //filling three text fields
            webDriver.FindElement(By.Id("first-name")).SendKeys("Janusz");
            webDriver.FindElement(By.Id("last-name")).SendKeys("Kowalski");
            webDriver.FindElement(By.Id("postal-code")).SendKeys("69-420");

            webDriver.FindElement(By.CssSelector("#continue")).Click();

            //summary and finish
            var price = webDriver.FindElement(By.CssSelector(".summary_total_label")).Text;
            Console.WriteLine($"THANK YOU FOR YOUR ORDER");
            Assert.IsTrue(price == "Total: $97.17");

            //finish
            webDriver.FindElement(By.CssSelector("#finish")).Click();
            var complete = webDriver.FindElement(By.CssSelector(".complete-header")).Text
            Assert.IsTrue(complete == "THANK YOU FOR YOUR ORDER");

            Console.ReadKey();
        }
    }
}