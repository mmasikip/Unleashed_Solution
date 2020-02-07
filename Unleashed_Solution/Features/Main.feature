Feature: Main

@Task1
Scenario: Task_01_Create new product
	Given I launch the Online Inventory Software site
	And I login using credentials:
		| Email            | Password   |
		| qamasikip@unl.sh | Unleashed1 |
	When I navigate using left navigation menu: Inventory > Products > Add Product
	And I am on the 'Add Product' page
	And I enter Product Details:
		| Product Code | Product Description | Barcode | Unit Of Measure | Product Group | Default Label Template |
		| RANDOM       | Sample description  | RANDOM  | EA              | Consumable    | Unleashed Default      |
	And I click 'Save' button
	Then notification message 'You have updated the product successfully.' is displayed
	And I navigate using left navigation menu: Inventory > Products > View Products
	And I am on the 'View Products' page
	And newly created product can be searched
	And I delete the newly created product
	And notification message 'Product successfully deleted.' is displayed

@Task2
Scenario: Task_02_Complete Sales Order flow
	Given I launch the Online Inventory Software site
	And I login using credentials:
		| Email            | Password   |
		| qamasikip@unl.sh | Unleashed1 |
	When I navigate using left navigation menu: Inventory > Products > View Products
	And I am on the 'View Products' page
	And I noted the first product's Product Code and Qty On Hand
	And I navigate using left navigation menu: Sales > Orders > Add Sales Order
	And I am on the 'Add Sales Order' page
	And I select Customer Code 'GBRO' on Add Sales Order page
	And I add Product Code and Quantity of '1'
	And I click 'Complete' button
	And I click 'Yes' on confirmation window
	Then notification message 'You have successfully Completed Sales Order' is displayed
	And I navigate using left navigation menu: Inventory > Products > View Products
	And I am on the 'View Products' page
	And I search for the noted Product Code
	And I validate Qty On Hand is reduced by '1'
	
@Task3
Scenario: Task_03_API Validation
	Given I have REST Client
	And I set Base Url SalesOrders/bfb4e4ee-2c3a-440c-8ee9-6ee4ec590b90
	And I initialize my request
	And I add header 'Accept' with value 'application/json'
	And I add header 'Content-Type' with value 'application/json'
	And I set my api-auth-id header value
	And I set my api-auth-signature header value
	When I make a GET request
	Then response status returns 'OK'