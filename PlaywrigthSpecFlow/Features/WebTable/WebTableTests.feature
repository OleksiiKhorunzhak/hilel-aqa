@ReusesFeatureDriver
@WebPageLogin

Feature: WebTableTest

As a User i want to add new item to web table, 
so that i can see the new item in the table
and i can delete and edit item.

Scenario Outline: I see item in the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	Then I see FirstNe>"ame "<FirstNam in a table
    Then I see LastName "<LastName>" in a table
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
    And I set Email "<Email>" 
    And I set Age "<Age>"
    And I set Salary "<Salary>"
    And I set Department "<Department>"
    And I click Submit Button
	Then I see FirstName "<FirstName>" in a table
    Then I see LastName "<LastName>" in a table

	Examples:
    | FirstName | LastName | Email             |Age  |Salary| Department              |
    | John      | Wick     | JohnWick@wick.com | 19  | 320  | Finance                 |
    | Alice     | Smith    | AS@mail.com       | 22  | 558  | Marketing               | 
    | Bob       | Johnson  | BJ@gmail.com      | 33  | 670  | IT                      |
    | Ann       | Gold     | AG@mail.com       | 37  | 5400 | Sales                   |
    | Ali       | Nielsen  | AN@mail.com       | 54  | 500  | Finance                 |
    | Charles   | Garcia   | AGr@mail.com      | 61  | 700  | Business administration |
    | Hanna     | Perry    | HP@mail.com       | 46  | 460  | IT                      |
    | Gabriel   | Bartlett | GB@mail.com       | 59  | 995  | Purchasing              |
    | Eric      | Holder   | EH@mail.com       | 40  | 3300 | Marketing               |




    #TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items