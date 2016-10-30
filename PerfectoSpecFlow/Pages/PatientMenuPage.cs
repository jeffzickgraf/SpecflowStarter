using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace PerfectoSpecFlow.Pages
{
	public static class PatientMenuPage
	{
		private static string PatientMenuHeader = "//*[@label='Patient'] | //*[@text='Patient']";
		private static string MedicationButton = "//*[@text='Medications'] | //*[@label='Medications']";

		public static void ValidateOnPatientHeader(AppiumDriver<IWebElement> driver)
		{
			Console.WriteLine("Looking for Put Your Health splash screen " + PerfectoHooks.CurrentDevice.DeviceDetails.Name );
			//App Opens a splash screen sometimes 
			if(PerfectoUtils.IsiOS() && PerfectoUtils.OCRTextCheckPoint(driver, "Put Your Health", 8, false))
			{
				Thread.Sleep(4000);
				PerfectoUtils.OCRTextClick(driver, "Close", 90, 6, 1, false, 1, true);
				Thread.Sleep(2000);
			}

			if (PerfectoUtils.IsTablet())
				Thread.Sleep(5000);
			
			Assert.IsNotNull(driver.FindElementByXPath(PatientMenuHeader));
		}

		public static void GoToMedicationPage(AppiumDriver<IWebElement> driver)
		{
			if(PerfectoUtils.IsTablet())
				driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(25));
						
			driver.FindElementByXPath(MedicationButton).Click();
			
		}
	}
}
