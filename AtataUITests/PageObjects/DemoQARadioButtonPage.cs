using _ = AtataUITests.PageObjects.DemoQARadioButtonPage;

namespace AtataUITests.PageObjects
{
    [Url("radio-button")]
    public sealed class DemoQARadioButtonPage : DemoQAPage<_>
    {
        public ControlList<CustomRadioButton, _> RadioButtons { get; set; }

        [ControlDefinition("div", ContainingClass = "custom-radio", ComponentTypeName = "radio button")]
        public class CustomRadioButton : Control<_>
        {
            [ScrollTo]
            [FindByClass("custom-control-label")]
            public Label<_> Label { get; set; }

            [FindByClass("custom-control-input")]
            public RadioButton<_> RadioButton { get; set; }
        }

        [FindByClass("mt-3")]
        public Text<_> Text { get; set; }

        [FindByClass("text-center")]
        public Text<_> H1TitleRadioButton { get; set; }


    }
}
