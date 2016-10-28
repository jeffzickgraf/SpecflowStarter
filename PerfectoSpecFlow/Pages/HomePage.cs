using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace PerfectoSpecFlow
{
    public class HomePage
    {

		private static string PatientButton = "//*[@text='Patient'] | //*[@label='Patient']";

		public static void ClickPatient(RemoteWebDriver driver)
        {
            driver.FindElementByXPath(PatientButton).Click();
        }


		/*
button.startsignin = xpath=//*[text()="Sign In"]
login.user = xpath=//*[@resource-id='com.mayoclinic.patient:id/fragment_login_username_edit_text'] |  //UIAScrollView//UIATextField
login.password = xpath=//*[@resource-id='com.mayoclinic.patient:id/fragment_login_password_edit_text'] | //*[@value='Enter Password']
button.signin = xpath=//*[@resource-id='com.mayoclinic.patient:id/fragment_login_sign_in_button'] | //*[@label='Sign In']

startpage.patientlink = xpath=
patient.header = xpath=//*[@label='Patient'] | //*[@text='Patient']
medications.button = xpath=//*[@text='Medications'] | //*[@label='Medications']
refill.button = xpath=//*[@text='Refill a prescription'] | //*[@label='Refill a Prescription']
		 * */


	}
}