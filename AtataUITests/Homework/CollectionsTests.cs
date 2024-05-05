using AtataUITests;
using NUnit.Framework.Legacy;

namespace Homework
{
    public sealed class CollectionsTests : UITestFixture
    {
        public string[] UkrainianCitiesArray =
        {
            "Kyiv",
            "Kharkiv",
            "Odesa",
            "Dnipro",
            "Donetsk",
            "Zaporizhzhia",
            "Lviv",
            "Kryvyi Rih",
            "Mykolaiv",
            "Mariupol",
            "Luhansk",
            "Vinnytsia",
            "Kherson",
            "Chernihiv",
            "Poltava",
            "Ternopil",
            "Cherkasy",
            "Khmelnytskyi",
            "Zhytomyr",
            "Sumy",
            "Rivne"
        };

        public List<string> UkrainianCitiesList = new List<string>
        {
            "Kyiv",
            "Kharkiv",
            "Odesa",
            "Dnipro",
            "Donetsk",
            "Zaporizhzhia",
            "Lviv",
            "Kryvyi Rih",
            "Mykolaiv",
            "Mariupol",
            "Luhansk",
            "Vinnytsia",
            "Kherson",
            "Chernihiv",
            "Poltava",
            "Ternopil",
            "Cherkasy",
            "Khmelnytskyi",
            "Zhytomyr",
            "Sumy",
            "Rivne",
        };

        [Test]
        [Description("TC-41 first expect to be Kyiv")]
        public void FirstCityTest()
        {
            //TODO: fix code below
            string expectedCity = "Kyiv";
            Assert.That(UkrainianCitiesArray, Is.EqualTo(expectedCity), "First city is not Kyiv");
        }

        [Test]
        [Description("TC-41 city quantity expected to be 21")]
        public void ArrayLengthTest()
        {
            //TODO: fix code below
            int expectedQuantity = 21;
            Assert.That(UkrainianCitiesArray, Is.EqualTo(expectedQuantity), "City quantity is not 21");
        }

        [Test]
        [Description("TC-42 sorted aray shoud be in ascending order")]
        public void SortArrayTest()
        {
            // Initialize a new string array of the same length as UkrainianCities
            string[] sortedArray = new string[UkrainianCitiesArray.Length];

            // Copy the contents of UkrainianCities into sortedArray
            //TODO: Uncomment and fix Copy() 
            //Array.Copy(*, sortedArray, UkrainianCitiesArray.Length);

            // Sort sortedArray in place
            //TODO: fix test below **
            //Array.*(sortedArray);

            // Assert that sortedArray is in ascending order
            CollectionAssert.IsOrdered(sortedArray, "The sorted array is not in ascending order.");
        }

        [Test]
        [Description("TC-42 array should not contain terrorist cities")]
        public void ArrayNotContainTest()
        {
            string terroristsCity = "Moskow";

            //TODO: Uncomment and put correct assert definition
            //(UkrainianCitiesArray, terroristsCity, "Terroris city " + terroristsCity + " is not Ukrainian city.");
        }

        [Test]
        [Description("TC-43 last city expected to be Rivne")]
        public void LastCityTest()
        {
            string expectedLastCity = "Rivne";
            int lastIndex = UkrainianCitiesArray.Length - 1;
            //TODO: Uncomment and put correct assert definition
            //Assert.That();
        }

        [Test]
        [Description("TC-44 ensure the list contains Kyiv")]
        public void ListContains()
        {
            string cityToCheck = "Kyiv";
            //TODO: Uncomment and put correct assert type and method
            //(UkrainianCitiesList, cityToCheck, "List does not contain Kyiv");
        }

        [Test]
        [Description("TC-45 city list Count expected to be 21")]
        public void ListCountTest()
        {
            int expectedCount = 21;
            //TODO: Fix asssertion
            Assert.That(UkrainianCitiesList, Is.EqualTo(expectedCount), "City list count is not 21");
        }

        [Test]
        [Description("TC-46 adding a city increases list size")]
        public void AddCityIncreasesListSizeTest()
        {
            var initialCount = UkrainianCitiesList.Count;
            //TODO: use Add() to add new city to cities list
            Assert.That(UkrainianCitiesList.Count, Is.EqualTo(initialCount + 1), "Adding a city did not increase the list size as expected");
        }
    }
}
