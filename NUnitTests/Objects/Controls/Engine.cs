namespace NUnitTests.Objects.Controls
{
    internal class Engine : BaseCar
    {
        //TODO Optimize AccelerationInput by DRY
        private byte Power { get; set; } = 255;

        //TODO Optimize Accelerate by KISS
        public byte Accelerate(byte currentAcceleration)
        {
            if (currentAcceleration >= 0 && currentAcceleration <= Power)
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
