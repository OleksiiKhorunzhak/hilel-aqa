namespace NUnitTests.Features.Drive
{
    [TestFixture]
    internal class Drive : DrivePresetup
    {
        //Mocked data
        public byte AccelerateInput = 255;
        public byte Speed = 68;
        public byte BreaksInput = 18;
        public byte ExpectedGear = 4;

        //Accelerate Test
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void AccelerateTest()
        {
            Assert.That(Accelerate, Is.EqualTo(AccelerateInput), "Acceleration doest equal AccelerateInput");
        }
        //Gear Test
        [Test]
        public void GearTest()
        {
            Assert.That(Gear, Is.EqualTo(ExpectedGear), "Gear not equal 4");
        }
        //Breaks Test
        [Test]
        public void BreaksTest()
        {
            Assert.That(BreaksPower, Is.EqualTo(BreaksInput), "Break does not equal value");
        }

        [Test]
        public void PresetupTest()
        {
            DrivePresetup presetup = new DrivePresetup();
            //presetup.Accelerate;
        }
    }
}
