﻿using Atata;
using _ = AtataSamples.SpecFlow.PageObjects.RadioButtonPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("radio-button")]
    public sealed class RadioButtonPage : _DemoQAPage<_>
    {
        public ControlList<CustomRadioButton, _> RadioButtons { get; set; }

        [ControlDefinition("div", ContainingClass = "custom-radio", ComponentTypeName = "radio button")]
        public class CustomRadioButton : Control<_>
        {
            [FindByClass("custom-control-label")]
            public Label<_> Label { get; set; }

            [FindByClass("custom-control-input")]
            public RadioButton<_> RadioButton { get; set; }
        }

        [FindByClass("mt-3")]
        public Text<_> Text { get; set; }
    }
}
