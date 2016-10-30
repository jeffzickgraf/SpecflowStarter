@AppiumTests
Feature: MedicationFeatures
	While using the Mayo Clinic App as a user, I want to be able to view and order medications.

Scenario: TC 19403 Order Medications
	Given I launch Mayo Clinic mobile application
	And I am a logged in user
	And I click Patient on the Home page 
	And I click Medications on the Patient Menu page   
	When I click Refill a Prescription on the Medications page
	Then I validate Pharmacy text is on the screen




#@Tag1 @Tag2
#Scenario: Navigating to Google and search for PerfectoCode
#	Given I navigate to google search page
#	And I search for PerfectoCode GitHub
#	When I click the first search result 
#	Then I validate that Perfecto is in the page's title 
