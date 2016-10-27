using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow
{
    public abstract class Navigation
    {
        private static string MenuButton =  "//*[@resource-id='com.cvs.launchers.cvs:id/imageButton']";
        private static string StoreLocatorButton = "//*[@text='Store Locator']";


        public static void ClickMenu(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(MenuButton).Click();
        }

        public static void ClickStoreLocator(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(StoreLocatorButton).Click();
        }

    }
}
