using NUnit.Framework;
using PerfectoSpecFlow.Pages;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;


namespace PerfectoSpecFlow
{
    [Binding]
    public class PerfectoFeaturesSteps: PerfectoHooks
    {
        [Given(@"I launch (.*) mobile application")]
        [When(@"I launch (.*) mobile application")]
        public void GivenILaunchMobileApplication(string appName)
        {
			CloseApp(appName);
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
                case "Home":
                    switch (buttonName)
                    {
                        //case "Patient":
                        //    PerfectoUtils.OCRTextClick(driver, "Patient", 90, 20, 1);
                        //    Thread.Sleep(2000);
                        //    break;
                        case "Patient":
                            driver.Context = Constants.NATIVEAPP;
                            HomePage.ClickPatient(driver);
                            break;
                        default:
                            break;
                    }
                    break;
				case "Patient":
					switch (buttonName)
					{
						case "Medications":
							driver.Context = Constants.NATIVEAPP;
							PatientMenuPage.GoToMedicationPage(driver);
							break;
						default:
							break;
					}
					break;
				case "Medications":
					switch (buttonName)
					{
						case "Refill a Prescription":
							driver.Context = Constants.NATIVEAPP;
							MedicationPage.ClickRefill(driver);
							break;
					}
					break;
                //case "Navigation":
                //    switch (buttonName)
                //    {
                //        case "Menu":
                //            Navigation.ClickMenu(driver);
                //            break;
                //        case "Store Locator":
                //            PerfectoUtils.OCRTextClick(driver, "Complete", 90, 20, 1);
                //            Thread.Sleep(2000);
                //            Navigation.ClickStoreLocator(driver);
                //            break;
                //        default:
                //            break;
                //    }
                //    break;
               
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
			Thread.Sleep(1000);
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
