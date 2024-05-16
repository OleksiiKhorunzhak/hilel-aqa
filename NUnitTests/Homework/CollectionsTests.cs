using NUnit.Framework.Legacy;
using System.Globalization;

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
            var expectedCity = UkrainianCitiesArray[0];
            Assert.That(UkrainianCitiesArray.GetValue(0), Is.EqualTo(expectedCity), "First city is not Kyiv");
            //Assert.That(UkrainianCitiesArray, Is.EqualTo(expectedCity), "First city is not Kyiv");
        }

        [Test]
        [Description("TC-41 city quantity expected to be 21")]
        public void ArrayLengthTest()
            Assert.That(UkrainianCitiesArray, Has.Length.EqualTo(21), "City quantity is not 21");
            //Assert.That(UkrainianCitiesArray, Is.EqualTo(expectedQuantity), "City quantity is not 21");
        }

        [Test]
        [Description("TC-42 sorted array should be in ascending order")]
        public void SortArrayTest()
        {
            string [] sortedArray = new string[UkrainianCitiesArray.Length];
            Array.Copy(UkrainianCitiesArray, sortedArray, UkrainianCitiesArray.Length);
            Array.Sort(sortedArray);
            //Array.Copy(*, sortedArray, UkrainianCitiesArray.Length);
            Assert.That(sortedArray, Is.Ordered, "The sorted array is not in ascending order.");
            CollectionAssert.IsOrdered(sortedArray, "The sorted array is not in ascending order.");
        }

        [Test]
        [Description("TC-42 array should not contain terrorist cities")]
        public void ArrayNotContainTest()
        {
            var terroristsCity = "Moskow";
            Assert.That(UkrainianCitiesArray, Does.Not.Contain(terroristsCity), "Terrorist city " + terroristsCity + " is not an Ukrainian city.");
            //(UkrainianCitiesArray, terroristsCity, "Terroris city " + terroristsCity + " is not Ukrainian city.");
        }

        [Test]
        [Description("TC-43 last city expected to be Rivne")]
        public void LastCityTest()
            var expectedLastCity = UkrainianCitiesArray.Last();
            var lastIndex = UkrainianCitiesArray.Length - 1;

            Assert.That(UkrainianCitiesArray.GetValue(lastIndex), Is.EqualTo(expectedLastCity), "The last city in the array is not Rivne");
            //Assert.That();
        }

        [Test]
        [Description("TC-44 ensure the list contains Kyiv")]
        public void ListContains()
            var cityToCheck = "Kyiv";

            Assert.That(UkrainianCitiesList, Does.Contain(cityToCheck), "List does not contain Kyiv");
            //(UkrainianCitiesList, cityToCheck, "List does not contain Kyiv");
        }

        [Test]
        [Description("TC-45 city list Count expected to be 21")]
        public void ListCountTest()
            Assert.That(UkrainianCitiesList, Has.Count.EqualTo(21), "City list count is not 21");
            //Assert.That(UkrainianCitiesList, Is.EqualTo(expectedCount), "City list count is not 21");
        }

        [Test]
        [Description("TC-46 adding a city increases list size")]
        public void AddCityIncreasesListSizeTest()
        {

            UkrainianCitiesList.Add("Korosten");

            Assert.That(UkrainianCitiesList, Has.Count.EqualTo(initialCount + 1), "Adding a city did not increase the list size as expected");
            Assert.That(UkrainianCitiesList.Count, Is.EqualTo(initialCount + 1), "Adding a city did not increase the list size as expected");
        }
    }
}