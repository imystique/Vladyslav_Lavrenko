Feature: WebUI

Scenario: WebUI_Test
	Given I navigate to the "https://opensource-demo.orangehrmlive.com/index.php/auth/login" page
	When I enter username "Admin" and password "admin123"
	And I press Login button
	Then I should be logged in
	When I go to "https://opensource-demo.orangehrmlive.com/index.php/admin/viewJobTitleList" page
	And I press Add button
	And I fill in the following:
			|     locator     |      value       |
			|    JobTitle    |   My Job Title   |
			| JobDescription | Some Description |
			|      Note       |     My Note      |
	And I press Save button
	Then Job Title table should contain My Job Title
	When I click on My Job Title in Job Title table
	And I press Edit button
	And I change Job Description field from Some Description to "Some Another Description"
	And I press Save button
	Then Job Description table should contain Some Another Description field
	When I select My Job Title field in Job Description table
	And I press Delete button
	And I press OK button in popup window
	Then I should not see My Job Title field in Job Description table