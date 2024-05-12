﻿
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

            Assert.That(low < higth, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            double part = 25.5;
            int whole = 100;

            Assert.That(part, Is.LessThan(whole),"part is not smaller than whole");
        }

        //TODO: uncomment and fix code below

        [Description("TC-23 text that represent higth should match expected pattern")]
        [Test]
        public void StringsTest()
        {
            int higth = 64;
            string Pattern = "higth equals " + higth;
            string GetCombinedString = Combine(higth);
            Assert.That(Pattern,Is.EqualTo(GetCombinedString),"expected text not match actual text");
        }

    }
}
