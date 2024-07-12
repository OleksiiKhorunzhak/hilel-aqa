@ReusesFeatureDriver
@WebPagePresetup
@WebPageLogin
@RefreshPag

Feature: WebTableTest

As a User i want to add new item to web table, 
so that i can see the new item in the table
and i can delete and edit item.

Scenario Outline: I see item in the table
	Given I am on WebTable Page
	When I see the WebTable
	#And I see the Headers
	And I type FirstName "<FirstName>" in the Search
	Then I see data in the row "<FirstName>" , "<LastName>", "<Age>", "<Email>", "<Salary>", "<Department>"
Examples:
	#| FirstName | LastName |
	#| Cierra    | Vega     |
	#| Alden     | Cantrell |
	#| Kierra    | Gentry   |
	| FirstName | LastName | Age | Email              | Salary | Department |
	| Cierra    | Vega     | 39  | cierra@example.com | 10000  | Insurance  |
	| Alden     | Cantrell | 45  | alden@example.com  | 12000  | Compliance |
	| Kierra    | Gentry   | 29  | kierra@example.com | 2000   | Legal      |

Scenario Outline: I add item to the table
	Given I am on WebTable Page
	When I see the WebTable
	And I click Add Button
	And I set FirstName to "<FirstName>"
	And I set LastName to "<LastName>"
	And I set Email to "<Email>"
	Then I see FirstName "<FirstName>" and LastName "<LastName>"
Examples:
	| FirstName | LastName | Email             |
	| John      | Wick     | JohnWick@wick.com |
	| Alice     | Smith    |                   |
	| Bob       | Johnson  |                   |
	| Cierra    | Vega     |                   |
	| Alden     | Cantrell |                   |

    #TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items