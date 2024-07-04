using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    //[Category("ElementsTests")]
    public sealed class ElementsTests : UITestFixture
    {
        [Test, Description("TestDecription"), Retry(2)]
        public void VerifyURL()
        {
            Go.To<ElementsPage>()
                .PageUrl.Should.Be("https://demoqa.com/elements");
        }

    }
}
