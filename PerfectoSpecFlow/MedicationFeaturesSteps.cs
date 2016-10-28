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
			SignInPage.ClickStartSignIn(driver);
			SignInPage.SignIn(driver);
        }
    }
}
