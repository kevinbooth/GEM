using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
namespace SeleniumTest
{
    [TestFixture]
    public class FirstTestCase
    {
        IWebDriver driver;

        [SetUp]
        public void startTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
        }

        [TearDown]
        public void endTest()
        {
            driver.Quit();
        }

        public void helperCreateNavTest()
        {
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Log in"));
            brwseBtn.Click();
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            IWebElement createBtn = driver.FindElement(By.LinkText("Create"));
            createBtn.Click();
        }

        public class RandomGenerator
        {
            // Generate a random number between two numbers  
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            // Generate a random string with a given size  
            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }

            // Generate a random password  
            public string RandomPassword()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(4, true));
                builder.Append(RandomNumber(1000, 9999));
                builder.Append(RandomString(2, false));
                return builder.ToString();
            }
        }//end randomGenerator

        //tests navigation to browse page
        [Test]
        public void browseLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the browse page
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Browse"));
            brwseBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Browse"), "User was not navigated to the browse page.");
            driver.Quit();
        }

        //tests navigation to create page
        [Test]
        public void createLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the create page
            IWebElement createBtn = driver.FindElement(By.LinkText("Create"));
            createBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Create"), "User was not navigated to the create page.");
            driver.Quit();
        }

        //tests navigation to create page (changed due to needing to be logged in)
        [Test]
        public void newCreateLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the login page
            IWebElement loginHeader = driver.FindElement(By.LinkText("Log in"));
            loginHeader.Click();
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            //navigates to the create page
            IWebElement createBtn = driver.FindElement(By.LinkText("Create"));
            createBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Create"), "User was not navigated to the create page.");
            driver.Quit();
        }

        //tests navigation to login modal
        [Test]
        public void loginLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement loginBtn = driver.FindElement(By.LinkText("Login »"));
            loginBtn.Click();
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Login"));
            driver.Quit();
        }

        //tests navigation to register page
        [Test]
        public void registerLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement registerBtn = driver.FindElement(By.LinkText("Register"));
            registerBtn.Click();
            driver.Quit();
        }

        //tests navigation to login page
        [Test]
        public void rightLoginLinkTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement loginBtn = driver.FindElement(By.LinkText("Log in"));
            loginBtn.Click();
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Login"), "User was not navigated to the login page.");
            driver.Quit();
        }

        //tests registers a user using random credentials
        [Test]
        public void registerTest()
        {
            RandomGenerator generator = new RandomGenerator();
            //sets email and password
            string mail = generator.RandomString(10, true);
            string pass = generator.RandomPassword();
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the register tab
            IWebElement registerBtn = driver.FindElement(By.LinkText("Register"));
            registerBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Register"), "User was not navigated to the register page.");
            //fills out the required fields apporpriately
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys($"{mail}@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys($"{pass}!");
            IWebElement confirmField = driver.FindElement(By.Id("ConfirmPassword"));
            confirmField.SendKeys($"{pass}!");
            //clicks the register button
            IWebElement register = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/button"));
            register.Click();
            driver.Quit();
        }

        //tests login page functionality
        [Test]
        public void loginPageTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Log in"));
            brwseBtn.Click();
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //tests 'remember me?' checkbox
            IWebElement rememberMe = driver.FindElement(By.Id("RememberMe"));
            rememberMe.Click();
            rememberMe.Click();
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            driver.Quit();
        }//end loginPageTest

        //tests login modal functionality
        [Test]
        public void loginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Login »"));
            brwseBtn.Click();
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("exampleInputEmail1"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("exampleInputPassword1"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id='exampleModal']/div/div/div[3]/button[2]"));
            //LOGIN CURRENTLY NOT IMPLEMENTED
            //loginBtn.Click();
            //tests closing the modal with x
            IWebElement xClose = driver.FindElement(By.XPath("//*[@id='exampleModal']/div/div/div[1]/button/span"));
            xClose.Click();
            driver.Quit();
        }//end loginTest

        //tests login page register redirect
        [Test]
        public void loginToReg()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement loginBtn = driver.FindElement(By.LinkText("Log in"));
            loginBtn.Click();
            //tests 'register as a new user?' link
            IWebElement register = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[6]/p[2]/a"));
            register.Click();
            driver.Quit();
        }//end loginToReg

        //tests forgot password functionality
        [Test]
        public void forgotPassword()
        {
            RandomGenerator generator = new RandomGenerator();
            string mail = generator.RandomString(10, true);
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            IWebElement loginBtn = driver.FindElement(By.LinkText("Log in"));
            loginBtn.Click();
            //tests 'forgot your password?' link
            IWebElement forgot = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[6]/p[1]/a"));
            forgot.Click();
            //fills out required fields with incorrect information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("blahBLAH123");
            IWebElement submit = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/button"));
            submit.Click();
            emailField.Clear();
            //fills out required fields with correct information
            emailField.SendKeys($"{mail}@mailinator.com");
            submit.Click();
            driver.Quit();
        }//end loginToReg

        //tests creation of a public event
        [Test]
        public void createPublicEventTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the browse page
            IWebElement loginHeaderBtn = driver.FindElement(By.LinkText("Log in"));
            loginHeaderBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Login"), "User was not navigated to the login page.");
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            //navigates to the create page
            IWebElement createBtn = driver.FindElement(By.LinkText("Create"));
            createBtn.Click();
            //Fills our required fields to create an event
            IWebElement title = driver.FindElement(By.Id("title"));
            title.SendKeys("Backyard BBQ");
            IWebElement description = driver.FindElement(By.Id("desc"));
            description.SendKeys("Come join us in the nice Spring weather for fun, friends, and food!");
            IWebElement location = driver.FindElement(By.Id("location"));
            location.SendKeys("NHTI Quad");
            IWebElement dateAndTime = driver.FindElement(By.Id("DateAndTime"));
            dateAndTime.SendKeys("05192018");
            dateAndTime.SendKeys(Keys.Tab);
            dateAndTime.SendKeys("0100p");
            IWebElement attendee = driver.FindElement(By.XPath("//*[@id='sel1']/option[1]"));
            attendee.Click();
            //submits alll the information/creates event
            IWebElement submit = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/form/button"));
            submit.Click();
            driver.Quit();
        }

        //test deletion of previously created event
        [Test]
        public void deletePublicEventTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to login page
            IWebElement loginHeader = driver.FindElement(By.LinkText("Log in"));
            loginHeader.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Login"), "User was not navigated to the login page.");
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            //navigates to account page
            IWebElement account = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a"));
            account.Click();
            //attempts to delete bottom most event
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[5]/a"));
            delete.Click();
            //ensures event was deleted
            String newURL = driver.Url;
            Assert.IsTrue(newURL.Contains("Manage/Delete?eventId"), "Event was not deleted");
            driver.Quit();
        }

        //test search functionality of events
        [Test]
        public void searchTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the browse page
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Browse"));
            brwseBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Browse"), "User was not navigated to the browse page.");
            //searches by date
            IWebElement searchBar = driver.FindElement(By.XPath("//*[@id='browseData_filter']/label/input"));
            searchBar.Click();
            searchBar.SendKeys("06");
            //ensures date was filtered
            String dateText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[1]")).Text;
            Assert.IsTrue(dateText.Contains("06/17/2018 2:00 PM"), "Filter by date did not function correctly");
            //searches by title
            searchBar.Clear();
            searchBar.SendKeys("BBQ");
            //ensures title was filtered
            String titleText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[2]")).Text;
            Assert.IsTrue(titleText.Contains("Backyard BBQ"), "Filter by title did not function correctly");
            //search by description
            searchBar.Clear();
            searchBar.SendKeys("nice spring");
            //ensures description was filtered
            String descText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[3]")).Text;
            Assert.IsTrue(descText.Contains("Come join us in the nice Spring weather for fun, friends, and food!"), "Filter by cescription did not function correctly");
            //search by description
            searchBar.Clear();
            searchBar.SendKeys("Quad");
            //ensures description was filtered
            String locationText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[4]")).Text;
            Assert.IsTrue(locationText.Contains("NHTI Quad"), "Filter by location did not function correctly");
            driver.Quit();
        }

        //test sort functionality of events
        [Test]
        public void sortTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to the browse page
            IWebElement brwseBtn = driver.FindElement(By.LinkText("Browse"));
            brwseBtn.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Browse"), "User was not navigated to the browse page.");
            //sorts by date
            IWebElement dateSort = driver.FindElement(By.XPath("//*[@id='browseData']/thead/tr/td[1]"));
            dateSort.Click();
            //ensures results were sorted by date
            String dateText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[1]")).Text;
            Assert.IsTrue(dateText.Contains("04/28/2018 12:00 PM"), "Filter by date did not function correctly");
            //sorts by title
            IWebElement titleSort = driver.FindElement(By.XPath("//*[@id='browseData']/thead/tr/td[2]"));
            titleSort.Click();
            //ensures results were sorted by title
            String titleText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[2]")).Text;
            Assert.IsTrue(titleText.Contains("ASP.NET Tech Conference"), "Filter by title did not function correctly");
            //sorts by description
            IWebElement descSort = driver.FindElement(By.XPath("//*[@id='browseData']/thead/tr/td[3]"));
            descSort.Click();
            //ensures results were sorted by description
            String descText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[3]")).Text;
            Assert.IsTrue(descText.Contains("Come eat some cake!"), "Filter by cescription did not function correctly");
            //sorts by description
            IWebElement locationSort = driver.FindElement(By.XPath("//*[@id='browseData']/thead/tr/td[4]"));
            locationSort.Click();
            //ensures results were sorted by date
            String locationText = driver.FindElement(By.XPath("//*[@id='srchTable']/tr/td[4]")).Text;
            Assert.IsTrue(locationText.Contains("5 Main Street, Washington, DC 20012"), "Filter by location did not function correctly");
            driver.Quit();
        }

        //tests updating profile
        [Test]
        public void updateProfile()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://gem.azurewebsites.net/";
            //navigates to login page
            IWebElement loginHeader = driver.FindElement(By.LinkText("Log in"));
            loginHeader.Click();
            //ensures navigation was correct
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains("Login"), "User was not navigated to the login page.");
            //fills out required fields with static information
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys("test@mailinator.com");
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("passWORD12!");
            //logs the user in
            IWebElement loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/form/div[5]/button"));
            loginBtn.Click();
            //navigates to account page
            IWebElement accountBtn = driver.FindElement(By.LinkText("My Account"));
            accountBtn.Click();
            //clears email field and tests validation
            IWebElement accountEmail = driver.FindElement(By.Id("Email"));
            accountEmail.Clear();
            IWebElement save = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[1]/div/form/button"));
            save.Click();
            //ensures error appeared
            IWebElement emailError = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[1]/div/form/div[1]"));
            Assert.IsTrue(emailError.Displayed);
            //updates email and phone number
            IWebElement phone = driver.FindElement(By.Id("PhoneNumber"));
            accountEmail.SendKeys("testeremail@mailinator.com");
            phone.SendKeys("5551234567");
            save.Click();
            //ensures success message appeared
            IWebElement correctMessage = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[1]"));
            Assert.IsTrue(correctMessage.Displayed);
            driver.Quit();
        }

    }//end FirstTestCase
}//end namespace SeleniumTest
