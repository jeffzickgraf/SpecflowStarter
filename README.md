## Reporting SpecFlow

This project demonstrates adding reporting client using [Reporting SDK for C#](https://www.nuget.org/packages/Perfecto-Reporting) to your SpecFlow tests.


:information_source: This project requires [Perfecto Reporting SDK](https://github.com/PerfectoCode/Samples/wiki) for C#.


The project contains three main files:<br/>
[PerfectoHooks](PerfectoSpecFlow/PerfectoHooks.cs) - Contains the configuration required in order to execute test using reporting client.<br/>
[PerfectoFeatures](PerfectoSpecFlow/PerfectoFeatures.feature) - Standard SpecFlow feature file, conatins BDD scenario and steps. <br/>
[PerfectoFeaturesSteps](PerfectoSpecFlow/PerfectoFeaturesSteps.cs) - C# implementation of the steps in the feature file. 

**TODO:**

- Make sure you have installed the [Perfecto plugin for Visual Studio](https://www.perfectomobile.com/ni/resources/downloads/add-ins-plugins-and-extensions) and [Reporting SDK for C#](https://www.nuget.org/packages/Perfecto-Reporting).
- Download the project and import the .sln file to Visual Studio IDE.
- See below how to set your Perfecto lab User, Password and Host in an appSettings.config file. 

     - Run the tests as SpecFlow tests.<br/>
Once the test run is complete, the report URL can be found in the test output.<br/>


This project requires the use of Visual Studio 2015 or Visual Studio 2013.

This project requires the consumer to add an appsettings.config file next to the app.config file in the PerfectoSpecFlow folder that will contain your credentials, the target Perfecto cloud, and whether wind tunnel is enabled. The filename appsettings.config has been added to the .gitignore file to prevent credentials from being accidently committed to source control.

```sh
<appSettings>
		<add key="PerfectoCloud" value="YOUR-CLOUD"/> 
		<add key="PerfectoUsername" value="YOUR-USERNAME"/>
		<add key="PerfectoPassword" value="YOUR-PASSWORD"/>		
		<add key="IsWindTunnelEnabled" value="true"/> <!-- if you have access to wind tunnel set to true, otherwise false. -->
</appSettings>
```

See the [Read-Me-For-Configuration.txt file for more details]VSTSDigitalDemoTests/Read-Me-For-Configuration.txt).


Additionally, you will need to provide your device identifiers in the SharedComponents/TestResources/DevicesGroup/ files.
```sh
 //TODO: Provide your device IDs eg. 125157DF53B1BA11F
 "devices": [    
    {
      "device": {
        "os": "windows",
        "osVersion": "7",
        "browserName": "Chrome",
        "browserVersion": "49",
        "name": "chrome",
        "isDesktopBrowser": "true"
      }
    },
    {
      "device": {
        "deviceID": "CA7EEEAADD92242C66A32807B538BDACFAA5A0DB",
        "os": "iOS",
        "name": "iPhone6s",
         "isDesktopBrowser": "false"
      }
    },
```

If using VSTS or TFS to kick off the ParallelDeviceExecutor, there is a Powershell script called RunExecutor.ps1 under the ParallelDeviceExecutor folder. This can be executed while passing in the following arguments:
param([String] $assemblies = "", [String] $baselocation="C:\a\1\s\")

To call with named parameters, use the following (note: end the baselocation with a '\' at the end):
```sh
RunExecutor.ps1 -assemblies "Your-Target-Test-Assembly.dll, Another-Assembly.dll" -baselocation "D:\your\working\build\directory\"