namespace AtataUITests
{
    public sealed class SampleTests : UITestFixture
    {
        [Test]
        public void SampleTest() =>
            Go.To<OrdinaryPage>()
                .PageTitle.Should.Contain("Atata");

        [Test]
        [Description("TC-1 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below *

            //low = 32;
            //higth = 64;

            // Assert.That(32 < 64, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-2 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below **

            //part = 25.5;
            //whole = 100;

            //Assert("part is not smaller than whole");
        }

        [Test]
        [Description("TC-3 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            //TODO: uncomment and fix code below ***

            //ExpectedText = higth;
            //Pattern = "higth equals " + number;

            //("expected text not match actual text");
        }
    }
}
