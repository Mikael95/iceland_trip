using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace api
{
    public class scraper
    {
        public string price {get; set;}
        public DateTime dateOfDeparture {get; set;}
        public DateTime dateOfReturn {get; set;}
        public string url {get; set;}
        public DateTime dateOfScan {get; set;}

        public scraper()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://booking.smyrilline.fo/en/book/return/journeySearch/?amp%3Bj2_route=P%7ESFJ-P%7EHRS&amp%3Bcw_nonce=58106f84a4");

            var destinationAwayDropdown = driver.FindElement(By.ClassName("cw-journeysearch-route"));
            var selectElement = new SelectElement(destinationAwayDropdown);
            selectElement.SelectByValue("P~HRS-P~SFJ");

            var vehicle = driver.FindElement(By.Name("cw_journeysearch_j1_vehicles[0][ctg]"));
            selectElement = new SelectElement(vehicle);
            selectElement.SelectByValue("CAR"); 

            var vehicle_length1 = driver.FindElement(By.Id("cw-j1-veh0-length"));
            vehicle_length1.Clear();
            vehicle_length1.SendKeys("5");

            var passengers = driver.FindElement(By.Id("cw-j1-passengers-1"));
            var selectNumOfPassengers = new SelectElement(passengers);
            selectNumOfPassengers.SelectByValue("2");

            Thread.Sleep(5000);
            var calenderMonth = "";
            var calenderNextButton = driver.FindElement(By.ClassName("cw-month-next"));

            while(calenderMonth != "AUGUST 2023")
            {
                calenderNextButton.Click();
                Thread.Sleep(5000);
                var calenderMonthElement = driver.FindElement(By.ClassName("cw-month-current"));
                calenderMonth = calenderMonthElement.Text;
                //Console.WriteLine(calenderMonth);
                calenderNextButton = driver.FindElement(By.ClassName("cw-month-next")); 
            }

            var dates = driver.FindElements(By.ClassName("date"));

            var departureDay = 0;
            var returnDay = 0;

            Thread.Sleep(5000);

            foreach(var date in dates)
            {

                if(date.Text == "15" && departureDay < 1)
                {
                    departureDay++;
                    date.Click();
                    Thread.Sleep(5000);
                }

                if(date.Text == "30" && returnDay < 1)
                {
                    returnDay++;
                }
                
                if(date.Text == "30" && returnDay >= 1)
                {
                   date.Click();
                }
            }

            Thread.Sleep(1000);
           

            //var next = driver.FindElement(By.ClassName("cw-action-next"));
            IWebElement body = driver.FindElement(By.ClassName("cw-action-next"));
            //next.SendKeys(Keys.Control + "t");
            //Actions action = new Actions(driver);
            //action.KeyDown(Keys.Control).MoveToElement(body).Click().Perform();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //Thread.Sleep(5000);

            Thread.Sleep(5000);

            var priceElements = driver.FindElements(By.ClassName("cw-choosejouney-prodinfohover"));
            var prices = new List<int>();

            foreach(var price in priceElements)
            {
                var priceText = price.FindElement(By.ClassName("cw-choosejouney-prodinfohover")).Text;

                if (priceText.Contains('.'))
                {
                    var indexOfDot = priceText.IndexOf('.');
                    priceText = priceText.Substring(0, indexOfDot);
                }
                prices.Add(Convert.ToInt32(priceText));
            }

            var index = prices.IndexOf(prices.Min());

            var priceRadios = driver.FindElements(By.ClassName("choosejourney-departure-1"));
            priceRadios[index].Click();
        }
    }
}