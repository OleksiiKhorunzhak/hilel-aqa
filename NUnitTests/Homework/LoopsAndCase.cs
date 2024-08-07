﻿using System.Runtime.CompilerServices;

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
            foreach(string name  in CarManufacturers) 
            {
            if(name.Length<=5)
                { counter++; }
            
            }
            Assert.That(counter, Is.EqualTo(4),"Counter is not equal 4"); 
        }

        [Test, Description("TODO use while loop to get a new list of car brands where brand nama is less than 5 characters.\r\n")]
        public void TestWhileLoop()
        {
            List<string> ShortCarManufacturerNames=new List<string>();
            int counter = 0;


            string[] emptyArray = [];
            decimal number = 1.01M;

            // apply next logic

            // while counter less thant CarManufacturers size and name length less or equal 5
            // add current name into ShortCarManufacturerNames
            // increment counter
            // after loop foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 
            
            while (counter<CarManufacturers.Count)
            {
                if(CarManufacturers[counter].Length < 5)
                {
                    ShortCarManufacturerNames.Add(CarManufacturers[counter]);
                }
                counter++;


            }
            foreach(string name in ShortCarManufacturerNames)
           
            { 

            Assert.That(name.Length,Is.LessThan(5), $"The name '{name}' is more or equal 5 characters");

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

            for(int index=ShortCarManufacturerNames.Count-1;index>=0;index--)
            {
                if (ShortCarManufacturerNames[index].Length>=5)
                {
                    ShortCarManufacturerNames.RemoveAt(index);
                }
            }
            foreach(string name in ShortCarManufacturerNames)
            {
                Assert.That(name.Length, Is.LessThan(5), "Length is more or equal 5");
            }
        }

        [Test, Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestSwitchCaseSelection()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);
            int requestedIndex = 2;
            string selectedName="Honda";


            // apply next logic

            // use switch case selection to select manufacturer by requestedIndex
            // make cases from 0 to 9 as first index in list is 0
            // rewrite selectedName with ShortCarManufacturerNames by requestedIndex    
            // Assert that string selectedName is eqal to expected string (for example 2 = "Honda")
            switch (requestedIndex)
            {
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
            Assert.That(selectedName, Is.EqualTo("Honda"));
        }
    }
}
