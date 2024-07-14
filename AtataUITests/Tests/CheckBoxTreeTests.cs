using Atata;
using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class CheckBoxTreeTests : UITestFixture
    {

        [Test, Retry(2)]
        [Category("UI")] 
        public void VerifyCheckBoxTreeeHomeCheckboxVisible()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BePresent().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeUnchecked().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeChecked();
        }

        [Test, Retry(2)]
        [Category("UI")]
        public void VerifyDocumentsCheckBoxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked();
        }

        //TODO: automate test cases
        //TC4 - Expand Home > Check Desktop Checkbox, verify checked
        [Test, Retry(2)]
        [Description("Expand Home > Check Desktop Checkbox, verify checked")]
        [Category("UI")]
        public void VerifyDesktopCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked();
        }
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        [Test, Retry(2)]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        [Category("UI")]
        public void VerifyWorkSpaceCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].CheckBox.Should.BeChecked();
        }
        //TC6 - Expand Home > Check Documents. Verify text 'You have selected : documents workspace react angular veu
        //office public private classified general'
        [Test, Retry(2)]
        [Description("Expand Home > Check Documents. Verify text 'You have selected :" +
            " documents workspace react angular veu office public private classified general")]
        [Category("UI")]
        public void VerifyTextAFterDocumentsCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                Result.Should.Be("You have selected :\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral");
        }
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct  icon-leaf-close icon
        [Test, Retry(2)]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct  icon-leaf-close icon")]
        [Category("UI")]
        public void VerifyReactChIcon()
        {
            Go.To<DemoQACheckBoxPage>().
                 CheckBoxTree.Should.BeVisible().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Title.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Style.Should.BeVisible();
        }

        //TC8 - Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked

        [Test, Retry(2)]
        [Description("Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        [Category("UI")]
        public void VerifyDesktopDocumentsDownloadsCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                 CheckBoxTree.Should.BeVisible().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].CheckBox.Should.BeChecked();
        }
    }
}
