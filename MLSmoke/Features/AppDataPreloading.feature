Feature: AppDataPreloading
	Test :: Application Data Preloading-Last Applied Warning

@smoke
Scenario: Verify Last Applied Warning with the existing Member Number
	Given Navigate to Vehicle loan
	When Existing Member number is added
	Then Last Applied Warning message should be displayed

Scenario: Verify Last Applied Warning with the New Member Number
	Given Navigate to Vehicle loan
	When New Member number is added
	Then Last Applied Warning message should not be displayed

Scenario: Verify Last Applied Warning with Valid SSN
	Given Navigate to Vehicle loan
	When Enter a valid SSN
	Then Last Applied SSN Warning message should be displayed

Scenario: Verify Last Applied Warning with Invalid SSN
	Given Navigate to Vehicle loan
	When Enter an invalid SSN
	Then Popup for invalid SSN is captured