using Atata;
using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class TableTestsw : UITestFixture
    {
        [Test]
        public void TableColumnTest()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible();
        }
    }
}
