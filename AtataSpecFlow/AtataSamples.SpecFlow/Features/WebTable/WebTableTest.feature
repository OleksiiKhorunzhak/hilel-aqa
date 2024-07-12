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
	And I see Registration Form
	And I set FirstName to "<FirstName>"
	And I set LastName to "<LastName>"
	And I set Age to "<Age>"
	And I set Email to "<Email>"
	And I set Salary to "<Salary>"
	And I set Department to "<Department>"
	And I click Submit Button
	Then I see data in the row "<FirstName>" , "<LastName>", "<Age>", "<Email>", "<Salary>", "<Department>"
Examples:
	| FirstName | LastName   | Age | Email                        | Salary | Department  |
	| Cierra    | Vega       | 39  | cierra@example.com           | 10000  | Insurance   |
	| Alden     | Cantrell   | 45  | alden@example.com            | 12000  | Compliance  |
	| Kierra    | Gentry     | 29  | kierra@example.com           | 2000   | Legal       |
	| Ruby      | Frank      | 34  | ruby.frank@example.com       | 11000  | Marketing   |
	| John      | Doe        | 28  | john.doe@example.com         | 9000   | Sales       |
	| Mary      | Smith      | 47  | mary.smith@example.com       | 13000  | HR          |
	| David     | Johnson    | 30  | david.johnson@example.com    | 10500  | IT          |
	| Sara      | Brown      | 37  | sara.brown@example.com       | 15000  | Finance     |
	| James     | Wilson     | 40  | james.wilson@example.com     | 11500  | Operations  |
	| Linda     | Lee        | 42  | linda.lee@example.com        | 12500  | Development |
	| Michael   | Clark      | 35  | michael.clark@example.com    | 10000  | QA          |
	| Laura     | Lewis      | 32  | laura.lewis@example.com      | 9000   | Design      |
	| Daniel    | Hall       | 38  | daniel.hall@example.com      | 12000  | Support     |
	| Olivia    | King       | 29  | olivia.king@example.com      | 8000   | Legal       |
	| William   | Adams      | 43  | william.adams@example.com    | 13000  | Insurance   |
	| Emma      | Scott      | 36  | emma.scott@example.com       | 9500   | Compliance  |
	| Robert    | Harris     | 41  | robert.harris@example.com    | 11000  | Marketing   |
	| Emily     | Young      | 33  | emily.young@example.com      | 8500   | Sales       |
	| Richard   | Nelson     | 44  | richard.nelson@example.com   | 12500  | HR          |
	| Amanda    | Baker      | 31  | amanda.baker@example.com     | 10500  | IT          |
	| Charles   | Carter     | 46  | charles.carter@example.com   | 15000  | Finance     |
	| Jessica   | Mitchell   | 28  | jessica.mitchell@example.com | 8500   | Operations  |
	| Matthew   | Perez      | 39  | matthew.perez@example.com    | 9000   | Development |
	| Jennifer  | Roberts    | 34  | jennifer.roberts@example.com | 11000  | QA          |
	| Joshua    | Turner     | 45  | joshua.turner@example.com    | 12000  | Design      |
	| Sarah     | Phillips   | 30  | sarah.phillips@example.com   | 10000  | Support     |
	| Joseph    | Campbell   | 37  | joseph.campbell@example.com  | 13000  | Legal       |
	| Ashley    | Parker     | 42  | ashley.parker@example.com    | 9500   | Insurance   |
	| Mark      | Evans      | 31  | mark.evans@example.com       | 8000   | Compliance  |
	| Megan     | Edwards    | 35  | megan.edwards@example.com    | 11500  | Marketing   |
	| Andrew    | Collins    | 43  | andrew.collins@example.com   | 12500  | Sales       |
	| Samantha  | Stewart    | 32  | samantha.stewart@example.com | 8500   | HR          |
	| Benjamin  | Sanchez    | 40  | benjamin.sanchez@example.com | 10500  | IT          |
	| Hannah    | Morris     | 28  | hannah.morris@example.com    | 9000   | Finance     |
	| Lucas     | Rogers     | 38  | lucas.rogers@example.com     | 9500   | Operations  |
	| Sophia    | Reed       | 34  | sophia.reed@example.com      | 12000  | Development |
	| Nathan    | Cook       | 29  | nathan.cook@example.com      | 8000   | QA          |
	| Mia       | Morgan     | 46  | mia.morgan@example.com       | 11000  | Design      |
	| Ethan     | Bell       | 36  | ethan.bell@example.com       | 10000  | Support     |
	| Isabella  | Murphy     | 33  | isabella.murphy@example.com  | 13000  | Legal       |
	| Logan     | Bailey     | 41  | logan.bailey@example.com     | 10500  | Insurance   |
	| Abigail   | Rivera     | 39  | abigail.rivera@example.com   | 9000   | Compliance  |
	| Ryan      | Cooper     | 32  | ryan.cooper@example.com      | 8500   | Marketing   |
	| Grace     | Richardson | 28  | grace.richardson@example.com | 11500  | Sales       |
	| Tyler     | Cox        | 37  | tyler.cox@example.com        | 10000  | HR          |
	| Zoey      | Howard     | 40  | zoey.howard@example.com      | 12000  | IT          |
	| Dylan     | Ward       | 29  | dylan.ward@example.com       | 9500   | Finance     |
	| Avery     | Torres     | 34  | avery.torres@example.com     | 13000  | Operations  |
	| Jack      | Peterson   | 44  | jack.peterson@example.com    | 10500  | Development |
	| Lily      | Gray       | 31  | lily.gray@example.com        | 8500   | QA          |
