using Atata;
using AtataUITests.PageObjects;
using AtataUITests;
using _ = AtataUITests.Tests.CheckBoxTests;
using System.Reflection.Emit;

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

        [Test]
        public void VerifyHomeTreeItems()
        {
            List<string> checkboxLabels = new List<string>
                {"Home","Desktop","Documents","Downloads"};

            foreach (var label in checkboxLabels)
            {
                Go.To<CheckBoxPage>()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeChecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked();
            }
        }

        [Test]
        public void VerifyFirstChildItems()
        {
            List<string> checkboxChildLabels = new List<string>
                 {"Notes","Commands","WorkSpace","Office","Word File.doc","Excel File.doc"};

            foreach (var label in checkboxChildLabels)
            {
                Go.To<CheckBoxPage>()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].Toggle.Click()
                .ScrollDown().CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BePresent()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeChecked();
            }

        }

        [Test]
        public void VerifySecondChildItems()
        {
            List<string> checkboxChildLabels = new List<string>
                {"React","Angular","Veu","Public","Private","Classified","General"};

            foreach (var label in checkboxChildLabels)
            {
                Go.To<CheckBoxPage>()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().ScrollDown()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Office")].Toggle.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BePresent()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeChecked();
            }
        }

        //Verifiing every checkbox
        [Test]
        public void VerifyExpandCollapseAll()
        {
            Go.To<CheckBoxPage>()
                .ExpandAll.Click().ScrollDown();

            List<string> checkboxLabels = new List<string>
                {"Desktop","Documents","Downloads","Notes","Commands","WorkSpace","Office","Word File.doc",
                 "Excel File.doc","Office","WorkSpace","React","Angular","Veu","Public","Private","Classified","General"};

            foreach (var label in checkboxLabels)
            {
                Go.On<CheckBoxPage>()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Should.BePresent()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Should.BeVisible()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeChecked()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Title.Click()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].CheckBox.Should.BeUnchecked();
            }
            Go.On<CheckBoxPage>()
                .CollapseAll.Click();

            foreach (var label in checkboxLabels)
            {
                Go.On<CheckBoxPage>()
                    .CheckBoxTree.Branch[x => x.Title.Content.Value.Equals(label)].Should.Not.BeVisible();
            }
        }

    }
}
