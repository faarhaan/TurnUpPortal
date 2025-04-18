using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Pages;


public class Program
{
     private static void Main(string[] args)
    {
        // To Handle leak password Detection
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        
        //  Open Chrome Browser
        IWebDriver driver = new ChromeDriver(options);

        // LoginPage Object initiallization and definition
        LoginPage loginpageObj = new LoginPage();
        loginpageObj.LoginActions(driver);

        // HomePage Object initilization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.VerifyUserInHomePage(driver);
        homePageObj.NavigateToTMPage(driver);

        // TMpage Object initialization and definition
        TMpage tMpageObj = new TMpage();
        tMpageObj.CreateTimeRecord(driver);

        // Edit Time Record
        tMpageObj.EditTimeRecord(driver);

        // Delete Time Record
        tMpageObj.DeleteTimeRecord(driver);
        

       

        

        


    }



}