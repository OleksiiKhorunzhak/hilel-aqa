using Atata;
using AtataUITests.PageObjects;


namespace AtataUITests.Tests
{
    internal class CheckBoxTreeTests : UITestFixture
    {
        [Test]
        public void VerifyCheckBoxTreeeHomeCheckboxVisible()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BePresent().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeUnchecked().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeChecked();
        }

        [Test]
        public void VerifyDocumentsCheckBoxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked();
        }

        [Test, Description("Expand Home > Check Descktop Checkbox, verify checked")]
        public void VerifyDesktopCheckBoxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked();
        }

        [Test, Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public void VerifyWorkSpaceCheckBoxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].CheckBox.Should.BeChecked();
        }

        [Test, Description("Expand Home > Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public void VerifyDisplayResultTextAfterDocumentsCheckBoxChecked() 
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                DisplayResult.Should.Be("You have selected :\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral");
        }


        [Test, Description("Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public void VerifyReactHaveIconRctIconLeafClose()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Icon.Should.BeVisible();
        }

        [Test, Description("Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public void VerifyCheckBoxesCheckedAfterCheckHome()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].CheckBox.Should.BeChecked();   

        }

    }

        //TODO: automate test cases
        //TC4 - Expand Home > Check Descktop Checkbox, verify checked
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        //TC6 - Expand Home > Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        //TC8 - Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
    
}
