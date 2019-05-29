using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TedsChallenge
{
    public class YelpHomepage
    {
        IWebDriver driver;

        string yelpUrl = "http://yelp.com";
        By findEditBox = By.Id("find_desc");
        By nearEditBox = By.Id("dropperText_Mast");
        string resNameAurora = "Ted’s Montana Grill - Aurora";
        string jscript =
            "return document.getElementsByClassName('biz-hours')[0]."
            + "getElementsByClassName('u-space-r-half')[0].innerText";

       

        public YelpHomepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToYelp()
        {
            driver.Navigate().GoToUrl(yelpUrl);
        }

        public void SendSearchString(string searchString, string searchString2)
        {
            driver.FindElement(findEditBox).SendKeys(searchString);
            driver.FindElement(nearEditBox).Clear();
            driver.FindElement(nearEditBox).SendKeys(searchString2);
            driver.FindElement(nearEditBox).SendKeys(Keys.Return);
            driver.FindElement(By.LinkText(resNameAurora)).Click();
        }
        
       public string GetNameofRestuarant()
        {
            return driver.FindElement(By.XPath("//*[@id='wrap']/div[2]/div/div[1]/div/div[3]/div[1]/div[1]/h1")).Text;
        }

        public string GetOpeningTime()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string time = (string)js.ExecuteScript(jscript);
            return time.Substring(0, 8);
           
        }

        public string GetCLosingTime()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string time = (string)js.ExecuteScript(jscript);
            return time.Substring(11, 8);
         
        }

        public void LunchDinnerBummer(string openingTime, string closingTime)
        {
            //Based on the current time, alerts the user
            //if it is lunch/dinner time or outside of 
            //business hours
            var openTime = DateTime.Parse(openingTime);
            var closeTime = DateTime.Parse(closingTime);
            
            //End of lunch time
            var lunchTime = DateTime.Parse("3:00 PM");

            //For lunch time
            if (openTime < DateTime.Now && DateTime.Now < lunchTime)
                Console.WriteLine("It is time to go to Ted’s for lunch!");
            
            //For dinner time
            else if (DateTime.Now > lunchTime && DateTime.Now < closeTime)
                Console.WriteLine("It is time to go to Ted’s for dinner!");
            
            //If outside of business hour before Opening Time for today
            else if (DateTime.Now < openTime)
            {
                TimeSpan span = openTime.Subtract(DateTime.Now);
                Console.WriteLine("Bummer, Ted’s is closed");
                Console.WriteLine("Ted’s will open in: " + span.Hours + " hour " + " and " + span.Minutes + " minutes ");
            }
            //If outside of business hours past closing time for today
            //Calculate for the hours and minutes left till opening time for next day
            else
            {
                var openTimeNextDay = openTime.AddDays(1);
                TimeSpan span = openTimeNextDay.Subtract(DateTime.Now);
                Console.WriteLine("Bummer, Ted’s is closed");
                Console.WriteLine("Ted’s will open in: " + span.Hours + " hour " + " and " + span.Minutes + " minutes ");
            }

        }
    }
}
