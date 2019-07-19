Feature: Loan Testing
 Description: This feature will test the functionality of Loan Testing
@smoke
Scenario: Verify that approval pop up is displayed 
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	Then Approval pop up should be displayed

Scenario: Verify that status changed to approved 
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	And User entered approval comments and saved
	Then Status should be changed to approved

Scenario: Verify that comments are added
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	And User entered approval comments and saved
	And User navigated to Comments page
	Then Approval comment should be displayed under decision comments

Scenario: Verify that Approval Date is displayed in status
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Approved
	And User entered approval comments and saved
	And User navigated to Status page
	Then Approval Date should be displayed in status 

Scenario: Verify that Denial Reason pop up is appearing
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Declined
	Then Denial Reason pop up should be displayed

Scenario: Verify that Status is changed to Declined
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Declined
	And User entered Denial reason and saved
	Then Status should be changed to Declined

Scenario: Verify that Denial comment is displayed in Decision Comments 
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Declined
	And User entered Denial reason and saved
	And User navigated to Comments page
	Then Denial comment should be displayed in Decision Comments

Scenario: Verify that Declined date is displayed correctly in status
	Given User login to application
	When User navigated to Credit Card application 
	And User filled all the information and saved the application
	And User changed the application status to Declined
	And User entered Denial reason and saved
	And User navigated to Status page
	Then Declined date should be displayed correctly





