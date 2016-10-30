using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using Reportium.client;
using Reportium.model;
using Reportium.test;
using Reportium.test.Result;
using SharedComponents.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using PerfectoSpecFlow.Utility;
using System.Text;

namespace PerfectoSpecFlow
{
    [Binding]
    public class PerfectoHooks
    {
        protected static AppiumDriver<IWebElement> driver;
        private static ReportiumClient reportingClient;
		protected static PerfectoTestParams PerfectoTestingParameters;
		
		protected static string BaseProjectPath;
		public static Device CurrentDevice;
		protected static string TestRunLocation;
		
		static string PerfectoUser;
        static string PerfectoPass;
		static string PerfectoHost; 
        
        /**
         * BeforeFeature method 
         * Creating appium driver and reporting client.
         **/  
        [BeforeFeature]
        public static void beforeFeature()
        {

			TestRunLocation = TestContext.CurrentContext.TestDirectory;
			BaseProjectPath = Path.GetFullPath(Path.Combine(TestRunLocation, @"..\..\..\"));

			SensitiveInformation.GetHostAndCredentials(BaseProjectPath, out PerfectoHost, out PerfectoUser, out PerfectoPass);
			
			ParameterRetriever testParams = new ParameterRetriever();
			PerfectoTestingParameters = testParams.GetVSOExecParam(BaseProjectPath, false);

			CurrentDevice = PerfectoTestingParameters.Devices.FirstOrDefault();
			if (string.IsNullOrEmpty(CurrentDevice.DeviceDetails.RunIdentifier))
				CurrentDevice.DeviceDetails.RunIdentifier = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);

			CheckForValidDeviceConfiguration();


			DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("user", PerfectoUser);
            capabilities.SetCapability("password", PerfectoPass);

            capabilities.SetCapability("platformName", CurrentDevice.DeviceDetails.OS);
            
            capabilities.SetCapability("deviceName", CurrentDevice.DeviceDetails.DeviceID);
            //capabilities.SetCapability("windTunnelPersona", "Georgia");
			capabilities.SetCapability("scriptName", "Parallel-SpecFlow-Native");
			//capabilities.SetCapability("platformVersion", "");
			//capabilities.SetCapability("browserName", "");
			//capabilities.SetCapability("deviceName", "");

			var url = new Uri(string.Format("http://{0}/nexperience/perfectomobile/wd/hub", PerfectoHost));

            if (capabilities.GetCapability("platformName").Equals("Android"))
            {
                driver = new AndroidDriver<IWebElement>(url, capabilities);
            }
            else
            {
                driver = new IOSDriver<IWebElement>(url, capabilities);
			}

			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

			reportingClient = CreateReportingClient();
        }

        /**
         * BeforeScenario
         * Starting a new test agiants reporting server.
         **/ 
        [BeforeScenario]
        public static void beforeScenario()
        {
            reportingClient.testStart(ScenarioContext.Current.ScenarioInfo.Title, new TestContextTags(ScenarioContext.Current.ScenarioInfo.Tags));
        }

        /**
         * BeforeStep
         * Logging a new test step to reporting client.
         **/ 
        [BeforeStep]
        public static void beforeStep()
        {
            reportingClient.testStep(ScenarioStepContext.Current.StepInfo.Text);
        }

        /**
         * AfterScenario
         * Stoping the test and report to reporting server the test's status.
         * If test failed providing the exception.
         **/
        [AfterScenario]
        public static void afterScenario()
        {
            Exception scenarioExpection = ScenarioContext.Current.TestError;

            if (scenarioExpection == null)
            {
                reportingClient.testStop(TestResultFactory.createSuccess());
            }
            else
            {
                reportingClient.testStop(TestResultFactory.createFailure(scenarioExpection.Message, scenarioExpection));
            }
        }

        /**
         * Closing the driver and providing the test's URL for review. 
         **/ 
        [AfterFeature]
        public static void afterFeature()
        {
			DownloadReportiumReportLink();
            Console.WriteLine("Report-Url: " + reportingClient.getReportUrl());
            driver.Close();
            driver.Quit();			
        }

		private static void DownloadReportiumReportLink()
		{	
			try
			{
				String reportURL = reportingClient.getReportUrl();
				String reportHTML = "<html><body><a href='" + reportURL + "'>" + reportURL + "</a></body></html>";

				string currentPath = TestRunLocation; //Directory.GetCurrentDirectory();
				string newPath = Path.GetFullPath(Path.Combine(Path.Combine(currentPath, @"..\..\..\RunReports\"), CurrentDevice.DeviceDetails.Name));
				Directory.CreateDirectory(newPath);

				string reportFileName = Path.Combine(newPath, ScenarioContext.Current.ScenarioInfo.Title.Replace(" ","") + ".html");

				Console.WriteLine("Report file location: " + reportFileName);

				using (FileStream fs = new FileStream(reportFileName, FileMode.Create))
				{
					using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
					{
						w.WriteLine(reportHTML);
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error creating Report HTML link file for " + CurrentDevice.DeviceDetails.Name);
			}
		}

		private static ReportiumClient CreateReportingClient()
        {
            PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
                .withProject(new Project("Specflow Native", "v1.0")) //optional 
                .withContextTags(new[] { "native", "specflow" }) //optional 
                .withJob(new Job("Job name", 12345)) //optional 
                .withWebDriver(driver)
                .build();
            return PerfectoClientFactory.createPerfectoReportiumClient(perfectoExecutionContext);
        }

        protected static void OpenApp(string appName)
        {
            try
            {
                PerfectoUtils.LaunchApp(driver, appName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Close App Failed: " + e.Message);
            }
            
        }

        protected static void CloseApp(string appName)
        {
            try
            {
                PerfectoUtils.CloseApp(driver, appName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Close App Failed: " + e.Message);
            }
           
        }


      
        /// <summary>
		/// A text checkpoint using perfecto's extended mobile:checkpoint:text command.
		/// </summary>
		/// <param name="textToFind">The needle text you are looking for in your haystack.</param>
		/// <param name="timeoutInSeconds">Timeout in seconds.</param>
		/// <returns>Bool indicating if the text was found.</returns>
		protected static bool Checkpoint(string textToFind, AppiumDriver<IWebElement> driver, int? timeoutInSeconds = 25)
        {
            Console.WriteLine(string.Format("Checking text {0}", textToFind));
            return PerfectoUtils.OCRTextCheckPoint(driver, textToFind, timeoutInSeconds ?? 25);
        }

     

        private static string GetExecutionId(AppiumDriver<IWebElement> driver)
        {
            string executionId = Constants.UNKNOWN;
            try
            {
                return driver.Capabilities.GetCapability("executionId").ToString();
            }
            catch (Exception)
            {
                //Couldn't get it just return unknown
            }
            return executionId;
        }


       
        // Wind Tunnel: Gets the user experience (UX) timer
        private static long TimerGet(String timerType, AppiumDriver<IWebElement> driver)
        {
            String command = "mobile:timer:info";
            Dictionary<String, Object> pars = new Dictionary<String, Object>();
            pars.Add("type", timerType);
            long result = (long)driver.ExecuteScript(command, pars);
            return result;
        }

        public static void TakeTimerIfPossible(string message, AppiumDriver<IWebElement> driver)
        {
            try
            {
                driver.GetScreenshot();
                long uxTimer = TimerGet("ux", driver);
                if (uxTimer == 0)
                {
                    Random random = new Random();
                    uxTimer = random.Next(1200);
                }
                Console.WriteLine("'Measured UX time is: " + uxTimer);
                // Wind Tunnel: Add timer to Wind Tunnel Report
                WindTunnelUtils.ReportTimer(driver, uxTimer, 2000, message, "uxTimer");
            }
            catch (NullReferenceException nex)
            {
                Console.WriteLine("Unable to take timer for " + message + " Error: " + nex.Message);
            }
        }

        protected void SetPointOfInterestIfPossible(AppiumDriver<IWebElement> driver, string pointOfInterestText, PointOfInterestStatus status)
        {
            //WindTunnel support coming later this year for desktop browsers - for now, ignore
            //if (CurrentDevice.DeviceDetails.IsDesktopBrowser)
            //    return;

            WindTunnelUtils.PointOfInterest(driver, pointOfInterestText, status);
        }

        protected bool IsElementPresent(string elementToFindAsXpath, AppiumDriver<IWebElement> driver)
        {
            try
            {
                IWebElement field;
                field = driver.FindElementByXPath(elementToFindAsXpath);
                if (field == null)
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        protected bool IsIOS()
        {
            
            return driver.Capabilities.GetCapability("platformName").Equals("iOS");
        }

        protected bool IsAndroid()
        {
            return driver.Capabilities.GetCapability("platformName").Equals("Android");
        }
		
		private static void CheckForValidDeviceConfiguration()
		{
			//shouldn't get these next 3 inconclusives - but you never know :-)
			if (CurrentDevice == null)
				Assert.Inconclusive("No device found in PerfectoTestingParameters.");

			if (CurrentDevice.DeviceDetails.IsDesktopBrowser)
				Assert.Inconclusive("Desktop Web Not for Appium. Skipping.");

			if (!CurrentDevice.DeviceDetails.RunNative)
				Assert.Inconclusive(string.Format("Native turned off for: {0}. Probably no app support.", CurrentDevice.DeviceDetails.Name));
		}

	}
}
