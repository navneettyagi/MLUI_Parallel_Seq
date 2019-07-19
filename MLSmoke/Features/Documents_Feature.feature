Feature: Documents_Feature
	Description: This feature will test the Document functionality

@smoke
Scenario: Verify the Printing of Docs For Banker System
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And User Attached document
	 And User Click on Display Link of the uploaded document
     Then Print button Should be displayed in the Print Preview Window

Scenario: Verify the Attaching of PDF Document less than 4mb
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And User Attached document
     Then The same PDF document should be displayed in the scanned /Uploaded documents

Scenario: Verify the Attaching of PDF Document more than 4mb
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And User Attached pdf document of more than 4mb 
     Then Pop Up should be displayed as the file you are transferring is too big

Scenario: Verify the visibility of the document to the consumer
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And User Attached document
	 And Click on show consumer link of the uploaded document  coming in the scanned/uploaded document
     Then YES should be displayed In the consumer column of the uploaded document present in the Scanned / uploaded Documents section

Scenario: Verify the sharing of the PDF document on the generated URL 
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload the PDF document less than 3.91 mb
     Then The same PDF document should be displayed in the scanned /Uploaded documents

Scenario: Verify the PDF document of more than 3.91mb must not be shared on the generated URL 
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload the PDF document of more than 3.91 mb
     Then The file you are transferring is too big Max file size is 3.91MB Message should be there

Scenario: Verify the JPG document must not be shared on the generated URL 
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload the JPG document 
     Then File type of JPG not allowed Message should be there

Scenario: Verify the five PDF document must be shared on the generated URL  
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload five PDF documents
	 And Close the file share page
	 And Refresh the Letter docs page
     Then All the five PDF document should be displayed in the scanned /Uploaded documents
	 
Scenario: Verify the PNG document must not be shared on the generated link 
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload the PNG Document
     Then File type of PNG not allowed Message should be there should be there

Scenario: Verify the six PDF document must not be shared on the generated link 
	 Given User Login successfully
     When User selects Vehicle APP 
	 And User navigates to letter docs
	 And Copy the generated URL
	 And Open the generated URL 
	 And Upload five PDF documents
     Then Upload Document button should not be there after uploading five PDFs document

Scenario: Verify the multiple PDF should be displayed at the same time 
	 Given User Login successfully
     When User navigates to letter docs templates
	 And User Add PDF in the vehicle module
	 And User selects Vehicle APP
	 And User Creates a new Vehicle APP
	 And User check the multiple pdf and click on display 
     Then Checked PDFs should be displayed

Scenario: Verify the PDFs should be saved as incomplete PDF
	 Given User Login successfully
     When User navigates to letter docs templates
	 And User Add PDF in the vehicle module
	 And User selects Vehicle APP
	 And User Creates a new Vehicle APP
	 And User check the multiple pdf and click on display 
     Then PDFs should be available in Incomplete PDF 

Scenario: Verify the PDF should be open through NG Mapper
	 Given User Login successfully
     When User navigates to letter docs templates
	 And User Add PDF in the vehicle module
	 And User Opens the PDF document in NG Mapper
     Then PDF document should be opened in PDF Mapper
