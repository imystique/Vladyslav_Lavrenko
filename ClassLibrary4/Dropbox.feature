Feature: Dropbox API

Scenario: A_Upload file
	Given I have a file called Test.txt
	When I upload file Test.txt to Dropbox
	Then I should get Status Code OK

Scenario: B_Get metadata
	Given I have an uploaded file Test.txt
	When I request a file Test.txt metadata by id
	Then I should get Status Code OK

Scenario: C_Delete file
	Given I have an uploaded file Test.txt
	When I delete file Test.txt from Dropbox
	Then I should get Status Code OK
