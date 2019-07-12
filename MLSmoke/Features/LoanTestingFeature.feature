Feature: Loan Testing
 Description: This feature will test the functionality of Loan Testing

@smoke
Scenario: Verify that approval pop up is displayed 
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	Then Approval pop up should be displayed


Scenario: Verify that comments are added
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	And User entered approval comments and saved
	And User navigated to Comments page
	Then Approval comment should be displayed under decision comments






