using AtataUITests;

namespace Homework
{
    public sealed class VariablesTests //: UITestFixture
    {
        protected static string Combine(int numberAtata) => "higth equals " + numberAtata;

        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            int low = 32;
            int higth = 64;

            Assert.That(32 < 64, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            double part = 25.5;
            int whole = 100;

            Assert.That(whole, Is.GreaterThan(part),"part is not smaller than whole");
        }

        [Test]
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            
            string Pattern = "higth equals " + higth;
            string GetCombinedString = Combine(higth);

            Assert.That(GetCombinedString, Is.EqualTo(Pattern), "expected text not match actual text");
        }
    }
}