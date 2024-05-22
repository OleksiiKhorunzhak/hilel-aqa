using NUnit.Framework.Legacy;

namespace Homework
{
    public sealed class CollectionsTests
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
			//TODO: uncomment and fix code below
			string expectedCity = "Kyiv";
			string actualFirstCity = UkrainianCitiesArray.First();
			Assert.That(actualFirstCity, Is.EqualTo(expectedCity), "First city is not Kyiv");
		}

        [Test]
        [Description("TC-41 city quantity expected to be 21")]
        public void ArrayLengthTest()
        {
            //TODO: uncomment and fix code below
            int expectedQuantity = 21;
            var actualQuantiry = UkrainianCitiesArray.Length;
			Assert.That(actualQuantiry, Is.EqualTo(expectedQuantity), "City quantity is not 21");
        }


        // Initialize a new string array of the same length as UkrainianCities
        // Copy the contents of UkrainianCities into sortedArray
        //TODO: Uncomment and fix Copy() 
        // Sort sortedArray in place
        // Assert that sortedArray is in ascending order

		[Test]
        [Description("TC-42 sorted aray shoud be in ascending order")]
        public void SortArrayTest()
        
        {
			string[] sortedArray = new string[UkrainianCitiesArray.Length];
			Array.Copy(UkrainianCitiesArray,sortedArray, UkrainianCitiesArray.Length);
			Array.Sort(sortedArray);
			CollectionAssert.IsOrdered(sortedArray, "The sorted array is not in ascending order.");

        }

        [Test]
        [Description("TC-42 array should not contain terrorist cities")]
        public void ArrayNotContainTest()
        {
            string terroristsCity = "Moskow";

			//TODO: Uncomment and put correct assert definition
			CollectionAssert.DoesNotContain(UkrainianCitiesArray, terroristsCity, "Terroris city " + terroristsCity + " is not Ukrainian city.");
        }

        [Test]
        [Description("TC-43 last city expected to be Rivne")]
        public void LastCityTest()
        {
            string expectedLastCity = "Rivne";
            var lastIndex = UkrainianCitiesArray.Last();
            //TODO: Uncomment and put correct assert definition
            Assert.That(lastIndex, Is.EqualTo(expectedLastCity));
        }

        [Test]
        [Description("TC-44 ensure the list contains Kyiv")]
        public void ListContains()
        {
            string cityToCheck = "Kyiv";
            //TODO: Uncomment and put correct assert type and method
            CollectionAssert.Contains(UkrainianCitiesList, cityToCheck, "List does not contain Kyiv");
        }

        [Test]
        [Description("TC-45 city list Count expected to be 21")]
        public void ListCountTest()
        {
            int expectedCount = 21;
            var listCount = UkrainianCitiesList.Count();
            //TODO: Uncomment and ix asssertion
            Assert.That(expectedCount, Is.EqualTo(listCount), "City list count is not 21");
        }

        [Test]
        [Description("TC-46 adding a city increases list size")]
        public void AddCityIncreasesListSizeTest()
        {
            var initialCount = UkrainianCitiesList.Count;
            UkrainianCitiesList.Add("NewCity");
			//TODO: use Add() to add new city to cities list
			Assert.That(UkrainianCitiesList.Count, Is.EqualTo(initialCount + 1), "Adding a city did not increase the list size as expected");
        }
    }
}
