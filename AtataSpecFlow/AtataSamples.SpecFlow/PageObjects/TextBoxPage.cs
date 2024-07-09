using Atata;
using _ = AtataSamples.SpecFlow.PageObjects.TextBoxPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }

        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

        [ScrollTo]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameText { get; set; }
    }
}
