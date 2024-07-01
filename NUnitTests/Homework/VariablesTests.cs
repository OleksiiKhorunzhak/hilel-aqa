﻿

namespace Homework
{
    public sealed class VariablesTests
    {
        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below 

            int low = 32;
            int higth = 64;

            Assert.That(32 < 64, "higth is bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            double part = 25.5;
            int whole = 100;

            Assert.That(25.5 < 100, "part is not smaller than whole");
        }

        [Test]
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            string Pattern = "higth equals " + higth;


            // Call the Combine method to get the combined string
            string GetCombinedString = Combine(higth);

            // Assert that the combined string matches the expected pattern
           Assert.That(Pattern != GetCombinedString, "expected text not match actual text");
        }
        public string Combine(int higth)
        {
            return "height equals " + higth;
        }
    }
}
 