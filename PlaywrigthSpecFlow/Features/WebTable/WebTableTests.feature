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
    And I set Email "<Email>" 
    And I set Age "<Age>" 
    And I set Salary "<Salary>" 
    And I set Department "<Department>"
    And I click Submit Button
	Then I see FirstName "<FirstName>" in a table
    Then I see LastName "<LastName>" in a table

	Examples:
    | FirstName | LastName | Email             |Age | Salary | Department|
    | John      | Wick     | JohnWick@wick.com | 23 |  25    | Insurance |
    | Alice     | Smith    |  test@gamil.com   |  3 |   45   |Insurance  |
    | Bob       | Johnson  |  test@gamil.com   |  3 |   3    |Insurance  |
    | Jacky     | Vegan    |  test@gamil.com   |  3 |   2    |  Finance  |
    | Alice     | Cantrel  |JohnWick@wick.com  | 23 |  25    | Finance   |
    | Jon       | Vishin   |  new@gamil.com    | 33 |   25   |  Finance  |
    | Alosa     | Camopr   |John@wick.com      | 53 |  56    | Business  |
     

    Scenario Outline: I can edit data in table after adding a new row
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
    
    When I click Edite button "4"
    And I set FirstName to "Test"
    And I set LastName to "LastName"
    And I click Submit Button
    Then I see FirstName "Test" in a table
    Then I see LastName "LastName" in a table
   
    Examples: 
    | FirstName | LastName | Email             |Age | Salary | Department|
    | John      | Wick     | JohnWick@wick.com | 23 |  25    | Insurance |


    Scenario Outline: I can delete table row with data
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
  
    When I click Delete button "4"
    Then I do not see deleted Row "4" in a table

    Examples: 
    | FirstName | LastName | Email             |Age | Salary | Department|
    | John      | Wick     | JohnWick@wick.com | 23 |  25    | Insurance |


    Scenario Outline: I can see new row is added after adding 
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

    Then I see new Row added "4" in a table

    Examples: 
    | FirstName | LastName | Email             |Age | Salary | Department|
    | John      | Wick     | JohnWick@wick.com | 23 |  25    | Insurance |
