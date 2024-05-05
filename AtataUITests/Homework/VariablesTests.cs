using AtataUITests;

namespace Homework
{
    public sealed class VariablesTests : UITestFixture
    {
        //protected static string Combine(***) => "higth equals " + higth;

        [Test]
        [Description("TC-21 higth expected to be bigger than low")]
        public void IntegerTest()
        {
            //TODO: uncomment and fix code below 

            //low = 32;
            //higth = 64;

            // Assert.That(32 < 64, "higth is not bigger than low");
        }

        [Test]
        [Description("TC-22 part expected to be smaller than whole")]
        public void DecimalTest()
        {
            //TODO: uncomment and fix code below 

            //part = 25.5;
            //whole = 100;

            //Assert("part is not smaller than whole");
        }

        //TODO: uncomment and fix code below
        //***
        [Description("TC-23 text that represent higth should match expected pattern")]
        public void StringsTest()
        {
            int higth = 64;
            string Pattern = "higth equals " + higth;
            //Uncomment and fix code below
            //string GetCombinedString = Combine(higth);
            //Assert.***(***, ***, "expected text not match actual text");
        }

    }
}
