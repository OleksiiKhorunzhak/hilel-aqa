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
            foreach (string name in CarManufacturers)
            {
                if (name.Length <= 5)
                {
                    counter++;
                }
            }
            Assert.That(counter, Is.EqualTo(4), $"{counter} is not equal to 4");
		}

        [Test, Description("TODO use while loop to get a new list of car brands where brand nama is less than 5 characters.\r\n")]
        public void TestWhileLoop()
        {
            List<string> ShortCarManufacturerNames = [];
            int counter = 0;
            string[] emptyArray = [];
            // apply next logic

            // while counter less thant CarManufacturers size and name length less or equal 5
            // add current name into ShortCarManufacturerNames
            // increment counter
            // after loop foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 
            
			while(counter < CarManufacturers.Count)
            {
                if (CarManufacturers[counter].Length <= 5)
                {
                    ShortCarManufacturerNames.Add(CarManufacturers[counter]);
                    counter++;
				}
				counter++;
			}
            foreach (string name in ShortCarManufacturerNames)
            {
                Assert.That(name.Length, Is.LessThanOrEqualTo(5), $"{name} lenght is not less or equal to 5");
            }
		}

        [Test, Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestForLoop()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);

            // apply next logic
            // caution - starting loop from last element to avoid modifying a collection while iterating over it

            // for index equal ShortCarManufacturerNames length - 1, while index less or equal 0, increment index
            // if ShortCarManufacturerNames by index .length is less or equal 5
            // remove ShortCarManufacturerNames by index
            // after loop finishes
            // foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters
            
            for (int i = ShortCarManufacturerNames.Count - 1; i >= 0; i--)
            {
                if (ShortCarManufacturerNames[i].Length >= 5)
                {
                    ShortCarManufacturerNames.RemoveAt(i);
                }
            }
            
            foreach (string name in ShortCarManufacturerNames)
            {
                Assert.That(name.Length, Is.LessThan(5), $"{name} lenght is not less or equal to 5");
			}
		}

        [Test, Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestSwitchCaseSelection()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);
            int requestedIndex = 2;
            string selectedName = "Honda";

            // apply next logic

            // use switch case selection to select manufacturer by requestedIndex
            // make cases from 0 to 9 as first index in list is 0
            // rewrite selectedName with ShortCarManufacturerNames by requestedIndex    
            // Assert that string selectedName is eqal to expected string (for example 2 = "Honda")
			string ?getName(int requestedIndex)
            {
                switch (requestedIndex)
                {
					case 1: return ShortCarManufacturerNames[1];
					case 2: return ShortCarManufacturerNames[2];
					case 3: return ShortCarManufacturerNames[3];
					case 4: return ShortCarManufacturerNames[4];
					case 5: return ShortCarManufacturerNames[5];
                    default: return null;
				}
            }
            string result = getName(requestedIndex);
            Assert.That(result, Is.EqualTo(selectedName), $"{result} is not equal to {selectedName}");

		}
    }
}
