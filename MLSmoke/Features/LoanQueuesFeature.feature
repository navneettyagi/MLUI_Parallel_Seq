Feature: LoanQueuesFeature
	
@mytag: This feature file test the functionality of Loan Queues
Scenario: To verify Test ConditionSet against an app link is displaying 
	Given User login to application
	When User navigated to custom app queues
	And User clicked filters link
	And User added a condition
	Then A link should be displayed as Test ConditionSet against an app

Scenario: To verify ConditionSet: True is displaying
	Given User login to application
	When User created a new credit card application and navigated to custom app queues
	And User clicked filters link
	And User added a condition
	And User entered valid credit card app number and tested
	Then Condtion Set: True should be displayed

Scenario: To verify ConditionSet: False is displaying
	Given User login to application
	When User created a new Vehicle Loan application and navigated to custom app queues
	And User clicked filters link
	And User added a condition
	And User entered invalid credit card app number and tested
	Then Condtion Set: False should be displayed

Scenario: To verify pop up window has same App ID
	Given User login to application
	When User clicked on assign icon of an application
	Then Same App ID should be displayed on pop up window

Scenario: To verify working queue message with assigned officer's name
	Given User login to application
	When User clicked on assign icon of an application
	And User verified the same appID on pop up window
	And User assigned to an officer with a comment
	Then Message should be displayed as Application added to queues with the officers name

Scenario: To verify working queue assigned officer's name
	Given User login to application
	When User clicked on assign icon of an application
	And User verified the same appID on pop up window
	And User assigned to an officer with a comment
	And User clicked on icon of Users with this App in Their Queue
	Then Working queue Officer's name should be displayed