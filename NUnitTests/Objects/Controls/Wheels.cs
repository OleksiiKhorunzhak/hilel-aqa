namespace NUnitTests.Objects.Controls
{
    internal class Wheels : BaseCar
    {
        public void Breaks(byte power)
        {
            BreakPower = power;
        }

    }
}
