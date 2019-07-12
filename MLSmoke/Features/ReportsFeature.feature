Feature: Reports
Description: This feature will test the Reports functionality

@smoke
Scenario: Custom Report designer 
	Given User login to application
	And User navigated to Reports page
	When User designed a custom report for Credit Score
	Then User verified Credit Score custom report creation

Scenario: Running Pre-built reports for Credit Score
	Given User login to application
	And User navigated to Reports page
	And User selected Pre-built Credit Score reports
	When User ran Pre-built reports 
	Then User verified Pre-built Credit Score reports
