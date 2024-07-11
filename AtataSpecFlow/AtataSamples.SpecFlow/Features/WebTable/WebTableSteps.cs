using Atata;
using AtataSamples.SpecFlow.PageObjects;
using System;
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

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public static void ThenISeeFirstName(string firstName) =>
            Go.On<WebTablePage>().
            Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].FirstName.Should.Equal(firstName);
    }

    //[Given(@"I am on DemoQA WebTable Page")]
    //public void GivenIAmOnDemoQAWebTablePage()
    //{
    //    throw new PendingStepException();
    //}

    //[When(@"I see the WebTable")]
    //public void WhenISeeTheWebTable()
    //{
    //    throw new PendingStepException();
    //}

    //[Then(@"I see FirstName ""([^""]*)"" in a table")]
    //public void ThenISeeFirstNameInATable(string cierra)
    //{
    //    throw new PendingStepException();
    //}

    //[When(@"I click Add Button")]
    //public void WhenIClickAddButton()
    //{
    //    throw new PendingStepException();
    //}

    //[When(@"I set FirstName to ""([^""]*)""")]
    //public void WhenISetFirstNameTo(string john)
    //{
    //    throw new PendingStepException();
    //}

    //[When(@"I set LastName to ""([^""]*)""")]
    //public void WhenISetLastNameTo(string wick)
    //{
    //    throw new PendingStepException();
    //}

    //[When(@"I set Email to ""([^""]*)""")]
    //public void WhenISetEmailTo(string p0)
    //{
    //    throw new PendingStepException();
    //}

    //[Then(@"I see newFirstName ""([^""]*)"" in a table")]
    //public void ThenISeeNewFirstNameInATable(string john)
    //{
    //    throw new PendingStepException();
    //}

}