using Atata;
using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System.Linq;
using TechTalk.SpecFlow;

namespace AtataUITests.Tests
{
    public sealed class WebTableTests : UITestFixture
    {
        [Test]
        public void VerifyTableHeaders()
        {
            Go.To<WebTablePage>()
                .Table.Should.BeVisible();

            List<string> headersList = new List<string>
            { "First Name", "Last Name", "Age", "Email", "Salary", "Department", "Action" };

            foreach (var header in headersList)
                Go.On<WebTablePage>()
                .Table.Headers.Contents.Value.Contains(header);
        }

        [Test]
        public void VerifySearch()
        {
            Go.To<WebTablePage>()
                .Search.Should.BeVisible()
                .Search.Should.BeEmpty()
                .Search.Set("Gentry")
                .Search.Should.BeFocused()
                .Table.Rows[0].FirstName.Should.Be("Kierra");
        }

        [Test]
        public void VerifyTableRow()
        {
            //testData:
            string firstName = "Cierra";
            string lastName = "Vega";
            string age = "39";
            string email = "cierra@example.com";
            string salary = "10000";
            string department = "Insurance";
            //--------------------------------
            Go.To<WebTablePage>()
                .Table.Should.BeVisible()
                .Table.Rows[0].Should.BePresent()
                .Table.Rows[0].FirstName.Should.Be(firstName)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Should.BeVisible()
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].LastName.Should.Be(lastName)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Age.Should.Be(age)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Email.Should.Be(email)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Salary.Should.Be(salary)
                .Table.Rows[row => row.FirstName.Content.Value.Equals(firstName)].Department.Should.Be(department);
        }

        [Test]
        public void VerifyAddNewRow()
        {
            //testData:
            string firstName = "TestName123";
            string lastName = "LastName 321";
            string email = "test123@email.com";
            string age = "99";
            string salary = "7890";
            string department = "testDep";
            //--------------------------------
            Go.To<WebTablePage>()
                .Table.Should.BeVisible()
                .Add.Click()
                    .AddPopup.FirstName.Set(firstName)
                    .AddPopup.LastName.Set(lastName)
                    .AddPopup.Email.Set(email)
                    .AddPopup.Age.Set(age)
                    .AddPopup.Salary.Set(salary)
                    .AddPopup.Department.Set(department)
                    .AddPopup.Submit.Should.BeVisible()
                    .AddPopup.Submit.Click();
            Go.On<WebTablePage>()
                .Table.Should.BeVisible();

            List<string> valueList = new List<string>
            { firstName, lastName, email, age, salary, department };

            foreach (var cellValue in valueList)
                Go.On<WebTablePage>()
                .Table.Rows.Contents.Value.Contains(cellValue);
        }

        [Test]
        public void VerifyAddPopupRequiredFields()
        {
            string failedColor = "rgb(220, 53, 69)";
            string passedColor = "rgb(40, 167, 69)";

            Go.To<WebTablePage>()
                .Add.Click()
                    .AddPopup.Submit.Click()
                    .AddPopup.FirstName.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.LastName.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.Email.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.Age.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.Salary.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.Department.Css["border-color"].Should.Be(failedColor)
                    .AddPopup.FirstName.SetRandom()
                    .AddPopup.LastName.SetRandom()
                    .AddPopup.Email.Set("Test123@mail.com")
                    .AddPopup.Age.Set("23")
                    .AddPopup.Salary.Set("4567")
                    .AddPopup.Department.SetRandom()
                    .AddPopup.FirstName.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.LastName.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.Email.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.Age.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.Salary.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.Department.Css["border-color"].Should.Be(passedColor);
        }

        //TODO: automate test cases
        //Edit row and verify row edited
        //Delete row and verify row deleted  
    }
}
