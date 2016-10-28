using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow.Pages
{
	public static class PatientMenuPage
	{
		private static string PatientHeader = "//*[@label='Patient'] | //*[@text='Patient']";
		private static string MedicationButton = "//*[@text='Medications'] | //*[@label='Medications']";

		public static void ValidateOnPatientHeader(RemoteWebDriver driver)
		{
			Assert.IsNotNull(driver.FindElementByXPath(PatientHeader));
		}

		public static void GoToMedicationPage(RemoteWebDriver driver)
		{
			driver.FindElementByXPath(MedicationButton).Click();
		}
	}
}
