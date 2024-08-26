namespace DifferentExamples;

[TestFixture]
public class IEnumerableTests
{
    
    [Test]
    public void TestWhere1()
    {
        var people = new List<Person>
        {
            new Person { Name = "John", Age = 25, City = "New York" },
            new Person { Name = "Anna", Age = 30, City = "London" },
            new Person { Name = "Mike", Age = 35, City = "New York" },
            new Person { Name = "Sara", Age = 20, City = "Paris" },
            new Person { Name = "Paul", Age = 28, City = "Berlin" }
        };

        var result = people.Where(p => p.City == "New York").ToList();
        var result1 = people.Where(p => p.City == "New York");

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result1.Count, Is.EqualTo(2));

            Assert.That(result[0].Name, Is.EqualTo("John"));
            Assert.That(result1.First().Name, Is.EqualTo("John"));

            Assert.That(result[1].Name, Is.EqualTo("Mike"));
            Assert.That(result1.Last().Name, Is.EqualTo("Mike"));

        });

        // IEnumerable VS List
        // List is IEnumerable, but IEnumerable is not only List
        Assert.That(result.Count, Is.EqualTo(result1.Count()));
        Assert.That(result.Count(), Is.EqualTo(result1.Count()));
        Assert.That(result1.Count, Is.EqualTo(result.Count));

        Assert.That(result[0], Is.EqualTo(result1.First()));
        Assert.That(result[0], Is.EqualTo(result1.ElementAt(0)));
        Assert.That(result[1], Is.EqualTo(result1.ElementAt(1)));
        Assert.That(result.ElementAt(1), Is.EqualTo(result1.ElementAt(1)));

        // result is List and IEnumerable, but result1 is IEnumerable only
        // so result has .Count from List, .Count() from IEnumerable, [0] from List and .ElementAt() from IEnumerable
    }

    [Test]
    public void TestWhere2()
    {
        var cities1 = new List<string> { "New York", "London", "Paris", "Berlin" };
        var cities2 = new HashSet<string> { "New York", "London", "Paris", "Berlin", "Berlin", "Berlin", "Berlin", "Berlin", "Berlin" };
        var cities3 = new string[] { "New York", "London", "Paris", "Berlin" };
        var cities4 = new Dictionary<int, string> { { 1, "New York" }, { 2, "London" }, { 3, "Paris" }, { 4, "Berlin" } };
        
        var expected1 = new string[] { "New York", "London", "Berlin" };
        var expected2 = expected1;
        var expected3 = expected1;
        var expected4 = new Dictionary<int, string> { { 1, "New York" }, { 2, "London" }, { 4, "Berlin" } };

        var result1 = cities1.Where(p => p.Length > 5);
        var result2 = cities2.Where(p => p.Length > 5);
        var result3 = cities3.Where(p => p.Length > 5);
        var result4 = cities4.Where(p => p.Value.Length > 5);

        Assert.Multiple(() =>
        {
            CollectionAssert.AreEqual(expected1, result1);
            CollectionAssert.AreEqual(expected2, result2);
            CollectionAssert.AreEqual(expected3, result3);
            CollectionAssert.AreEqual(expected4, result4);
        });

        var noError1 = cities1[0];
        //var error2 = cities2[0];
        var noError3 = cities3[0];
        var noError4 = cities4[0];

        //_ = cities1.TryGetValue("qwe", out var res1);
        _ = cities2.TryGetValue("qwe", out var res2);
        //_ = cities3.TryGetValue("qwe", out var res3);
        //_ = cities4.TryGetValue("qwe", out var res4);

        Assert.Multiple(() =>
        {
            Assert.That(GetCount(result1), Is.EqualTo(3));
            Assert.That(GetCount(result2), Is.EqualTo(3));
            Assert.That(GetCount(result3), Is.EqualTo(3));
            Assert.That(GetCount(result4), Is.EqualTo(3));
        });

    }

    private int GetCount<T>(IEnumerable<T> values)
    {
        //var error1 = values.Count;
        //var error2 = values[0];
        //var error3 = values.TryGetValue("qwe", out var res);

        return values.Count();
    }

}
