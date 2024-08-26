using System.Drawing;

namespace DifferentExamples;

public static class MathOperations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}

[TestFixture]
public class StaticClassTests
{
    [Test]
    public void TestAdd()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = MathOperations.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void TestSubtract()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = MathOperations.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }
}
