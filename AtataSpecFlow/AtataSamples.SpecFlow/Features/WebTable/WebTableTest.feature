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
    And I set Age to "<Age>"
    And I set Email to "<Email>"
    And I set Salary to "<Salary>"
    And I set Department to "<Department>"
    And I click Submit button
	Then I see FirstName "<FirstName>" in a table
    Then I see LastName "<LastName>" in a table
    Then I see Age "<Age>" in a table
	Then I see Email "<Email>" in a table
    Then I see Salary "<Salary>" in a table
    Then I see Department "<Department>" in a table

    Examples:
  | FirstName | LastName | Age | Email                 | Salary | Department  |
  | John      | Wick     | 22  | JohnWick@wick.com     | 15000  | Compliance  |
  | Elchin    | Sangu    | 36  | elchin@sangu.com      | 25000  | Finance     |
  | Alice     | Johnson  | 28  | alice.j@company.com   | 18000  | HR          |
  | Bob       | Brown    | 45  | bob.b@company.com     | 23000  | IT          |
  | Carol     | Smith    | 32  | carol.s@company.com   | 21000  | Marketing   |
  | David     | Wilson   | 40  | david.w@company.com   | 22000  | Sales       |
  | Eve       | Davis    | 29  | eve.d@company.com     | 19000  | Legal       |
  | Frank     | Miller   | 33  | frank.m@company.com   | 24000  | Operations  |
  | Grace     | Lee      | 27  | grace.l@company.com   | 16000  | R&D         |
  | Hank      | Taylor   | 39  | hank.t@company.com    | 25000  | Admin       |
  | Irene     | Anderson | 31  | irene.a@company.com   | 20000  | Finance     |
  | Jack      | Thomas   | 35  | jack.t@company.com    | 23000  | HR          |
  | Karen     | Jackson  | 38  | karen.j@company.com   | 22000  | IT          |
  | Leo       | White    | 30  | leo.w@company.com     | 19000  | Marketing   |
  | Megan     | Harris   | 34  | megan.h@company.com   | 21000  | Sales       |
  | Nate      | Martin   | 26  | nate.m@company.com    | 17000  | Legal       |
  | Olivia    | Thompson | 41  | olivia.t@company.com  | 24000  | Operations  |
  | Paul      | Garcia   | 37  | paul.g@company.com    | 25000  | R&D         |
  | Quinn     | Martinez | 25  | quinn.m@company.com   | 15000  | Admin       |
  | Rachel    | Robinson | 29  | rachel.r@company.com  | 20000  | Compliance  |
  | Steve     | Clark    | 42  | steve.c@company.com   | 22000  | Finance     |
  | Tina      | Rodriguez| 33  | tina.r@company.com    | 23000  | HR          |
  | Uma       | Lewis    | 36  | uma.l@company.com     | 21000  | IT          |
  | Victor    | Lee      | 28  | victor.l@company.com  | 19000  | Marketing   |
  | Wendy     | Walker   | 32  | wendy.w@company.com   | 24000  | Sales       |
  | Xavier    | Hall     | 35  | xavier.h@company.com  | 25000  | Legal       |
  | Yvonne    | Allen    | 30  | yvonne.a@company.com  | 16000  | Operations  |
  | Zack      | Young    | 41  | zack.y@company.com    | 25000  | R&D         |
  | Anna      | King     | 27  | anna.k@company.com    | 18000  | Admin       |
  | Brian     | Wright   | 31  | brian.w@company.com   | 20000  | Compliance  |
  | Clara     | Lopez    | 40  | clara.l@company.com   | 23000  | Finance     |
  | Derek     | Hill     | 34  | derek.h@company.com   | 22000  | HR          |
  | Ella      | Scott    | 29  | ella.s@company.com    | 21000  | IT          |
  | Fred      | Green    | 37  | fred.g@company.com    | 19000  | Marketing   |
  | Gina      | Adams    | 28  | gina.a@company.com    | 24000  | Sales       |
  | Harry     | Baker    | 33  | harry.b@company.com   | 25000  | Legal       |
  | Ivy       | Gonzalez | 36  | ivy.g@company.com     | 16000  | Operations  |
  | James     | Nelson   | 38  | james.n@company.com   | 25000  | R&D         |
  | Kate      | Carter   | 30  | kate.c@company.com    | 18000  | Admin       |
  | Liam      | Mitchell | 25  | liam.m@company.com    | 20000  | Compliance  |
  | Mia       | Perez    | 39  | mia.p@company.com     | 23000  | Finance     |
  | Noah      | Roberts  | 27  | noah.r@company.com    | 22000  | HR          |
  | Oscar     | Turner   | 31  | oscar.t@company.com   | 21000  | IT          |
  | Pam       | Phillips | 34  | pam.p@company.com     | 19000  | Marketing   |
  | Quinn     | Campbell | 26  | quinn.c@company.com   | 24000  | Sales       |
  | Rose      | Parker   | 41  | rose.p@company.com    | 25000  | Legal       |
  | Sam       | Evans    | 35  | sam.e@company.com     | 16000  | Operations  |
  | Tina      | Edwards  | 30  | tina.e@company.com    | 25000  | R&D         |
   
    #TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items