using System;
using TechTalk.SpecFlow;

namespace PerfectoSpecFlow
{
    [Binding]
    public class MedicationFeaturesSteps : PerfectoHooks
    {
        [Given(@"I am a logged in user")]
        public void GivenIAmALoggedInUser()
        {
			if (PerfectoUtils.OCRTextCheckPoint(driver, "Patient", 6))
			{
				return;
			}
			SignInPage.ClickStartSignIn(driver);
			if (PerfectoUtils.OCRTextCheckPoint(driver, "Patient", 6))
			{
				return;
			}

			SignInPage.SignIn(driver);
        }
    }
}
