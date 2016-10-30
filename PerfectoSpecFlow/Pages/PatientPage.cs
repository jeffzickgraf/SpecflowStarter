using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow.Pages
{
	public static class PatientPage
	{
		private static string PatientPageHeader = "";
		

		public static void ValidateOnPatientPage(AppiumDriver<IWebElement> driver)
		{
			Assert.IsNotNull(driver.FindElementByXPath(PatientPageHeader));
		}

	}
}
