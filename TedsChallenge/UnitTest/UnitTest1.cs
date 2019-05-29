using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TedsChallenge
{
    [TestClass]
    public class UnitTest1
    {

        private static IWebDriver _driver;

        [TestInitialize]
        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void TestNameofRestaurant()
        {

            YelpHomepage yelpHomepage = new YelpHomepage(_driver);

            yelpHomepage.NavigateToYelp();
            yelpHomepage.SendSearchString("Teds Montana Grill", "Denver, CO");
            string nameofRes = yelpHomepage.GetNameofRestuarant();
            Console.WriteLine(nameofRes);
            //Verify the name of the restaurant on the page
            Assert.AreEqual("Ted’s Montana Grill -", nameofRes);
            Thread.Sleep(8000);
            //_driver.Close();
        }

        [TestMethod]
        public void TestOpeningClosingTime()
        {
            YelpHomepage yelpHomepage = new YelpHomepage(_driver);

            yelpHomepage.NavigateToYelp();
            yelpHomepage.SendSearchString("Teds Montana Grill", "Denver, CO");
            string openingTime = yelpHomepage.GetOpeningTime();
            Console.WriteLine(openingTime);
            string closingTime = yelpHomepage.GetCLosingTime();
            Console.WriteLine(closingTime);
            Assert.AreEqual("11:00 am", openingTime);
            Assert.AreEqual("10:00 pm", closingTime);
            Thread.Sleep(8000);
        }

        [TestMethod]
        public void TestLunchDinnerBummer()
        {
            //IWebDriver _driver = new ChromeDriver();
            YelpHomepage yelpHomepage = new YelpHomepage(_driver);

            yelpHomepage.NavigateToYelp();
            yelpHomepage.SendSearchString("Teds Montana Grill", "Denver, CO");
            string openingTime = yelpHomepage.GetOpeningTime();
            //Console.WriteLine(openingTime);
            string closingTime = yelpHomepage.GetCLosingTime();
            //Console.WriteLine(closingTime);

            yelpHomepage.LunchDinnerBummer(openingTime, closingTime);

            Thread.Sleep(8000);
             
        }

        /*Note: TestLunchDinnerBummer() has been tested for different times of a 24 hour period
        so as to display the correct alert.
        The challenge I am facing now is how to inject different `DateTime.Now` for each case
        in the test case. It is work in progress. I will attempt to submit another version.
        */
    }
}