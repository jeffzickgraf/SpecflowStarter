@AppiumTests
Feature: PerfectoFeatures
	In order to validate PerfectoCode repository title,
	We need to navigate to Google and search for the repository.

Scenario: Install Mobile Application
	Given I install CVS mobile application


Scenario: Launch Mobile Application
	When I launch CVS mobile application
	And I click Allow on the Popup page  
	Then I validate Create Account text is on the screen

Scenario: Navigate to Home Page without signing in
	When I click Not Now on the Launch page
	Then I validate Pharmacy text is on the screen
	And I click Tap this on the Home page

Scenario: Scan valid ExtraCare card
	Given I click Link Your Card on the Home page
	And I click Allow on the Popup page 
	When I scan ExtraCare barcode
	Then I validate 4763596295583 text is on the screen
	And I click Yes on the Popup page 
	And I click OK on the Popup page
	And I click Cancel on the Popup page

Scenario: Remove ExtraCare card
	Given I click Link Your Card on the Home page
	And I click View My Deals & Rewards on the ExtraCare Card page  
	When I click Remove ExtraCare Card on the Your Deals & Rewards page  
	And I click Yes on the Popup page
	Then I validate We've removed your ExtraCare text is on the screen
	And I click OK on the Popup page

Scenario: Store Locator
	Given I click Menu on the Navigation page
	And I click Store Locator on the Navigation page  
	And I validate FILTER BY SERVICES text is on the screen
	When I click 24 Hour Pharmacy Checkbox on the Store Locator page  
	And I click Pharmacy Checkbox on the Store Locator page  
	And I click Find a Store on the Store Locator page
	And I click Store Details on the Store Locator page
	Then I validate PHARMACY OPEN 24 HOURS text is on the screen



#@Tag1 @Tag2
#Scenario: Navigating to Google and search for PerfectoCode
#	Given I navigate to google search page
#	And I search for PerfectoCode GitHub
#	When I click the first search result 
#	Then I validate that Perfecto is in the page's title 
