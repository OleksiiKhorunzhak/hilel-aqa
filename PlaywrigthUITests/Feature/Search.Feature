Feature: Search on Google

Scenario: Search for PlayWright
  Given I am on the Google home page
  When I search for "PlayWright"
  Then I should see "PlayWright" in the results