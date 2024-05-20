using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Objects
{
    internal abstract class BaseCar
    {
        public byte AccelerationInput { get; set; }

        public byte BreakInput { get; set; }

        public byte SteeringWheel { get; set; }

        public byte BreakSensor { get; set; }

        public byte BatteryChargeSensor { get; set; }

        public int Speed { get; set; }

        public byte Gear { get; set; }

        public byte BreakPower { get; set; }

        public int Charge { get; set; }
    }
}
