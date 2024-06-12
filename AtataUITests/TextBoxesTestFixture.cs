using AtataUITests.PageObjects;

namespace AtataUITests
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