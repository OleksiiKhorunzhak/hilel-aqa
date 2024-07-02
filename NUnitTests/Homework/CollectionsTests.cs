using NUnit.Framework.Legacy;

namespace Homework
{
    public sealed class CollectionsTests
    {
        public string[] UkrainianCitiesArray =
        [
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
        ];

        public List<string> UkrainianCitiesList =
        [
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
        ];

        [Test]
        [Description("TC-41 first expect to be Kyiv")]
        public void FirstCityTest()
        {
            string expectedCity = "Kyiv";
            Assert.That(UkrainianCitiesArray[0], Is.EqualTo(expectedCity), "First city is not Kyiv");
        }

        [Test]
        [Description("TC-41 city quantity expected to be 21")]
        public void ArrayLengthTest()
        {
            int expectedQuantity = 21;
            Assert.That(UkrainianCitiesArray.Length, Is.EqualTo(expectedQuantity), "City quantity is not 21");
        }

        [Test]
        [Description("TC-42 sorted aray shoud be in ascending order")]
        public void SortArrayTest()
        {
            // Initialize a new string array of the same length as UkrainianCities
            string[] sortedArray = new string[UkrainianCitiesArray.Length];
            // Copy the contents of UkrainianCities into sortedArray
            Array.Copy(UkrainianCitiesArray, sortedArray, UkrainianCitiesArray.Length);
            // Sort sortedArray in place
            Array.Sort(sortedArray);
            // Assert that sortedArray is in ascending order
            Assert.That(sortedArray, Is.Ordered.Ascending, "The sorted array is not in ascending order.");
        }

        [Test]
        [Description("TC-42 array should not contain terrorist cities")]
        public void ArrayNotContainTest()
        {
            string unexpectedCity = "Some City";
            Assert.That(UkrainianCitiesArray, Is.Not.Contain(unexpectedCity), $"Unexpected city " + unexpectedCity + " is not Ukrainian city.");
        }

        [Test]
        [Description("TC-43 last city expected to be Rivne")]
        public void LastCityTest()
        {
            string expectedLastCity = "Rivne";
            int lastIndex = UkrainianCitiesArray.Length - 1;
            Assert.That(UkrainianCitiesArray[lastIndex], Is.EqualTo(expectedLastCity), "last city is not Rivne");
        }

        [Test]
        [Description("TC-44 ensure the list contains Kyiv")]
        public void ListContains()
        {
            string cityToCheck = "Kyiv";
            Assert.That(UkrainianCitiesList.Contains(cityToCheck), "List does not contain Kyiv");
        }

        [Test]
        [Description("TC-45 city list Count expected to be 21")]
        public void ListCountTest()
        {
            int expectedCount = 21;
            Assert.That(UkrainianCitiesList.Count, Is.EqualTo(expectedCount), "City list count is not 21");
        }

        [Test]
        [Description("TC-46 adding a city increases list size")]
        public void AddCityIncreasesListSizeTest()
        {
            string newCity = "New City";
            var initialCount = UkrainianCitiesList.Count;
            UkrainianCitiesList.Add(newCity);
            Assert.That(UkrainianCitiesList.Count, Is.EqualTo(initialCount + 1), "Adding a city did not increase the list size as expected");
            // Cleanup: Remove the added city
            UkrainianCitiesList.Remove(newCity);
            Assert.That(UkrainianCitiesList.Count, Is.EqualTo(initialCount), "Removing the city did not restore the list size as expected");
        }
    }
}
