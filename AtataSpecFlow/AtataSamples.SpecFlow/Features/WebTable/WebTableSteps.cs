﻿using Atata;
using AtataSamples.SpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace AtataSamples.SpecFlow.Features.WebTable
{
    [Binding]
    public sealed class WebTableSteps
    {
        [When(@"I see the WebTable")]
        public static void WhenISeeTheWebTable() =>
            Go.On<WebTablePage>().
            WebTable.Should.BeVisible();

        [When(@"I click Add Button")]
        public static void WhenIKlickAddButton() =>
            Go.On<WebTablePage>().
            Add.Click();

        [When(@"I set FirstName to ""(.*)""")]
        public static void WhenISetFirstName(string firstName) =>
            Go.On<WebTablePage>().
            AddPopup.FirstName.Set(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public static void WhenISetLastName(string lastName) =>
            Go.On<WebTablePage>().
                AddPopup.LastName.Set(lastName);

        [When(@"I set Email to ""(.*)""")]
        public static void WhenISetEmail(string email) =>
            Go.On<WebTablePage>().
                AddPopup.Email.Set(email);

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public static void ThenISeeLastName(string firstName) =>
            Go.On<WebTablePage>().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals(firstName)].FirstName.Should.Equal(firstName);
    }
}