using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


public class Program
{
    private static void Main(string[] args)
    {
        // To Handle leak password Detection
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        
        // Step-1 Open Chrome Browser
        IWebDriver driver = new ChromeDriver(options);
        
        // Step-2   Launch Turnup Portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io");
        Thread.Sleep(4000);
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        // Step-3 Identify username text box and enter valid user name
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");
        

        // Step-4  Identify password textbox and enter valid password
        IWebElement paswordTextbox = driver.FindElement(By.Id("Password"));
        paswordTextbox.SendKeys("123123");
    
    
        // Step-5   Identify Login button and perform action click
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();

        // Step -6  Test :Check if user login sucessfully or not
        IWebElement HelloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (HelloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User is login successfully! Test is Passed");
        }
        else

        {    
            Console.WriteLine("User is not successfully login! Test is Failed");
        }

        // Step -6  Identify adminstration drop down and perform action click
        IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
        administrationDropdown.Click();

        // Step -7   Click on option Time and Material
        IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TimeAndMaterialOption.Click();

        // Step -8  Click on Create New button
        IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        CreateNewButton.Click();
        
        // Step -9   Identify Dropdown  and select Time option
        IWebElement timeDropdownOPtion = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        timeDropdownOPtion.Click();
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();
       
        // Step-10    Type code in code Textbox
        IWebElement codeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
        codeTextbox.SendKeys("123A");
        
        // Step-11    Type description in description text box
        IWebElement descriptionTextBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
        descriptionTextBox.SendKeys("This is my first Time Order");
        
        // ** Step -12    Type price in price Text box Note:Below code line extra due to overlapping code
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();
        IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
        priceTextBox.SendKeys("12");

        // Step -13   Click on Save Button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(5000);

        // Step -14   Check if Time Record is created successfully or not 
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        Thread.Sleep(4000);
        IWebElement NewCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        
        if (NewCode.Text == "123A")
        {
            Console.WriteLine("new Time Record is created! Test is passed");
        }
        else
        {
            Console.WriteLine("Time Record is not created! Test is Failed");
        }


    }



}