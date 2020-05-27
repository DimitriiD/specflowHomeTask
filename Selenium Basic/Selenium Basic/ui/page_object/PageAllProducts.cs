﻿using OpenQA.Selenium;
using Selenium_Basic.business_object;

namespace Selenium_Basic
{
    class PageAllProducts
    {
        private IWebDriver driver;
        public PageAllProducts(IWebDriver driver)
        {
            this.driver = driver;
        }
        private string productXpath;
        private string productXPathForRemove;
        private IWebElement create => driver.FindElement(By.XPath("//a[@href='/Product/Create']"));
        private IWebElement allProducts => driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]"));
        private IWebElement productName => driver.FindElement(By.XPath(productXpath));
        private IWebElement productRemove => driver.FindElement(By.XPath(productXPathForRemove));
        private IWebElement logout => driver.FindElement(By.XPath("//a[@href='/Account/Logout']"));

        public PageCreate MoveToCreate()
        {
            create.Click();
            return new PageCreate(driver);
        }
        public PageEditProduct MoveToProduct(ProductForTest productForTest)
        {
            productXpath = $"//a[contains(text(),\"{productForTest.productName }\")]";
            productName.Click();
            return new PageEditProduct(driver);
        }
        public string GetAllProducts()
        {
            return (allProducts.Text);
        }
        public string GetProductsName(string findName)
        {
            productXpath = $"//a[contains(text(),\"{findName }\")]";
            return (productName.Text);
        }
        public void RemoveProduct (ProductForTest productForTest)
        {
            productXPathForRemove = $"//following-sibling::tr/td[contains(.,\"{productForTest.productName }\")]/../td/a[contains(text(),'Remove')]";
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();
        }
        public string xpathProduct (ProductForTest productForTest)
        {
            return productXpath = $"//a[contains(text(),\"{productForTest.productName }\")]";
        }
        public PageLogin Logout ()
        {
            logout.Click();
            return new PageLogin(driver);
        }
    }
}
