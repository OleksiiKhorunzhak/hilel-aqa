using Atata;
using AtataSamples.SpecFlow.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace AtataSamples.SpecFlow.Features.WebTable
{
    [Binding]
    public sealed class WebTableSteps
    {
        [Given(@"I am on DemoQA WebTable Page")]
        public static void GivenIAmOnHomePage() =>
            Go.To<WebTablePage>();

        [When(@"I see the WebTable")]
        public static void WhenISeeTheWebTable() =>
            Go.On<WebTablePage>().
            Table.Should.BeVisible();

        [When(@"I see the Headers")]
        public void WhenISeeTheHeaders()
        {
            List<string> headersList = new List<string>
            { "First Name", "Last Name", "Age", "Email", "Salary", "Department", "Action" };

            foreach (var header in headersList)
                Go.On<WebTablePage>()
                .Table.Headers.Contents.Value.Contains(header);
        }

        [When(@"I click Add Button")]
        public static void WhenIClickAddButton() =>
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

        [When(@"I type FirstName ""(.*)"" in the Search")]
        public void WhenITypeFirstNameInTheSearch(string firstName) =>
            Go.On<WebTablePage>()
                .Search.Set(firstName);

        [Then(@"I see FirstName ""(.*)"" and LastName ""(.*)""")]
        public void ThenISeeFirstNameAndLastName(string firstName, string lastName) =>
            Go.On<WebTablePage>()
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Should.BeVisible()
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].LastName.Should.Be(lastName);
    }
}