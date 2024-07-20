namespace Lesson21;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

[TestFixture]
public class LinqTests
{
    [Test]
    public void TestWhere()
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

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Name, Is.EqualTo("John"));
            Assert.That(result[1].Name, Is.EqualTo("Anna"));
        });
    }

    [Test]
    public void TestSelect()
    {
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 22, City = "New York" },
            new Person { Name = "Bob", Age = 28, City = "San Francisco" },
            new Person { Name = "Charlie", Age = 32, City = "Chicago" },
            new Person { Name = "Diana", Age = 26, City = "Los Angeles" },
            new Person { Name = "Eve", Age = 29, City = "Seattle" }
        };

        var result = people.Select(p => p.Name).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo("Alice"));
            Assert.That(result[1], Is.EqualTo("Diana"));
        });
    }

    [Test]
    public void TestAny()
    {
        var people = new List<Person>
        {
            new Person { Name = "George", Age = 24, City = "Miami" },
            new Person { Name = "Helen", Age = 30, City = "Houston" },
            new Person { Name = "Ian", Age = 35, City = "Dallas" },
            new Person { Name = "Jane", Age = 21, City = "Austin" },
            new Person { Name = "Karen", Age = 27, City = "San Antonio" }
        };

        var result = people.Any(p => p.City == "Houston");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(result, Is.False);
        });
    }

    [Test]
    public void TestFirstOrDefault()
    {
        var people = new List<Person>
        {
            new Person { Name = "Larry", Age = 25, City = "Boston" },
            new Person { Name = "Megan", Age = 30, City = "Atlanta" },
            new Person { Name = "Nina", Age = 35, City = "Chicago" },
            new Person { Name = "Oliver", Age = 22, City = "Boston" },
            new Person { Name = "Paula", Age = 29, City = "Denver" }
        };

        var result = people.FirstOrDefault(p => p.City == "Denver");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Null);
            Assert.That(result.Name, Is.EqualTo("Paula"));
            Assert.That(result.Name, Is.EqualTo("Nina"));
        });
    }

    [Test]
    public void TestOrderBy()
    {
        var people = new List<Person>
        {
            new Person { Name = "Quinn", Age = 40, City = "Las Vegas" },
            new Person { Name = "Rachel", Age = 35, City = "Los Angeles" },
            new Person { Name = "Steve", Age = 30, City = "San Francisco" },
            new Person { Name = "Tom", Age = 25, City = "New York" },
            new Person { Name = "Uma", Age = 20, City = "Miami" }
        };

        var result = people.OrderBy(p => p.Age).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result[0].Age, Is.EqualTo(20));
            Assert.That(result[1].Age, Is.EqualTo(25));
            Assert.That(result[2].Age, Is.EqualTo(28));
            Assert.That(result[3].Age, Is.EqualTo(30));
            Assert.That(result[4].Age, Is.EqualTo(35));
            Assert.That(result[0].Age, Is.EqualTo(35));
        });
    }

    [Test]
    public void TestOrderByDescending()
    {
        var people = new List<Person>
        {
            new Person { Name = "Victor", Age = 45, City = "Seattle" },
            new Person { Name = "Wendy", Age = 40, City = "Portland" },
            new Person { Name = "Xander", Age = 35, City = "San Diego" },
            new Person { Name = "Yara", Age = 30, City = "Phoenix" },
            new Person { Name = "Zane", Age = 25, City = "Tucson" }
        };

        var result = people.OrderByDescending(p => p.Age).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result[0].Age, Is.EqualTo(45));
            Assert.That(result[1].Age, Is.EqualTo(40));
            Assert.That(result[2].Age, Is.EqualTo(35));
            Assert.That(result[3].Age, Is.EqualTo(30));
            Assert.That(result[4].Age, Is.EqualTo(25));
            Assert.That(result[0].Age, Is.EqualTo(25));
        });
    }

    [Test]
    public void TestGroupBy()
    {
        var people = new List<Person>
        {
            new Person { Name = "Adam", Age = 30, City = "San Francisco" },
            new Person { Name = "Brian", Age = 40, City = "San Francisco" },
            new Person { Name = "Charlie", Age = 35, City = "Los Angeles" },
            new Person { Name = "David", Age = 25, City = "New York" },
            new Person { Name = "Edward", Age = 28, City = "New York" }
        };

        var result = people.GroupBy(p => p.City).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.First(g => g.Key == "San Francisco").Count(), Is.EqualTo(2));
            Assert.That(result.First(g => g.Key == "New York").Count(), Is.EqualTo(1));
        });
    }

    [Test]
    public void TestSum()
    {
        var people = new List<Person>
        {
            new Person { Name = "Alex", Age = 20, City = "New York" },
            new Person { Name = "Bella", Age = 25, City = "Los Angeles" },
            new Person { Name = "Chris", Age = 30, City = "Chicago" },
            new Person { Name = "Diana", Age = 35, City = "Houston" },
            new Person { Name = "Ethan", Age = 40, City = "Phoenix" }
        };

        var result = people.Sum(p => p.Age);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(150));
            Assert.That(result, Is.EqualTo(100));
        });
    }

    [Test]
    public void TestAverage()
    {
        var people = new List<Person>
        {
            new Person { Name = "Fiona", Age = 22, City = "New York" },
            new Person { Name = "George", Age = 28, City = "San Francisco" },
            new Person { Name = "Hannah", Age = 32, City = "Chicago" },
            new Person { Name = "Ian", Age = 26, City = "Los Angeles" },
            new Person { Name = "Jane", Age = 29, City = "Seattle" }
        };

        var result = people.Average(p => p.Age);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(27.4));
            Assert.That(result, Is.EqualTo(30));
        });
    }

    [Test]
    public void TestMin()
    {
        var people = new List<Person>
        {
            new Person { Name = "Kevin", Age = 24, City = "Miami" },
            new Person { Name = "Laura", Age = 30, City = "Houston" },
            new Person { Name = "Michael", Age = 35, City = "Dallas" },
            new Person { Name = "Nina", Age = 21, City = "Austin" },
            new Person { Name = "Oscar", Age = 27, City = "San Antonio" }
        };

        var result = people.Min(p => p.Age);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(21));
            Assert.That(result, Is.EqualTo(25));
        });
    }

    [Test]
    public void TestMax()
    {
        var people = new List<Person>
        {
            new Person { Name = "Peter", Age = 33, City = "Boston" },
            new Person { Name = "Quincy", Age = 29, City = "Atlanta" },
            new Person { Name = "Rachel", Age = 36, City = "Chicago" },
            new Person { Name = "Steve", Age = 24, City = "Boston" },
            new Person { Name = "Tracy", Age = 32, City = "Denver" }
        };

        var result = people.Max(p => p.Age);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(36));
            Assert.That(result, Is.EqualTo(40));
        });
    }

    [Test]
    public void TestJoin()
    {
        var people = new List<Person>
        {
            new Person { Name = "Uma", Age = 45, City = "Seattle" },
            new Person { Name = "Vince", Age = 40, City = "Portland" },
            new Person { Name = "Wendy", Age = 35, City = "San Diego" },
            new Person { Name = "Xander", Age = 30, City = "Phoenix" },
            new Person { Name = "Yara", Age = 25, City = "Tucson" }
        };

        var cities = new List<string> { "Seattle", "Portland", "Phoenix" };

        var result = people.Join(
            cities,
            person => person.City,
            city => city,
            (person, city) => person).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Count, Is.EqualTo(2));
        });
    }
}
