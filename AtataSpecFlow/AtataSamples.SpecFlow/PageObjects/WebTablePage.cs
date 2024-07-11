using Atata;
using AtataSamples.SpecFlow.PageObjects.Controls;
using _ = AtataSamples.SpecFlow.PageObjects.WebTablePage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("webtables")]
    public sealed class WebTablePage : DemoQAPage<_>
    {
        public ReactTable<ReactHeader<_>, ReactRow<_>, _> Table { get; private set; }

        public ReactAddPopup<_> AddPopup { get; private set; }

        public Button<_> Add { get; private set; }

        [FindByPlaceholder("Type to search")]
        public TextInput<_> Search { get; private set; }
    }
}