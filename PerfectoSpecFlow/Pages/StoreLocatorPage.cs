using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace PerfectoSpecFlow
{
    public abstract class StoreLocatorPage
    {
        private static string UseMyLocationButton = "//*[@content-desc='Use My Location']";
        private static string TwentyFourHrPharmCheckbox = "//*[@resource-id='Rx24_Flag' and @class='android.view.View']";
        private static string PharmacyCheckbox = "//*[@resource-id='Rx_Flag' and @class='android.view.View']";
        private static string FindAStoreButton = "//*[@resource-id='find_a_store_mobile']";
        private static string StoreDetailsButton = "//*[@content-desc='Store Details Get directions to this store.']";
        public static void Check24hrPharmCheckbox(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(TwentyFourHrPharmCheckbox).Click();
        }

        public static void CheckPharmacyCheckbox(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(PharmacyCheckbox).Click();
        }

        public static void ClickUseMyLocation(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(UseMyLocationButton).Click();
        }

        public static void ClickFindAStore(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(FindAStoreButton).Click();
        }

        public static void ClickStoreDetails(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(StoreDetailsButton).Click();
        }
    }
}
