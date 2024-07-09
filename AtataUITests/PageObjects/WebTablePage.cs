using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.WebTablePage;

namespace AtataUITests.PageObjects
{
    [Url("webtables")]
    public sealed class WebTablePage : DemoQAPage<_>
    {
        public ReactTable<ReactHeader<_>, ReactRow<_>, _> Table { get; private set; }

        public ReactHeader<_> Header { get; private set; }

        public ReactRow<_> Row { get; private set; }

        public ReactAddPopup<_> AddPopup { get; private set; }

        public Button<_> Add { get; private set; }

        [FindByPlaceholder("Type to search")]
        public TextInput<_> Search { get; private set; }
    }
}
