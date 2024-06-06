using Atata;
using _ = AtataUITests.PageObjects.RadioButtonPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Text Box")]
    [Url("radio-button")]
    public sealed class RadioButtonPage : DemoQAPage<_>
    {
        [FindById(TermCase.LowerMerged)]
        public RadioButton<_> Option1 { get; private set; }

        [FindById(TermCase.LowerMerged)]
        public RadioButton<_> Option2 { get; private set; }
    }
}
