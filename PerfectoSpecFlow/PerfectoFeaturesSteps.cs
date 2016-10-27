using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;


namespace PerfectoSpecFlow
{
    [Binding]
    public class PerfectoFeaturesSteps: PerfectoHooks
    {
        [Given(@"I install (.*) mobile application")]
        [When(@"I install (.*) mobile application")]
        public void GivenIInstallMobileApplication(string appName)
        {
            if (IsAndroid())
            {
                try
                {
                    Dictionary<string, object> param100 = new Dictionary<string, object>();
                    param100.Add("file", "PUBLIC:CVS\\com.cvs.launchers.cvs-1.apk");
                    param100.Add("instrument", "noinstrument");
                    param100.Add("cameraInstrument", "camera");
                    driver.ExecuteScript("mobile:application:install", param100);
                }
                catch { }
            
            }
            else if (IsIOS())
            {

            }
            Thread.Sleep(90000);


        }

        [Given(@"I launch (.*) mobile application")]
        [When(@"I launch (.*) mobile application")]
        public void GivenILaunchMobileApplication(string appName)
        {
            OpenApp(appName);
            //driver.Context = Constants.VISUAL;
            Thread.Sleep(1000);
         

        }
        [Given(@"I click (.*) on the (.*) popup")]
        [When(@"I click (.*) on the (.*) popup")]
        [Then(@"I click (.*) on the (.*) popup")]

        public void GivenPopup(string action, string popupName)
        {
            
            //driver.Context = Constants.VISUAL;
            if (Checkpoint(popupName, driver, 20))
            {

                PerfectoUtils.OCRTextClick(driver, action, 90, 20, 2);
                Thread.Sleep(1000);
            }

        }

        [Given(@"I click (.*) on the (.*) page")]
        [When(@"I click (.*) on the (.*) page")]
        [Then(@"I click (.*) on the (.*) page")]
        public void GivenIClick(string buttonName, string pageName)
        {
            Thread.Sleep(2000);

            if (IsAndroid())
            {
                switch (pageName)
                {
                    case "Popup":
                        switch (buttonName)
                        {
                            case "OK":
                                if (Checkpoint("OK", driver, 20))
                                {
                                    driver.Context = Constants.NATIVEAPP;
                                    driver.FindElementByXPath("//*[@resource-id='android:id/button1']").Click();
                                }
                                break;
                            case "Yes":
                                if (Checkpoint("Yes", driver, 20))
                                {
                                    driver.Context = Constants.NATIVEAPP;
                                    driver.FindElementByXPath("//*[@resource-id='android:id/button1']").Click();
                                }
                                break;
                            case "No":
                                if (Checkpoint("No", driver, 20))
                                {
                                    driver.Context = Constants.NATIVEAPP;
                                    driver.FindElementByXPath("//*[@resource-id='android:id/button2']").Click();
                                }
                                break;
                            case "Allow":
                                PerfectoUtils.OCRTextClick(driver, "Allow", 90, 20, 2);
                                break;
                            case "Cancel":
                                PerfectoUtils.OCRTextClick(driver, "Cancel", 90, 20, 1);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Launch":
                        switch (buttonName)
                        {
                            case "Not Now":
                                driver.Context = Constants.NATIVEAPP;
                                driver.FindElementByXPath("//*[@resource-id='com.cvs.launchers.cvs:id/notNowTextView']").Click();
                                break;
                            case "Sign In":
                                driver.Context = Constants.NATIVEAPP;
                                driver.FindElementByXPath("//*[@resource-id='com.cvs.launchers.cvs:id/btnSignIn']").Click();
                                break;
                            case "Create Account":
                                driver.Context = Constants.NATIVEAPP;
                                driver.FindElementByXPath("//*[@resource-id='com.cvs.launchers.cvs:id/btnCreateAccount']").Click();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Home":
                        switch (buttonName)
                        {
                            case "Tap this":
                                PerfectoUtils.OCRTextClick(driver, "Tap", 90, 20, 1);
                                Thread.Sleep(2000);
                                break;
                            case "Link Your Card":
                                driver.Context = Constants.NATIVEAPP;
                                HomePage.ClickLinkYourCard(driver);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Navigation":
                        switch (buttonName)
                        {
                            case "Menu":
                                Navigation.ClickMenu(driver);
                                break;
                            case "Store Locator":
                                PerfectoUtils.OCRTextClick(driver, "Complete", 90, 20, 1);
                                Thread.Sleep(2000);
                                Navigation.ClickStoreLocator(driver);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Store Locator":
                        switch (buttonName)
                        {
                            case "Use My Location":
                                PerfectoUtils.OCRTextClick(driver, "Complete", 90, 20, 1);
                                Thread.Sleep(2000);
                                StoreLocatorPage.ClickUseMyLocation(driver);
                                break;
                            case "24 Hour Pharmacy Checkbox":
                                driver.Context = Constants.NATIVEAPP;
                                Thread.Sleep(2000);
                                StoreLocatorPage.Check24hrPharmCheckbox(driver);
                                break;
                            case "Pharmacy Checkbox":
                                driver.Context = Constants.NATIVEAPP;
                                Thread.Sleep(2000);
                                StoreLocatorPage.CheckPharmacyCheckbox(driver);
                                break;
                            case "Find a Store":
                                driver.Context = Constants.NATIVEAPP;
                                Thread.Sleep(2000);
                                StoreLocatorPage.ClickFindAStore(driver);
                                break;
                            case "Store Details":
                                driver.Context = Constants.NATIVEAPP;
                                Thread.Sleep(2000);
                                StoreLocatorPage.ClickStoreDetails(driver);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "ExtraCare Card":
                        switch (buttonName)
                        {
                            case "View My Deals & Rewards":
                                driver.FindElementByXPath("//*[@resource-id='com.cvs.launchers.cvs:id/showDealsDragDowntv']").Click();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Your Deals & Rewards":
                        switch (buttonName)
                        {
                            case "Remove ExtraCare Card":
                                PerfectoUtils.Swipe(driver, "50%,80%", "50%,30%");
                                Thread.Sleep(1000);
                                PerfectoUtils.Swipe(driver, "50%,80%", "50%,30%");
                                Thread.Sleep(1000);
                                PerfectoUtils.Swipe(driver, "50%,80%", "50%,30%");
                                Thread.Sleep(1000);
                                PerfectoUtils.Swipe(driver, "50%,80%", "50%,30%");
                                Thread.Sleep(1000);
                                PerfectoUtils.OCRTextClick(driver, "Remove ExtraCare Card", 90,0,1, true);
                                Thread.Sleep(1000);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;

                }
            }
            if (IsIOS())
            {

            }
            Thread.Sleep(1000);
        }

        [When(@"I scan (.*) barcode")]
        public void WhenIScanBarcode(string barcode)
        {
            if (IsAndroid())
            {
                Dictionary<string, object> params4 = new Dictionary<string, object>();
                params4.Add("repositoryFile", "PUBLIC:CVS\\Barcode_CVS.png");
                params4.Add("name", "CVS");
                driver.ExecuteScript("mobile:image.injection:start", params4);
            }   
        }

        [Given(@"I validate (.*) text is on the screen")]
        [When(@"I validate (.*) text is on the screen")]
        [Then(@"I validate (.*) text is on the screen")]
        public void ThenIValidateText(string val)
        {
            driver.Context = Constants.VISUAL;
            Assert.IsTrue(Checkpoint(val, driver));
        }
    }
}
