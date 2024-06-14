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
            Go.To<CheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.CheckBoxBranch[0].CheckBox.Should.BePresent().
                CheckBoxTree.CheckBoxBranch[0].CheckBox.Should.BeUnchecked().
                CheckBoxTree.CheckBoxBranch[0].Title.Click().
                CheckBoxTree.CheckBoxBranch[0].CheckBox.Should.BeChecked();
        }
    }
}
