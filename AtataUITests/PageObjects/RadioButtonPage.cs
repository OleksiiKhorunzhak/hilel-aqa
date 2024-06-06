using Atata;
using _ = AtataUITests.PageObjects.RadioButtonPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Radio Button")]
    [Url("radio-button")]
    public sealed class RadioButtonPage : DemoQAPage<_>
    {
        //Texts:
        [FindByClass("text-center")]
        public Text<_> RadioButtonPageH1 { get; set; }

        [FindByClass("mb-3")]
        public Text<_> DoYouLikeText { get; set; }

        [FindByClass("mt-3")]
        public Text<_> SuccessText { get; set; }

        //Yes Radio:
        [FindById("yesRadio")]
        public RadioButton<_> YesRadio { get; set; }

        [FindByClass("custom-control-label")]
        public Label<_> YesLabel { get; set; }

        //Impressive Radio:
        [FindById("impressiveRadio")]
        public RadioButton<_> ImpressiveRadio { get; private set; }

        [FindByClass("custom-control-label")]
        public Label<_> ImpressiveLabel { get; set; }

        //No Radio:


    }
}
