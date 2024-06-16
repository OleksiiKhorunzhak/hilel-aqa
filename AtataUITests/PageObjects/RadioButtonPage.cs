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
        public RadioButton<_> YesRadioButton { get; set; }

        [FindByClass("custom-control-label")]
        public Label<_> YesLabel { get; set; }

        //Impressive Radio:
        [FindById("impressiveRadio")]
        public RadioButton<_> ImpressiveRadioButtom{ get; set; }

        [FindByLabel("Impressive")]
        public Label<_> ImpressiveLabel { get; set; }

        //No Radio:
        [FindById("noRadio")]
        public RadioButton<_> NoRadioButton { get; set; }

        [FindByClass("custom-control-label")]
        public Label<_> NoLabel { get; set; }
    }
}
