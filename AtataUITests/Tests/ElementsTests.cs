using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class ElementsTests : UITestFixture
    {
        //Elements:
        //Preconditions: Go to https://demoqa.com/elements
        //TC 1: Image "https://demoqa.com/images/Toolsqa.jpg" should be in the Header
        //TC 2: Image "https://demoqa.com/images/Toolsqa.jpg" should be centered in the header
        //TC 3: Image "https://demoqa.com/images/Toolsqa.jpg" should be a link to Home page "https://demoqa.com/"

        [Test]
        [Description("TestDecription")]
        public void TestName1()
        {
            Go.To<ElementsPage>();
        }

    }
}
