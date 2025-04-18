using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TurnUpPortal.Utilites;

namespace TurnUpPortal.Pages
{
    public class TMpage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //  Click on Create New button
            IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            CreateNewButton.Click();

            // Identify Dropdown  and select Time option
            IWebElement timeDropdownOPtion = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            timeDropdownOPtion.Click();
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Type code in code Textbox
            IWebElement codeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeTextbox.SendKeys("123A");

            // Type description in description text box
            IWebElement descriptionTextBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextBox.SendKeys("This is my first Time Order");

            // **Type price in price Text box Note:Below code line extra due to overlapping code
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();
            IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            priceTextBox.SendKeys("12");
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 2);
            // Click on Save Button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(9000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 9);
            // SCheck if Time Record is created successfully or not 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(5000);
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
        public void EditTimeRecord(IWebDriver driver)
        {  //  put code for EditTime Record here 
             }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            // put code for Delete Time Reecord here
        }
    }
}
