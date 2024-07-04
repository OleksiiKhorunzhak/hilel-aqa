using AtataUITests.PageObjects;
using _ = AtataUITests.PageObjects.ElementsPage;

namespace AtataUITests.PageObjects
{
    [Url("elements")]
    [VerifyContent("Please select an item from left to start practice.")]
    public sealed class ElementsPage : DemoQAPage<_>
    {
        [FindById("item-0")]
        public Clickable<TextBoxPage, _> TextBox { get; private set; }
        
        [FindById("item-1")]
        public Clickable<CheckBoxPage, _> CheckBox { get; private set; }

        [FindById("item-2")]
        public Clickable<RadioButtonPage, _> RadioButton { get; private set; }

        [FindById("item-3")]
        public Clickable<WebTablesPage, _> WebTables { get; private set; }

        [FindById("item-4")]
        public Clickable<ButtonsPage, _> Buttons { get; private set; }

        [FindById("item-5")]
        public Clickable<LinksPage, _> Links { get; private set; }

        [FindById("item-6")]
        public Clickable<BrokenLinksPage, _> BrokenLinks { get; private set; }

        [FindById("item-7")]
        public Clickable<UploadDownloadPage, _> UploadAndDownload { get; private set; }

        [FindById("item-8")]
        public Clickable<DynamicPropertiesPage, _> DynamicProperties { get; private set; }
    }
}
