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
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted  
    }
}
