@ReusesFeatureDriver
@WebPageLogin

Feature: WebTableTest

As a User i want to add new item to web table, 
so that i can see the new item in the table
and i can delete and edit item.

Scenario Outline: I see item in the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	Then I see FirstName "<FirstName>" in a table
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
    And I set Email "<Email>" in a table
    And I set Age <Age> in a table
    And I set Salary <Salary> in a table
    And I set Department <Department> in a table
    And I click Submit button
    
	Then I see FirstName "<FirstName>" in a table
	Then I see LastName "<LastName>" in a table
	Then I see Email "<Email>" in a table
	Then I see Age "<Age>" in a table
	Then I see Salary "<Salary>" in a table
	Then I see Department "<Department>" in a table
	Examples:
    | FirstName | LastName | Email             | Age | Salary | Department |
    | Zack      | Hock     | Zack@Hock.com     | 42  | 12100  | QA         |
    | Alice     | Smith    | Alice@smith.com   | 40  | 10500  | Dev        |
    | Bob       | Johnson  | Bob@johnson.com   | 20  | 9000   | Dev        |
    | Petro     | Petrenko | Petro@Petro.com   | 16  | 9200   | BA         |
    | Ivan      | Ivanenko | Ivan@Ivanenko.com | 59  | 13400  | BA         |
    | Alex      | Alexo    | Alex@Alexo.com    | 30  | 8900   | Dev        |
    | Tanya     | Vertigo  | Tanya@vertigo.com | 25  | 11100  | Dev        |
    | Deb       | Darts    | deb@darts.com     | 55  | 12800  | QA         |

    #TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items