Feature: WorkWithDb

/Scenario: The result of SQL queries can be written into file
	When I open the result file
	Then 'the file'  is empty
	When I read the SQL file with queries
	And I execute queries from it
	And I write the result of query into 'the file' 
	And I open the result file
	Then 'the file'  is populated with text

Scenario: The minimal working time for each test can be displayed
	When I read the SQL query from 'minimalWorkingTime.txt'
	And I execute this SQL query in MySQL and the result is saved in the store
	And The result is appended to the 'results.txt'
	Then The 'results.txt' is not blank

Scenario: All projects with unique tests on each of them can be displayed
	When I read the SQL query from 'uniqeTestsInProjects.txt'
	And I execute this SQL query in MySQL and the result is saved in the store
	And The result is appended to the 'results.txt'
	Then The 'results.txt' is not blank

Scenario: All tests for each project that were executed not later specified date can be displayed 
	When I read the SQL query from 'testsRunAfterSpecificDate.txt'
	And I execute this SQL query for the parameter '2016-10-13' in MySQL and the result is saved in the store
	And The result is appended to the 'results.txt'
	Then The 'results.txt' is not blank

Scenario: Number of tests which were executed for specified browsers can be displayed
	When I read the SQL query from 'numberOfTestsOnTwoBrowsers.txt'
	And I execute this SQL query for the parameters 'firefox' and 'chrome' in MySQL and the result is saved in the store
	And The result is appended to the 'results.txt'
	Then The 'results.txt' is not blank