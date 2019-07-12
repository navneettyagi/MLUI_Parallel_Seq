Feature: Underwriting
	Description: This feature will test Underwriting page functionality.

@smoke
Scenario: Verify the functionality of Ordering credit with valid SSN
	 Given User Login successfully
	 When User selects Vehicle from New App menu
	 And User fills applicant form with valid data and click on Pull Credit and Save button
	 And User clicks on View Credit link from navigation panel
	 Then Credit Report values should be displayed in the report

Scenario: Verify that NA is not displaying in Underwirting information
	 Given User Login successfully
	 When User selects Vehicle from New App menu
	 And User fills applicant form with valid data and click on Pull Credit and Save button
	 And User clicks on Accept button of 36 mo NEW EXAMPLE loan
	 Then Scroll the page down and Verify that NA is not displaying in Underwriting Information

