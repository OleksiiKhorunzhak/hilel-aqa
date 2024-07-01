Feature: WebTableTest

As a User i want to add new item to web table, 
so that i can see the new item in the table
and i can delete and edit item.

@ReusesFeatureDriver
Scenario Outline: I see item in the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	Then I see FirstName "<FirstName>" in a table
	Examples:
    | FirstName | LastName |
    | Cierra    | Vega     |
    | Alden     | Cantrell |
    | Kierra    | Gentry   |

Scenario Outline: I add item to the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	And I click Add Button
	And I set FirstName to "<FirstName>"
    And I set LastName to "<LastName>"
    And I set Email to "<Email>"
	Then I see FirstName "<FirstName>" in a table
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