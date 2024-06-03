using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class ElementsTests : UITestFixture
    {
        [Test]
        [Description("TestDecription")]
        public void TestName1()
        {
            Go.To<ElementsPage>();
        }

    }
}
