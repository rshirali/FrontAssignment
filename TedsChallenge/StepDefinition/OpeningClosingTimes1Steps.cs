using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TedsChallenge.step_definition
{
    [Binding]
    public class OpeningClosingTimes1Steps
    {
        private static readonly IWebDriver _driver = new ChromeDriver();
        readonly YelpHomepage yelpHomepage = new YelpHomepage(_driver);

        [Given(@"Landed on Yelp site")]
        public void GivenLandedOnYelpSite()
        {
            yelpHomepage.NavigateToYelp();
        }
        
        [When(@"Search for an restaurant")]
        public void WhenSearchForAnRestaurant()
        {
            yelpHomepage.SendSearchString("Teds Montana Grill", "Denver, CO");
        }
        
        [Then(@"Verify Opening and Closing time displayed")]
        public void ThenVerifyOpeningAndClosingTimeDisplayed()
        {
            string openingTime = yelpHomepage.GetOpeningTime();
            Console.WriteLine(openingTime);
            string closingTime = yelpHomepage.GetCLosingTime();
            Console.WriteLine(closingTime);
            Assert.AreEqual("11:00 am", openingTime);
            Assert.AreEqual("10:00 pm", closingTime);
            Thread.Sleep(8000);
            _driver.Quit();
        }
    }
}
