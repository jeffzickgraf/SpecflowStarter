using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow
{
    public class MedicationPage
    {

		private static string RefillMedicationButton = "//*[@text='Refill a prescription'] | //*[@label='Refill a Prescription']";

		public static void ClickRefill(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(RefillMedicationButton).Click();
        }

	}
}