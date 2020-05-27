using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Basic.business_object;
using Selenium_Basic.ui.page_elements;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Selenium_Basic.step_definition
{
   [Binding]
    class StepForWorkWithProduct
    {
        private IWebDriver driver;
         [Given (@"I open url ""(.*)""")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
        }
        [When (@"I input login ""(.*)"" and password ""(.*)""")]
        public void WhenIInputLoginAndPassword(string login, string password)
        {
            PageLogin pageLogin = new PageLogin(driver);
            pageLogin.LoginNwApp(new User(login, password));
        }
        [When (@"I click the button login")]
        public void AndIClickTheButtonLogin()
        {
            new PageLogin(driver).ClickButtonLogin();
        }
        [Then (@"Titel of home page should be ""(.*)""")]
        public void ThenTitelOfNewPageShouldBe(string titel)
        {
            Assert.IsTrue(titel == new PageHomePage(driver).GetHomePage());
        }
        [When (@"I click on the line All Product")]
        public void WhenIClickOnTheLineAllProduct()
        {
            new PageHomePage(driver).MoveToAllProducts();
        }
        [Then (@"Titel of new page should be ""(.*)""")]
        public void TitelOfNewPageShouldBe(string titel)
        {
            Assert.AreEqual(titel,new PageAllProducts(driver).GetAllProducts());
        }
        [When (@"I click button create new")]
        public void IClickButtonCreateNew ()
        {
            new PageAllProducts(driver).MoveToCreate();
        }
        [When (@"I specify the following values ProductName ""(.*)"" Category ""(.*)"" Supplier ""(.*)"" UnitPrice ""(.*)"" QuantityPerUnit ""(.*)""  UnitsInStock ""(.*)"" UnitsOnOrder ""(.*)"" ReorderLevel ""(.*)"" Discontinued ""(.*)""")]
        public void ISpecifyTheFollowingValues(string productName, string categoryValue, string supplierValue, string unitPrice, string quantityPerUnit,
            string unitsInStock, string unitsOnOrder, string reorderLevel, string discontinued)
        {
            ProductForTest productForTest = new ProductForTest(productName, categoryValue, supplierValue, unitPrice, quantityPerUnit,
                unitsInStock, unitsOnOrder, reorderLevel, discontinued);
            new PageCreate(driver).CreateNewProduct(productForTest);
        }
        [When(@"I click the button send")]
        public void IClickTheButtonSend ()
        {
            new PageCreate(driver).ClickCreateNewProduct();
        }
        [Then(@"The new added product have the name ""(.*)""")]
        public void TheNewAddedProductHaveTheName(string name)
        {
            Assert.AreEqual(name,new PageAllProducts(driver).GetProductsName(name));
        }
    }
}
