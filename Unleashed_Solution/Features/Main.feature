Feature: Main

@Task1
Scenario: Task_01_Create new product
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@Task2
Scenario: Task_02_Complete Sales Order flow
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@Task3
Scenario: Task_03_API Validate critical scenarios
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen