using _ = AtataUITests.PageObjects.DemoQARadioButtonPage;

namespace AtataUITests.PageObjects
{
    [Url("radio-button")]
    public sealed class DemoQARadioButtonPage : DemoQAPage<_>
    {
        [FindByClass("mt-3")]
        public Text<_> ResultText { get; set; }

        [FindByXPath("//input[@type='radio' and @id='yesRadio']/following-sibling::label")]
        public Clickable<_> YesButton { get; private set; }

        [FindByXPath("//input[@type='radio' and @id='impressiveRadio']/following-sibling::label")]
        public Clickable<_> ImpressiveButton { get; private set; }

        [FindByXPath("//input[@type='radio' and @id='noRadio']")]
        public Control<_> NoButton { get; private set; }

        [FindByClass("text-center")]
        public Text<_> Header { get; set; }

        public DemoQARadioButtonPage SelectRandomRadio()
        {
            int randomNumber = new Random().Next(1, 3);

            switch (randomNumber)
            {
                case 1:
                    {
                        YesButton.Click();
                        return this;
                    }
                case 2:
                    {
                        ImpressiveButton.Click();
                        return this;
                    }
                default: return this;
            }
        }
        public bool PageInDefaultState()
        {
            return !this.ResultText.IsVisible ? true : false;
        }
    }
}