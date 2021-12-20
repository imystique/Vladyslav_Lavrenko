Feature: Dropbox API

Scenario: Upload_Get_Delete
	Given I have a file
	When I upload file to Dropbox
	Then The file should be uploaded on Dropbox
	When I request a file metadata by id
	Then I should get File Name
	When I delete file from Dropbox
	Then File should not exist
