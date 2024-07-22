using AtataUITests.PageObjects;

namespace AtataUITests.Tests.Fixtures
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TextBoxesTestFixture : UITestFixture
    {
        internal DemoQATextBoxPage demoQaTextBoxPage;

        [SetUp]
        public void TextBoxesSetUp()
        {
            demoQaTextBoxPage = DemoQAElementsPage.GoToTextBoxesPage();
        }
    }
}