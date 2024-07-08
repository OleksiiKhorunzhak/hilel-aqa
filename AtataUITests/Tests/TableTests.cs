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
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].LastName.Should.Be("Vega").
                Add.Click().
                    AddPopup.Submit.Should.BeVisible().
                    AddPopup.FirstName.Set("John").
                    AddPopup.Submit.Click().
                    AddPopup.LastName.Css["border-color"].Should.Be("rgb(220, 53, 69)");
        }

        //TODO: automate test cases
        //Check any mandatory field
        [Test]

        public void TableMandatoryFieldTest()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
                    Add.Click().
                    AddPopup.Email.Should.BeEnabled();

        }

        //Add new row and verify row added
        [Test, Description("Add new row and verify row added")]
        public void AddAndVerifyNewRowTest()
        {
            Go.To<DemoQAWebTablePage>().
            WebTable.Should.BeVisible().
                    Add.Click().
                    AddPopup.FirstName.Set("Elchin").
                    AddPopup.LastName.Set("Sangu").
                    AddPopup.Email.Set("elchin@gmail.com").
                    AddPopup.Age.Set("36").
                    AddPopup.Salary.Set("25000").
                    AddPopup.Department.Set("Finance").
                    AddPopup.Submit.Click().
           WebTable.Rows.Count.Should.BeGreater(3).
           //WebTable.Rows[6].FirstName.Should.Be("Elchin").
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].FirstName.Should.BeVisible().
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].LastName.Should.Be("Sangu").
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Age.Should.Be("36").
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Email.Should.Be("elchin@gmail.com").
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Salary.Should.Be("25000").
           WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Department.Should.Be("Finance");
        }


        //Edit row and verify row edited
        //Delete row and verify row deleted  




    }
}
