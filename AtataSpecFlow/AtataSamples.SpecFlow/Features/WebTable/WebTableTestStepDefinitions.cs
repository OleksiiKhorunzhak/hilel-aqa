using System;
using TechTalk.SpecFlow;
using Atata;
using AtataSamples.SpecFlow.PageObjects;
using System.Collections.Generic;
using System.Linq;


namespace AtataSpecFlow.Features.WebTable
{
    [Binding]
    public sealed class WebTableSteps
    {
        [Given(@"I am on WebTable Page")]
        public static void GivenIAmOnHomePage() => Go.To<WebTablePage>();

        [When(@"I see the WebTable")]
        public static void WhenISeeTheWebTable() => Go.On<WebTablePage>()
            .Table.Should.BeVisible();

        [When(@"I see the Headers")]
        public void WhenISeeTheHeaders()
        {
            List<string> headersList = new List<string>
            { "First Name", "Last Name", "Age", "Email", "Salary", "Department", "Action" };

            foreach (var header in headersList)
            {
                Go.On<WebTablePage>()
                    .Table.Headers.Contents.Value.Contains(header);
            }
        }

        [When(@"I type FirstName ""(.*)"" in the Search")]
        public void WhenITypeFirstNameInTheSearch(string firstName) => Go.On<WebTablePage>()
            .Search.Set(firstName);

        [Then(@"I see data in the row ""([^""]*)"" , ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)""")]
        public void ThenISeeDataInTheRow(string firstName, string lastName, string age, string email, string salary, string department)
        {
            Go.On<WebTablePage>()
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Should.BeVisible()
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].LastName.Should.Be(lastName)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Age.Should.Be(age)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Email.Should.Be(email)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Salary.Should.Be(salary)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Department.Should.Be(department);
        }

        [When(@"I click Add Button")]
        public static void WhenIClickAddButton() => Go.On<WebTablePage>()
            .Add.Click();

        [When(@"I see Registration Form")]
        public void WhenISeeRegistrationForm() => Go.On<WebTablePage>()
            .AddPopup.Should.BeVisible();

        [When(@"I set FirstName to ""(.*)""")]
        public static void WhenISetFirstName(string firstName) => Go.On<WebTablePage>()
            .AddPopup.FirstName.Set(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public static void WhenISetLastName(string lastName) => Go.On<WebTablePage>()
            .AddPopup.LastName.Set(lastName);

        [When(@"I set Email to ""(.*)""")]
        public static void WhenISetEmail(string email) => Go.On<WebTablePage>()
            .AddPopup.Email.Set(email);

        [When(@"I set Age to ""([^""]*)""")]
        public void WhenISetAgeTo(string age) => Go.On<WebTablePage>()
            .AddPopup.Age.Set(age);

        [When(@"I set Salary to ""([^""]*)""")]
        public void WhenISetSalaryTo(string salary) => Go.On<WebTablePage>()
            .AddPopup.Salary.Set(salary);

        [When(@"I set Department to ""([^""]*)""")]
        public void WhenISetDepartmentTo(string department) => Go.On<WebTablePage>()
            .AddPopup.Department.Set(department);

        [When(@"I click Submit Button")]
        public void WhenIClickSubmitButton() => Go.On<WebTablePage>()
            .AddPopup.Submit.Click();
    }
}