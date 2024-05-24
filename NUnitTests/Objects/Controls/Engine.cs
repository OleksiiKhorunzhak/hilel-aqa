using NUnitTests.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Objects.Controls
{
    internal class Engine : BaseCar
    {
        //TODO Optimize AccelerationInput by DRY

        private byte Power { get; set; } = 255;

        //TODO Optimize Accelerate by KISS
        public byte? Accelerate(byte currentAcceleration)
        {
            if(0 >= currentAcceleration && currentAcceleration <= Power)
            {
                AccelerationInput = currentAcceleration;
                return AccelerationInput;
            }
            else
            {
                return 0;
            };
        }
    }
}
