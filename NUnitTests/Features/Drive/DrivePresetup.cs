using NUnitTests.Objects.Controls;

namespace NUnitTests.Features.Drive
{
    [TestFixture]
    public class DrivePresetup
    {
        public class InternalClass
        {
            public static byte InternalAccelerate { get; private set; }
        }

        // Property to hold the result of Engine.Accelerate
        public static byte Accelerate { get; private set; }
        // Property to hold the result of Transmission.Accelerate
        protected static byte Gear { get; private set; }
        // Property to hold the result of Transmission.Accelerate
        protected static byte BreaksPower { get; private set; }

        //Engine Accelerate sub feature presetup
        public void GetAcceleration(byte acceletareInput)
        {
            Engine engine = new Engine();
            Accelerate = (byte)engine.Accelerate(acceletareInput);
        }

        //Transmission sub feature Gear presetup
        public void SetGear(byte speedSensor)
        {
            Transmission transmission = new Transmission();
            transmission.ChangeGear(speedSensor);
            Gear = transmission.Gear;
        }

        //Breaks sub feature presetup
        public void CheckBreaks(byte breaksInput)
        {
            Wheels wheels = new Wheels();
            wheels.Breaks(breaksInput);
            BreaksPower = wheels.BreakPower;
        }

        [SetUp]
        public void DriveFeaturePresetup()
        {
            //Mocked test data
            byte AccelerateInput = 255;
            byte Speed = 68;
            byte BreaksInput = 18;

            GetAcceleration(AccelerateInput);
            SetGear(Speed);
            CheckBreaks(BreaksInput);
        }

        [TearDown]
        public void DriveFeatureTeardown()
        {
            //Mocked test data
            byte AccelerateInput = 0;
            byte Speed = 0;
            byte BreaksInput = 0;

            GetAcceleration(AccelerateInput);
            SetGear(Speed);
            CheckBreaks(BreaksInput);
        }
    }
}
