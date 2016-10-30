using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace PerfectoSpecFlow
{
    public class MedicationPage
    {

		private static string RefillMedicationButton = "//*[@text='Refill a prescription'] | //*[@label='Refill a Prescription']";

		public static void ClickRefill(RemoteWebDriver driver)
        {
			do
			{
				Console.WriteLine("Wait for 5 seconds medications page to open " + PerfectoHooks.CurrentDevice.DeviceDetails.Name);
				Thread.Sleep(5000);
			} while (PerfectoUtils.OCRTextCheckPoint(driver, "Retrieving", 6));

			if (PerfectoUtils.IsTablet())
			{
				PerfectoUtils.OCRTextClick(driver, "Refill a prescription", 90, 20, 1, false, 1, false);
			}
			else
			{
				driver.FindElementByXPath(RefillMedicationButton).Click();
			}

			PerfectoUtils.RotateDevice(driver, Constants.Rotation.LANDSCAPE);
			Thread.Sleep(1000);
			PerfectoUtils.RotateDevice(driver, Constants.Rotation.PORTRAIT);
			Thread.Sleep(1000);
			PerfectoUtils.RotateDevice(driver, Constants.Rotation.LANDSCAPE);
			Thread.Sleep(1000);
			PerfectoUtils.RotateDevice(driver, Constants.Rotation.PORTRAIT);
			Thread.Sleep(1000);
		}

	}
}