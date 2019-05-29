using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TedsChallenge.step_definition
{
    [Binding]
    public class RestaurantNameSteps
    {

        private static readonly IWebDriver _driver = new ChromeDriver();
        readonly YelpHomepage yelpHomepage = new YelpHomepage(_driver);

        [Given(@"Navigated to Yelp site")]
        public void GivenNavigatedToYelpSite()
        {

            yelpHomepage.NavigateToYelp();
        }

        [When(@"Search for a restaurant")]
        public void WhenSearchForARestaurant()
        {
            yelpHomepage.SendSearchString("Teds Montana Grill", "Denver, CO");

            //_driver.Close();
        }

        [Then(@"Display and verify the name")]
        public void ThenDisplayAndVerifyTheName()
        {
            string nameofRes = yelpHomepage.GetNameofRestuarant();
            Console.WriteLine(nameofRes);
            //Verify the name of the restaurant on the page
            Assert.AreEqual("Ted’s Montana Grill -", nameofRes);
            Thread.Sleep(8000);
            _driver.Quit();
        }

    }
}
