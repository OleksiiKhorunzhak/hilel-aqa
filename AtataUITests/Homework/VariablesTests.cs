using AtataUITests;
using System.Security.Cryptography.X509Certificates;

namespace Homework
{
    public sealed class VariablesTests // : UITestFixture
    {
        protected static string Combine(int higth) => "higth equals " + higth;

        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below 

            int low = 32;
            int higth = 64;

            Assert.That(higth > low, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            float part = 25.5F;
            int whole = 100;

            Assert.That(part < whole, "part is not smaller than whole");
        }

        //TODO: uncomment and fix code below
        //***
        [Test]
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            
            string Pattern = "higth equals " + higth;

            string GetCombinedString = "Combine(higth)";

            Assert.That(higth, Is.EqualTo(higth), "expected text not match actual text");
        }

    }
}
