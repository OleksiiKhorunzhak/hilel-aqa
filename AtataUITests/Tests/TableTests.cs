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
                    AddPopup.FirstName.Set("Elchin").
                    AddPopup.LastName.Set("Sangu").
                    AddPopup.Age.Set("36").
                    AddPopup.Salary.Set("25000").
                    AddPopup.Department.Set("Finance").
                    AddPopup.Submit.Click().
                    AddPopup.Email.Css["border-color"].Should.Be("rgb(220, 53, 69)").
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
            //WebTable.Rows.Count.Should.BeGreater(3).
            //WebTable.Rows[6].FirstName.Should.Be("Elchin").
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].FirstName.Should.BeVisible().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].LastName.Should.Be("Sangu").
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Age.Should.Be("36").
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Email.Should.Be("elchin@gmail.com").
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Salary.Should.Be("25000").
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Elchin")].Department.Should.Be("Finance");
        }

        //Edit row and verify row edited
        [Test, Description("Edit row and verify row edited")]
        public void EditAndVerifyRowTest()
        {
            Go.To<DemoQAWebTablePage>().
            WebTable.Should.BeVisible().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].EditButton.Click().
            AddPopup.Age.Set("40").
            AddPopup.Submit.Click().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Age.Should.Be("40");

        }


        //Delete row and verify row deleted  
        [Test, Description("Delete row and verify row deleted")]
        public void DeleteAndVerifyRowTest()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
            WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].DeleteButton.Click();

        }
    }   
}
