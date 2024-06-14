using Atata;
using AtataUITests.PageObjects;
using AtataUITests;
using _ = AtataUITests.Tests.CheckBoxTests;

namespace AtataUITests.Tests
{
    internal class CheckBoxTests : UITestFixture
    {
        [Test]
        public void VerifyCheckBoxTreeHomeCheckboxVisible()
        {
            Go.To<CheckBoxPage>()
                .CheckBoxTree.Should.BeVisible()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BePresent()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeUnchecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeChecked();
        }

        [Test]
        public void VerifyDocumentsCheckboxChecked()
        {
            Go.To<CheckBoxPage>()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeUnchecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked();
        }
    }
}
