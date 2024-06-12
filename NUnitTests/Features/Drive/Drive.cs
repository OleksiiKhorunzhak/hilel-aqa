namespace NUnitTests.Features.Drive
{
    //[TestFixture]
    internal class Drive : DrivePresetup
    {
        //Mocked data
        //TODO Refactor by DRY
        private static readonly byte ExpectedAccelerateInput = 255;
        private static readonly byte Speed = 68;
        private static readonly byte BreaksInput = 18;

        //TODO: Accelerate Test
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void AccelerateTest()
        {
            Assert.That(Accelerate, Is.EqualTo(ExpectedAccelerateInput), "Acceleration doest equal ExpectedAccelerateInput");
        }
        //TODO: Gear Test
        [Test]
        public void GearTest()
        {
            Assert.That(Gear, Is.EqualTo(4), "Gear not equal 4");
        }
        //TODO: Breaks Test
        [Test]
        public void BreaksTest()
        {
            Assert.That(BreaksPower, Is.EqualTo(18), "Break does not equal value");
        }

        [Test]
        public void PresetupTest()
        {
            DrivePresetup presetup = new DrivePresetup();
            //presetup.Accelerate;
        }
    }
}
