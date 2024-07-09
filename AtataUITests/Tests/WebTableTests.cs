using Atata;
using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System.Linq;
using TechTalk.SpecFlow;

namespace AtataUITests.Tests
{
    public sealed class WebTableTests : UITestFixture
    {
        readonly string failedColor = "rgb(220, 53, 69)";
        readonly string passedColor = "rgb(40, 167, 69)";

        [Test, Retry(2)]
        public void VerifyTableHeaders()
        {
            List<string> headersList = new List<string>
            { "First Name", "Last Name", "Age", "Email", "Salary", "Department", "Action" };

            foreach (var header in headersList)
                Go.To<WebTablePage>()
                .Table.Headers.Contents.Value.Contains(header);
        }

        [Test, Retry(2)]
        public void VerifyTableRow()
        {
            Go.To<WebTablePage>()
                .Table.Should.BeVisible()
                .Table.Rows[0].Should.BePresent()
                .Table.Rows[0].FirstName.Should.Be("Cierra")
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Should.BeVisible()
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].LastName.Should.Be("Vega")
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Age.Should.Be("39")
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Email.Should.Be("cierra@example.com")
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Salary.Should.Be("10000")
                .Table.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Department.Should.Be("Insurance"); 
        }

        [Test]
        public void AddNewRowTest()
        {
            Go.To<WebTablePage>()
                .Table.Should.BeVisible()
                .Add.Click()
                    .AddPopup.FirstName.Set("TestName123")
                    .AddPopup.LastName.Set("LastName 321")
                    .AddPopup.Email.Set("test123@email.com")
                    .AddPopup.Age.Set("99")
                    .AddPopup.Salary.Set("7890")
                    .AddPopup.Department.Set("testDep")
                    .AddPopup.Submit.Should.BeVisible()
                    .AddPopup.Submit.Click()
                .Table.Should.BeVisible()
                .Table.Rows[0].Should.BePresent();          
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].Should.BeVisible()
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].LastName.Should.Be("LastName 321")
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].Email.Should.Be("testMail123@email.com")
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].Age.Should.Be("99")
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].Salary.Should.Be("7890")
                //.Table.Rows[row => row.FirstName.Content.Value.Equals("TestName123")].Department.Should.Be("testDep");
        }

        [Test, Retry(2)]
        public void VerifyAddPopupRequiredFields()
        {
            Go.To<WebTablePage>()
                .Add.Click()
                    .AddPopup.Should.BeVisible()
                    .AddPopup.LastName.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.LastName.Css["border-color"].Should.Be(passedColor)
                    .AddPopup.Submit.Click();
                    /////////////////
        }
        [Test, Retry(2)]
        public void VerifySearch()
        {
            Go.To<WebTablePage>()
                .Search.Should.BeVisible()
                .Search.Should.BeEmpty()
                .Search.Set("Gentry")
                .Search.Should.BeFocused()
                .Table.Rows[0].FirstName.Should.Be("Kierra");
        }

        //TODO: automate test cases
        //Check any mandatory field
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted  
    }
}
