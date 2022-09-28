using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace api
{
    public class scraper
    {
        public startScraper()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://https://booking.smyrilline.fo/en/book/return/journeySearch/?amp%3Bj2_route=P%7ESFJ-P%7EHRS&amp%3Bcw_nonce=58106f84a4");

            var vehicle = driver.FindElement(By.Name("cw_journeysearch_j1_vehicles[0][ctg]"));
            var selectElement = new SelectElement(vehicle);
            selectElement.SelectByValue("CAR"); 

            var vehicle_length1 = driver.FindElement(By.Id("cw-j1-veh0-length"));
            var vehicle_length2 = driver.FindElement(By.Id("cw-j2-veh0-length"));

            vehicle_length1.Clear();
            vehicle_length2.Clear();
            vehicle_length1.SendKeys("5");
            vehicle_length2.SendKeys("5");

            var passengers = driver.FindElement(By.Id("cw-j1-passengers-1"));
            var selectNumOfPassengers = new SelectElement(passengers);
            selectNumOfPassengers.SelectByValue("2");

            var calenderMonth = driver.FindElement(By.ClassName("cw-month-current"));
            var calenderNextButton = driver.FindElement(By.ClassName("cw-month-next"));

            while(calenderMonth.Text != "August 2023")
            {
                calenderNextButton.Click();
                Thread.Sleep(3000);
                calenderMonth = driver.FindElement(By.ClassName("cw-month-current")); 
            }

            var dates = driver.FindElements(By.ClassName("date"));

            foreach(var date in dates)
        }
    }
}