@NativeFeature
Feature: PerfectoNativeFeatures
	In order to validate PerfectoCode repository title,
	We need to navigate to Google and search for the repository.

Scenario: 2nd feature Install Mobile Application
	Given I install JeffApp mobile application


Scenario: 2nd feature Launch Mobile Application
	When I launch JeffApp mobile application
	And I click Allow on the Popup page  
	Then I validate Create Account text is on the screen


#@Tag1 @Tag2
#Scenario: Navigating to Google and search for PerfectoCode
#	Given I navigate to google search page
#	And I search for PerfectoCode GitHub
#	When I click the first search result 
#	Then I validate that Perfecto is in the page's title 
