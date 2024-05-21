using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;

namespace NUnitTests.Homework
{
    internal class LoopsAndCase
    {
       public readonly List<string> CarManufacturers =
        [
            "Toyota", "Ford", "Honda", "Chevrolet", "Nissan",
                        "BMW", "Mercedes-Benz", "Volkswagen", "Hyundai", "Audi"
        ];

        [Test, NUnit.Framework.Description("TODO use foreach loop to count all CarManufacturers names")]
        public void TestForeach()
        {
            int counter = 0;
            // apply next logic

            // foreach string name in CarManufacturers

            foreach (string name in CarManufacturers)
            {
                // if name length less or equal 5
                if (name.Length <= 5)
                    // increase counter
                {
                    counter++;
                }
            }
         
                // after loop end assert that counter is equal to 4
                
                    Assert.That(counter, Is.EqualTo(4));
        }

        [Test, NUnit.Framework.Description("TODO use while loop to get a new list of car brands where brand name is less than 5 characters.\r\n")]
        public void TestWhileLoop()
        {
            List<string> shortCarManufacturerNames = new List<string>();
            int counter = 0;

            // apply next logic

            // while counter less that CarManufacturers size and name length less or equal 5
            while (counter < CarManufacturers.Count)
            {
                if (CarManufacturers[counter].Length <= 5)
                {
                    // add current name into ShortCarManufacturerNames
                    shortCarManufacturerNames.Add(CarManufacturers[counter]);
                }
                // increment counter
                counter++;
            }

            // after loop foreach strings 'name' in ShortCarManufacturerNames assert name length less or equal than 5 characters  
            foreach (string name in shortCarManufacturerNames)
            {
               Assert.That(name.Length, Is.LessThanOrEqualTo(5), $"The name '{name}' should be less or equal 5 characters");
            }
        }

        [Test, NUnit.Framework.Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestForLoop()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);

            // caution - starting loop from last element to avoid modifying a collection while iterating over it

            // for index equal ShortCarManufacturerNames length - 1, while index less or equal 0, increment index
            for (int i = ShortCarManufacturerNames.Count - 1; i >= 0; i--)

            {
                // if ShortCarManufacturerNames by index .length is less or equal 5
                if (CarManufacturers[i].Length >= 5)
                {
                    // remove ShortCarManufacturerNames by index
                    ShortCarManufacturerNames.RemoveAt(i);
                }
            }
            // after loop finishes
            // foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 characters
            foreach (string name in ShortCarManufacturerNames)
            {
                Assert.That(name.Length, Is.LessThan(5), $"Name '{name}' should lees 5 characters");
            }
        }

        [Test, NUnit.Framework.Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestSwitchCaseSelection()
        {
            List<string> ShortCarManufacturerNames = new List<string>(CarManufacturers);
            int requestedIndex = 2;
            string selectedName = "Honda";


            // apply next logic

            // use switch case selection to select manufacturer by requestedIndex
            switch (requestedIndex)
            {
                // make cases from 0 to 9 as first index in list is 0

                // rewrite selectedName with ShortCarManufacturerNames by requestedIndex   
                case 0:
                    selectedName = ShortCarManufacturerNames[0];
                    break;
                case 1:
                    selectedName = ShortCarManufacturerNames[1];
                    break;
                case 2:
                    selectedName = ShortCarManufacturerNames[2];
                    break;
                case 3:
                    selectedName = ShortCarManufacturerNames[3];
                    break;
                case 4:
                    selectedName = ShortCarManufacturerNames[4];
                    break;
                case 5:
                    selectedName = ShortCarManufacturerNames[5];
                    break;
                case 6:
                    selectedName = ShortCarManufacturerNames[6];
                    break;
                case 7:
                    selectedName = ShortCarManufacturerNames[7];
                    break;
                case 8:
                    selectedName = ShortCarManufacturerNames[8];
                    break;
                case 9:
                    selectedName = ShortCarManufacturerNames[9];
                    break;

                default:
                    Assert.Fail("Invalid index");
                    break;
            }

            // Assert that string selectedName is eqal to expected string (for example 2 = "Honda")

            Assert.That(selectedName, Is.EqualTo("Honda"));
        }
    }
}
