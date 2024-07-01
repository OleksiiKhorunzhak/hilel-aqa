﻿@ReusesFeatureDriver
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
	#And I click Add Button
	#And I set FirstName to "<FirstName>"
    #And I set LastName to "<LastName>"
	Then I see FirstName "<FirstName>" in a table
	Examples:
    | FirstName | LastName |
    | John      | Wick     |
    | Alice     | Smith    |
    | Bob       | Johnson  |
    | Cierra    | Vega     |
    | Alden     | Cantrell |