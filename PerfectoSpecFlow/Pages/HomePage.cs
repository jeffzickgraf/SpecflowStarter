
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace PerfectoSpecFlow
{
    public class HomePage
    {

		private static string PatientButton = "//*[@text='Patient'] | //*[@label='Patient']";
		private static string UsernameField = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_username_edit_text'] |  //UIAScrollView//UIATextField";

		public static void ClickPatient(AppiumDriver<IWebElement> driver)
        {
			//Ipad has no home page
			if (PerfectoUtils.IsiPad())
				return;

			if (PerfectoUtils.IsTablet())
			{
				Console.WriteLine("About to click patient link - sleep for tablet " + PerfectoHooks.CurrentDevice.DeviceDetails.Name);

				Thread.Sleep(15000);
			}

			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(25));
			driver.FindElementByXPath(PatientButton).Click();
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));
			//App sends to authenticate if haven't already authenticated after opening app

			try
			{
				if (driver.FindElementsByXPath(UsernameField).Count > 0)
				{
					Console.WriteLine("Redirected to sign in - attempt sign in " + PerfectoHooks.CurrentDevice.DeviceDetails.Name);
					SignInPage.SignIn(driver);
				}
				{
					Console.WriteLine("login screen not found " + PerfectoHooks.CurrentDevice.DeviceDetails.Name);
				}
			}
			catch (Exception)
			{	
			}
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
		}
	}
}