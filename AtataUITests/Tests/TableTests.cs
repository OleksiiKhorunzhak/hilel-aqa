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
                WebTable.Rows[0].FirstName.Should.BeVisible().
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].FirstName.Should.BeVisible();
        }

        //TODO: automate test cases
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted
    }
}
