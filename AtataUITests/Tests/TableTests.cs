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

        [Test]
        public void CheckMandatoryField()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
                WebTable.Rows.Count.Should.BeGreater(1).
                Add.Click().
                   AddPopup.FirstName.Set("Helen").
                   AddPopup.LastName.Set("Vick").
                   AddPopup.Email.Set("hv@mail.com").
                   AddPopup.Submit.Click().                 
                   AddPopup.Age.Css["border-color"].Should.Be("rgb(220, 53, 69)").
                   AddPopup.Salary.Css["border-color"].Should.Be("rgb(220, 53, 69)").
                   AddPopup.Department.Css["border-color"].Should.Be("rgb(220, 53, 69)");

        }

        [Test]

        public void AddNewRow()
        {
            Go.To<DemoQAWebTablePage>().
              WebTable.Should.BeVisible().
                  Add.Click().
                  AddPopup.FirstName.Set("Helen").
                  AddPopup.LastName.Set("Vick").
                  AddPopup.Email.Set("hv@mail.com").
                  AddPopup.Age.Set("29").
                  AddPopup.Salary.Set("17500").
                  AddPopup.Department.Set("Finance").
                  AddPopup.Submit.Click().
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].FirstName.Should.BeVisible().
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].LastName.Should.Be("Vick").
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].Age.Should.Be("29").
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].Email.Should.Be("hv@mail.com").
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].Salary.Should.Be("17500").
          WebTable.Rows[row => row.FirstName.Content.Value.Equals("Helen")].Department.Should.Be("Finance");

        }

        [Test]

        public void VerifyRowAdited()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].EditButton.Click().
                AddPopup.Salary.Set("36000").
                AddPopup.Submit.Click().
                 WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].Salary.Should.Be("36000");
        }

       [Test]

       public void VerifyRowDeleted()
        {
            Go.To<DemoQAWebTablePage>().
              WebTable.Should.BeVisible().
              WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].DeleteButton.Click();

        }
        //TODO: automate test cases
        //Check any mandatory field
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted  
    }
}
