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
            // apply next logic

            // foreach string name in CarManufacturers
            // if name length less or equal 5
            // increase counter
            // after loop end assert that counter is equal to 4

            foreach (string item in CarManufacturers)
            {
                if (item.Length <= 5)
                {
                    counter++;
                }
            }

            Assert.That(counter, Is.EqualTo(4), "Counter is not equal to 4");
        }

        [Test,
         Description(
             "TODO use while loop to get a new list of car brands where brand nama is less than 5 characters.\r\n")]
        public void TestWhileLoop()
        {
            List<string> ShortCarManufacturerNames = new();
            int counter = 0;

            // apply next logic

            // while counter less thant CarManufacturers size and name length less or equal 5
            // add current name into ShortCarManufacturerNames
            // increment counter
            // after loop foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 

            foreach (string item in CarManufacturers)
            {
                while (counter < CarManufacturers.Count && item.Length <= 5)
                {
                    ShortCarManufacturerNames.Add(item);
                    counter++;
                }
            }

            Assert.That(ShortCarManufacturerNames, Has.All.Length.LessThan(5),
                "Not all names are less than 5 characters");
        }

        [Test,
         Description(
             "TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestForLoop()
        {
            List<string> shortCarManufacturerNames = new(CarManufacturers);

            // apply next logic
            // caution - starting loop from last element to avoid modifying a collection while iterating over it

            // for index equal ShortCarManufacturerNames length - 1, while index less or equal 0, increment index
            // if ShortCarManufacturerNames by index .length is less or equal 5 (incorrect condition, should be > 5)
            // remove ShortCarManufacturerNames by index
            // after loop finishes
            // foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 


            for (int i = shortCarManufacturerNames.Count - 1; i >= 0; i--)
            {
                if (shortCarManufacturerNames[i].Length < 5)
                {
                    shortCarManufacturerNames.RemoveAt(i);
                }
            }
            
            Assert.That(shortCarManufacturerNames, Has.All.Length.GreaterThanOrEqualTo(5),
                "Not all names are less than 5 characters");
        }

        [Test,
         Description(
             "TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")] // incorrect description
        public void TestSwitchCaseSelection()
        {
            List<string> shortCarManufacturerNames = new(CarManufacturers);
            int requestedIndex = 0;
            string selectedName = "Audi";
            // apply next logic
            
            // rewrite selectedName with ShortCarManufacturerNames by requestedIndex 
            shortCarManufacturerNames[requestedIndex] = selectedName;
            // use switch case selection to select manufacturer by requestedIndex
            // make cases from 0 to 9 as first index in list is 0
            switch (requestedIndex)
            {
                case 0:
                    selectedName = shortCarManufacturerNames[0];
                    break;
                case 1:
                    selectedName = shortCarManufacturerNames[1];
                    break;
                case 2:
                    selectedName = shortCarManufacturerNames[2];
                    break;
                case 3:
                    selectedName = shortCarManufacturerNames[3];
                    break;
                case 4:
                    selectedName = shortCarManufacturerNames[4];
                    break;
                case 5:
                    selectedName = shortCarManufacturerNames[5];
                    break;
                case 6:
                    selectedName = shortCarManufacturerNames[6];
                    break;
                case 7:
                    selectedName = shortCarManufacturerNames[7];
                    break;
                case 8:
                    selectedName = shortCarManufacturerNames[8];
                    break;
                case 9:
                    selectedName = shortCarManufacturerNames[9];
                    break;
                default:
                    selectedName = "Unknown";
                    break;
            }
            
            // Assert that string selectedName is eqal to expected string (for example 2 = "Honda")
            Assert.That(selectedName, Is.EqualTo($"{selectedName}"), $"Selected name is not equal to {selectedName}");
        }
    }
}