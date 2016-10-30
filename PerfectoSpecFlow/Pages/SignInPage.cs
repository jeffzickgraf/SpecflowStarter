using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace PerfectoSpecFlow
{
    public class SignInPage
    {
       
        private static string StartSignInButton = "//*[@resource-id='com.mayoclinic.patient:id/fragment_main_sign_in_button'] | //*[@resource-id='com.mayoclinic.patient:id/fragment_main_patient_sign_in_layout']//*[@class='android.widget.ImageView'] |  //*[@label='Sign In'] | //*[@label='Sign in']";

		//Something doesn't look right with the 2nd xpath
		private static string UsernameField = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_username_edit_text'] |  //UIAScrollView//UIATextField | //AppiumAUT/UIAApplication[1]/UIAWindow[1]/UIATextField[1]";
		private static string PasswordField = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_password_edit_text'] | //*[@value='Enter Password'] | //AppiumAUT/UIAApplication[1]/UIAWindow[1]/UIASecureTextField[1]";
		private static string PrivacyPolicySwitch = "//UIASwitch";
		private static string SignInButton = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_sign_in_button'] | //*[@label='Sign In']";

		private static string AuthenticatingModal = "//*[@resource-id='android:id/message']";
		public static void ClickStartSignIn(AppiumDriver<IWebElement> driver)
        {
			//PerfectoUtils.OCRTextClick(driver, "Sign In", 90, 20, 1, false, 0, true);
			driver.Context = Constants.NATIVEAPP;
			driver.FindElementByXPath(StartSignInButton).Click();
			Thread.Sleep(2000);

			//sometimes an authenticating modal appears - if so, give it some time to breath
			Console.WriteLine("Looking for Authenticating modal " + PerfectoHooks.CurrentDevice.DeviceDetails.Name);
			if (PerfectoUtils.OCRTextCheckPoint(driver, "Authenticating", 6, true))
			{
				Console.WriteLine("Found Authenticating modal, sleep for few seconds" + PerfectoHooks.CurrentDevice.DeviceDetails.Name);
				Thread.Sleep(4000);
			}
			
		}

		public static void SignIn(AppiumDriver<IWebElement> driver)
		{			
			driver.Context = Constants.NATIVEAPP;
			driver.FindElementByXPath(UsernameField).Clear();
			driver.FindElementByXPath(UsernameField).SendKeys(Constants.MAYO_USERNAME);
			driver.FindElementByXPath(PasswordField).SendKeys(Constants.MAYO_PASSWORD);
			Thread.Sleep(1000);

			if (PerfectoUtils.IsiPad())
			{
				if (PerfectoUtils.OCRTextCheckPoint(driver, "Privacy policy", 6, false))
				{
					driver.FindElementByXPath(PrivacyPolicySwitch).Click();
					Thread.Sleep(2000);
				}
			}

			driver.FindElementByXPath(SignInButton).Click();
		}


	}
}