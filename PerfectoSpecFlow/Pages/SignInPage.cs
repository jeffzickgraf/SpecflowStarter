using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace PerfectoSpecFlow
{
    public class SignInPage
    {
       
        private static string StartSignInButton = "//*[@label='Sign In'] | //*[text()='Sign In']";

		//Something doesn't look right with the 2nd xpath
		private static string UsernameField = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_username_edit_text'] |  //UIAScrollView//UIATextField";
		private static string PasswordField = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_password_edit_text'] | //*[@value='Enter Password']";
		private static string SignInButton = "//*[@resource-id='com.mayoclinic.patient:id/fragment_login_sign_in_button'] | //*[@label='Sign In']";

		public static void ClickStartSignIn(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(StartSignInButton).Click();
        }

		public static void SignIn(RemoteWebDriver driver)
		{
			driver.FindElementByXPath(UsernameField).Clear();
			driver.FindElementByXPath(UsernameField).SendKeys(Constants.MAYO_USERNAME);
			driver.FindElementByXPath(PasswordField).SendKeys(Constants.MAYO_PASSWORD);
			Thread.Sleep(1000);
			driver.FindElementByXPath(SignInButton).Click();
		}


	}
}