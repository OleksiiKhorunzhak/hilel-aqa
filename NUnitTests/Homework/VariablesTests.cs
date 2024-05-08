using System;

namespace Homework
{
    public sealed class VariablesTests
    {
        protected static string Combine(int higth) => "higth equals " + higth;

        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below 

            int low = 32;
            int higth = 64;
            Assert.That(low, Is.LessThan(higth), $"{higth} is not bigger than {low}");
		}

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            double part = 25.5;
            int whole = 100;

            Assert.That(part, Is.LessThan((double)whole), $"{part} is not smaller than {whole}");
        }

        //TODO: uncomment and fix code below

        //Is not a test if missed [Test] attribute
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            string Pattern = "higth equals " + higth;
            //Uncomment and fix code below
            string GetCombinedString = Path.Combine(Pattern); //this part is wrong
            Assert.That(GetCombinedString, Is.EqualTo(Pattern), "Expected text not match actual text");
        }

        //TODO: example for 3 test
        [Test]
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest2()
        {
            int higth = 64;
            string Pattern = "higth equals " + higth;
            //Uncomment and fix code below
            string GetCombinedString = Combine(higth);
            //Assert.***(***, ***, "expected text not match actual text");
        }
    }
}
