using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson21;

// TODO: modify enum so CheckCustomIntNumbersForTestDataAgeEnum pass
public enum TestDataAge
{
    Child = 7,
    Teenager = 14,
    Adult = 30
}

//TODO: uncomment and implement tests so all Assert pass. Use such LINQ as Any(), Count(), Contains()
[TestFixture]
public class EnumHomework
{
    [Test]
    public void CheckCustomIntNumbersForTestDataAgeEnum()
    {

        Assert.That((int)TestDataAge.Child, Is.EqualTo(7));
        Assert.That((int)TestDataAge.Teenager, Is.EqualTo(14));
        Assert.That((int)TestDataAge.Adult, Is.EqualTo(30));
    }

    [Test]
    public void SomeIntCorrespondsToSomeTestDataAgeValue()
    {
        var listOfInt = new List<int>() { 5, 14, 15 };

        Dictionary<int, string> ageList = Enum.GetValues<TestDataAge>().ToDictionary(i => (int)i, t => t.ToString());
        var isAnyIntCorrespondsToTestDataAge = listOfInt.Any(i => ageList.ContainsKey(i));

        Assert.That(isAnyIntCorrespondsToTestDataAge, Is.True);
    }

    [Test]
    public void NumberOfIntCorrespondsToSomeTestDataAgeValue()
    {
        var listOfInt = new List<int>() { 5, 14, 15, 30 };
        Dictionary<int, string> ageList = Enum.GetValues<TestDataAge>().ToDictionary(i => (int)i, t => t.ToString());

        var numberOfIntCorrespondToTestDataAge = listOfInt.Where(i => ageList.ContainsKey(i)).Count();

        Assert.That(numberOfIntCorrespondToTestDataAge, Is.EqualTo(2));
    }

    [TestCaseSource(nameof(StringElementsArePresentInEnumCases))]
    public void StringElmentsArePresentInEnum(string[] list, int expectedNumberPresent, int expectedNumberExtra, bool areAllPresentExpected, bool areExtraElementsExpected)
    {
        var listOfString = list.ToList();

        // for the first test case { "Child", "Baby", "Teenager", "Eldery", "Adult" } there are only 3 (out of 5) strings "Child", "Teenager", "Adult" are present in TestDataAge
        // so for the first case numberOfStringsWhichPresentInEnum is 3
        Dictionary<int, string> ageList = Enum.GetValues<TestDataAge>().ToDictionary(i => (int)i, t => t.ToString());
        List<string> ages = ageList.Values.ToList();

        var numberOfStringsWhichPresentInEnum = listOfString.Where(i => ages.Contains(i)).Count();
        // "Baby" and "Eldery" are not present in TestDataAge, so numberOfStringsWhichAreNotPresentInEnum is 2
        var numberOfStringsWhichAreNotPresentInEnum = listOfString.Where(i => !ages.Contains(i)).Count();
        // for the first case not all strings are present in TestDataAge (only 3 out of 5 are present)), so expression result should be false
        bool areAllPresent = ages.All(i => ages.Contains(listOfString.ToString()));
		// for the first case, yes, there are 2 extra elements "Baby" and "Eldery", so result is true
		bool areExtraElements = ages.TrueForAll(i => listOfString.Count() != ages.Count());

		Assert.That(numberOfStringsWhichPresentInEnum, Is.EqualTo(expectedNumberPresent));
        Assert.That(numberOfStringsWhichAreNotPresentInEnum, Is.EqualTo(expectedNumberExtra));
        Assert.That(areAllPresent, Is.EqualTo(areAllPresentExpected));
        Assert.That(areExtraElements, Is.EqualTo(areExtraElementsExpected));
    }

	public static object[] StringElementsArePresentInEnumCases =
    {
            new object[] { new string[] { "Child", "Baby", "Teenager", "Eldery", "Adult" }, 3, 2, false, true },
			new object[] { new string[] { "Child", "Teenager", "Adult" }, 3, 0, true, false },
			new object[] { new string[] { "Baby", "Teenager", "Eldery" }, 1, 2, false, true },
			new object[] { new string[] { "Adult", "Child" }, 2, 0, true, false },
			new object[] { new string[] { "Eldery", "Baby" }, 0, 2, false, true },
			new object[] { new string[] { }, 0, 0, true, false },
	};
}