Feature: Reports

@smoke
Scenario: Custom Report designer 
	Given User login to application
	And User navigated to Reports page
	When User designed a custom report for Credit Score
	Then Custom report should be created as Test Amount Approved

Scenario: Running Pre-built reports for Credit Score
	Given User login to application
	And User navigated to Reports page
	And User selected Pre-built Credit Score reports
	When User ran Pre-built reports 
	Then Pre-built Credit Score reports should be displayed
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Credit Score of Vehicle Loan
	Given User login to application
	And User navigated to Reports page
	And User selected pre-built Credit Score Reports for Vehicle Loan
	When User ran Pre-built reports 
	Then Pre-built Vehicle Loan Credit Score reports should be displayed
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Approved Loans
	Given User login to application
	And User navigated to Reports page
	And User selected Approved Loans Pre-built reports
	When User ran Pre-built reports
	Then Pre-built reports for Approved Loans should be displayed
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Branch Activities
	Given User login to application
	And User navigated to Reports page
	And User selected Branch Activities Pre-built reports
	When User ran Pre-built reports
	Then User verified Branch Activities Pre-built reports
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Branch Activities of Mortgage Loan
	Given User login to application
	And User navigated to Reports page
	And User selected Branch Activities Pre-built reports for Mortgage Loan
	When User ran Pre-built reports
	Then User verified Branch Activities Pre-built reports for Mortgage Loan
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Dealership Production
	Given User login to application
	And User navigated to Reports page
	And User selected Dealership Production Pre-built reports
	When User ran Pre-built reports
	Then User verified Dealership Production Pre-built reports
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Funded Loans
	Given User login to application
	And User navigated to Reports page
	And User selected Funded Loans Pre-built reports
	When User ran Pre-built reports
	Then User verified Funded Loans Pre-built reports
	And Current month reports should be displayed

Scenario: Running Pre-built reports for Funding Source
	Given User login to application
	And User navigated to Reports page
	And User selected Funding Source Pre-built reports
	When User ran Pre-built reports
	Then User verified Funding Source Pre-built reports
	And Current month reports should be displayed

Scenario: Custom Report Test Amount Approved 
	Given User login to application
	And User navigated to Reports page
	And User designed a custom report as Amount Approved
	When User ran Amount Approved custom report 
	Then User verified Amount Approved custom report
	And Current month reports should be displayed for Custom Report
	
