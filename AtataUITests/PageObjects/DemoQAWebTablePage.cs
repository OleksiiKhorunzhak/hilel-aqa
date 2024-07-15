using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQAWebTablePage;

namespace AtataUITests.PageObjects
{
    [Url("webtables")]
    public sealed class DemoQAWebTablePage : DemoQAPage<_>
    {        
        public Button<_> Add{ get; private set; }

        public ReactAddPopup<_> AddPopup { get; private set; }

        public ReactTable<ReactRow<_>, _> WebTable { get; private set; }
        
    }
}