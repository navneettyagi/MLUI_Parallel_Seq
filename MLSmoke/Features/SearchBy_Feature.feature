Feature: SearchBy_Feature
	Description: This feature will test the Search Page functionality

@smoke
Scenario: Verify the loading of APP with valid APP number
	 Given User Login successfully 	 
     When User Created a new Vehicle Loan APP 
	 And User selects the Loan APP Number from the drop down
	 And User enters valid APP number and Click Search 
     Then Same APP number should be displayed in the loaded Application

Scenario: Verify the loading of APP with invalid APP number
	 Given User Login successfully
     When User selects the Loan APP Number from the drop down
	 And User enters invalid APP number and Click Search 
     Then Pop up should be displayed as No Results found


	