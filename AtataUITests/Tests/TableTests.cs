using Atata;
using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class TableTests : UITestFixture
    {
        [Test]
        public void TableColumnTest()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
                WebTable.Rows.Count.Should.BeGreater(1).
                WebTable.Rows[0].FirstName.Should.Be("Cierra").
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].FirstName.Should.BeVisible().
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].LastName.Should.Be("Vega")   .
                Add.Click().
                    AddPopup.Submit.Should.BeVisible().
                    AddPopup.FirstName.Set("John").
                    AddPopup.Submit.Click().
                    AddPopup.LastName.Css["border-color"].Should.Be("rgb(220, 53, 69)");
        }

        //TODO: automate test cases
        //Check any mandatory field
        [Test, Description("Check any mandatory field"), Retry(2)]
        public void CheckMandatoryField()
        {
            Go.To<DemoQAWebTablePage>().
            Add.Click().
                AddPopup.FirstName.Set("John").
                AddPopup.LastName.Set("Doe").
                AddPopup.Email.Set("ABC@gmail.com").
                AddPopup.Age.Set("ABC@gmail.com").
                AddPopup.Salary.Set("2400").
                AddPopup.Department.Set("Sales").
                AddPopup.Submit.Click().
                AddPopup.Age.Css["border-color"].Should.Be("rgb(220, 53, 69)");
        }


        //Add new row and verify row added
        [Test, Description("Check any mandatory field")]
        public void AddNewRowAndVerify()
        {
            Go.To<DemoQAWebTablePage>().
             Add.Click().
                 AddPopup.FirstName.Set("John").
                 AddPopup.LastName.Set("Doe").
                 AddPopup.Email.Set("ABC@gmail.com").
                 AddPopup.Age.Set("22").
                 AddPopup.Salary.Set("2400").
                 AddPopup.Department.Set("Sales").
                 AddPopup.Submit.Click().
                 //Fails on this step
                 //
                 WebTable.Rows[row => row.FirstName.Content.Value.Equals("John")].FirstName.Should.BeVisible();

        }

        //Edit row and verify row edited
        //Delete row and verify row deleted 
    }
}