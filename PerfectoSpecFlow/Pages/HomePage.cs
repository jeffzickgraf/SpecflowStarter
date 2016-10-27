using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow
{
    public abstract class HomePage
    {
       
        private static string LinkYourCardButton = "//*[@resource-id='com.cvs.launchers.cvs:id/ecCard']";
       

        public static void ClickLinkYourCard(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(LinkYourCardButton).Click();
        }

       
    }
}