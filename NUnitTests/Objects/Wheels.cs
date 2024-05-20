using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Objects
{
    internal class Wheels : BaseCar
    {
        public void Breaks(byte power)
        {
            BreakPower = power;
        }

    }
}
