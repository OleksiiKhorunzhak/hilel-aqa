using Atata;
using AtataSamples.SpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace AtataSamples.SpecFlow.Features.WebTable
{
    [Binding]
    public sealed class WebTableSteps
    {
        [When(@"I see the WebTable")]
        public static void WhenISeeTheWebTable() =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Should.BeVisible();

        [When(@"I click Add Button")]
        public static void WhenIKlickAddButton() =>
            Go.On<DemoQAWebTablePage>().
            Add.Click();

        [When(@"I set FirstName to ""(.*)""")]
        public static void WhenISetFirstName(string firstName) =>
            Go.On<DemoQAWebTablePage>().
            AddPopup.FirstName.Set(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public static void WhenISetLastName(string lastName) =>
            Go.On<DemoQAWebTablePage>().
                AddPopup.LastName.Set(lastName);

        [When(@"I set Email to ""(.*)""")]
        public static void WhenISetEmail(string email) =>
            Go.On<DemoQAWebTablePage>().
                AddPopup.Email.Set(email);

        [When(@"I set Age to ""(.*)""")]
        public static void WhenISetAge(string age) =>
           Go.On<DemoQAWebTablePage>().
               AddPopup.Age.Set(age);

        [When(@"I set Salary to ""(.*)""")]
        public static void WhenISetSalary(string salary) =>
            Go.On<DemoQAWebTablePage>().
                AddPopup.Salary.Set(salary);

        [When(@"I set Department to ""(.*)""")]
        public static void WhenISetDepartment(string department) =>
            Go.On<DemoQAWebTablePage>().
                AddPopup.Department.Set(department);

        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton() =>
            Go.On<DemoQAWebTablePage>().
                AddPopup.Submit.Click();

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public static void ThenISeeFirstName(string firstName) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals(firstName)].FirstName.Should.Equal(firstName);

        [Then(@"I see LastName ""(.*)"" in a table")]
        public static void ThenISeeLastName(string lastName) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.LastName.Content.Value.Equals(lastName)].LastName.Should.Equal(lastName);

        [Then(@"I see Age ""(.*)"" in a table")]
        public static void ThenISeeAge(string age) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.Age.Content.Value.Equals(age)].Age.Should.Equal(age);

        [Then(@"I see Email ""(.*)"" in a table")]
        public static void ThenISeeEmail(string email) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.Email.Content.Value.Equals(email)].Email.Should.Equal(email);

        [Then(@"I see Salary ""(.*)"" in a table")]
        public static void ThenISeeSalary(string salary) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.Salary.Content.Value.Equals(salary)].Salary.Should.Equal(salary);
       
        [Then(@"I see Department ""(.*)"" in a table")]
        public static void ThenISeeDepartment(string department) =>
            Go.On<DemoQAWebTablePage>().
            WebTable.Rows[row => row.Department.Content.Value.Equals(department)].Department.Should.Equal(department);
    }
}