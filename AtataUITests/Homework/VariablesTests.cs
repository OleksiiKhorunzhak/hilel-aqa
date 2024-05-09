using AtataUITests;

namespace Homework
{
    public sealed class VariablesTests //: UITestFixture
    {
        protected static string Combine(int higth) => "higth equals " + higth;

        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below 

            int low = 32;
            int higth = 64;

            Assert.That(32 < 64, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            double part = 25.5;
            int whole = 100;

            Assert.That((part < whole), "part is not smaller than whole");
        }

        //TODO: uncomment and fix code below
        [Test]
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            string pattern = "higth equals " + higth;
            //Uncomment and fix code below
            string getCombinedString = Combine(higth);
            Assert.That(getCombinedString, Is.EqualTo(pattern), "Pattern is not equal to GetCombinedString");
        }
    }
}