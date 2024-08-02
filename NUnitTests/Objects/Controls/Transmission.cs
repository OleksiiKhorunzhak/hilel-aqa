namespace NUnitTests.Objects.Controls
{
    internal class Transmission : BaseCar
    {
        public void ChangeGear(int speed)
        {
            Gear = speed switch
            {
                < 0 => 0,
                < 20 => 1,
                < 40 => 2,
                < 60 => 3,
                < 80 => 4,
                < 100 => 5,
                _ => 0,
            };
        }
    }
}
