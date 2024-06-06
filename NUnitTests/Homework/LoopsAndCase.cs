using System.Diagnostics.Metrics;

namespace NUnitTests.Homework
{
    internal class LoopsAndCase
    {
        public readonly List<string> CarManufacturers =
         [
             "Toyota", "Ford", "Honda", "Chevrolet", "Nissan",
                        "BMW", "Mercedes-Benz", "Volkswagen", "Hyundai", "Audi"
         ];

        [Test, Description("TODO use foreach loop to count all CarManufacturers names")]
        public void TestForeach()
        {
            int counter = 0;
            
            foreach (var car in CarManufacturers)
            {
                if (car.Length <=5)
                { counter++; }
            }
            Assert.That(counter, Is.EqualTo(4), "Some message");
        }

        [Test, Description("TODO use while loop to get a new list of car brands where brand name is less than 5 characters")]
        public void TestWhileLoop()
        {
            List<string> ShortCarManufacturerNames = new List<string>();
            int counter = 0;

            while (counter < CarManufacturers.Count)
            {
                string car = CarManufacturers[counter];
                if (car.Length < 5)
                {
                    ShortCarManufacturerNames.Add(car);
                }
                
                counter++;
            }

            Assert.That(ShortCarManufacturerNames, Has.Count.EqualTo(3),
                "ShortCarManufacturerNames does not contain 3 elements as expected");

            foreach (var car in ShortCarManufacturerNames)
            {
                Assert.That(car.Length, Is.LessThan(5));
            }
        }

        [Test, Description("TODO: Use for cycle to remove items from LongCarManufacturerNames that are less than 5 characters long")]
        public void TestForLoop()
        {
            List<string> longCarManufacturerNames = new (CarManufacturers);

            for (int i = 0; i < longCarManufacturerNames.Count; i++)
            {
                if (longCarManufacturerNames[i].Length <= 5)
                {
                    longCarManufacturerNames.RemoveAt(i);
                    i--;
                }
            }

            foreach (var car in longCarManufacturerNames)
            {
                Assert.That(car.Length, Is.GreaterThan(5));
            }
        }

        [Test, Description("TODO: Use switchCase")]
        public void TestSwitchCaseSelection()
        {
            List<string> newCarManufacturerNames = new (CarManufacturers);
            int requestedIndex = 0;
            string selectedName;

            switch (requestedIndex)
            {
                case 0:
                    selectedName = newCarManufacturerNames[0];
                    break;
                case 1:
                    selectedName = newCarManufacturerNames[1];
                    break;
                case 2:
                    selectedName = newCarManufacturerNames[2];
                    break;
                //and so on
                default: selectedName = "No such element in the List";
                    break;
            }

            Assert.That(selectedName == "Toyota");
        }
    }
}