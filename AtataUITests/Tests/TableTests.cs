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
    }
}
