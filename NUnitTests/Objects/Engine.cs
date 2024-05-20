using NUnitTests.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Objects
{
    internal class Engine : BaseCar
    {
        //TODO Optimize AccelerationInput by DRY
        public byte AccelerationInput { get; set; }

        private byte Power { get; set; } = 255;

        //TODO Optimize Accelerate by KISS
        public byte Accelerate(byte currentAcceleration)
        {
            if (currentAcceleration <= Power)
            {
                AccelerationInput = currentAcceleration;
                return AccelerationInput;
            }
            if (currentAcceleration > Power)
            {
                return Power;
            }
            if (currentAcceleration < 0)
            {
                AccelerationInput = 0;
                return AccelerationInput;
            }
            if (currentAcceleration == Power)
            {
                AccelerationInput = Power;
                return AccelerationInput;
            }
            else
            {
                return 0;
            };
        }
    }
}
