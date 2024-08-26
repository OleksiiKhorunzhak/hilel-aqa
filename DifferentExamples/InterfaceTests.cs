using System.Drawing;

namespace DifferentExamples;

public interface IShape
{
    double GetArea();
    double GetPerimeter();
}

public interface IPrintable
{
    void Print();
}


public class Circle : IShape // what happens if I add , IPrintable ?
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
    //public void Print()
    //{
    //    Console.WriteLine($"Can I declare Print() if Rectangle does not implement IPrintable?");
    //}
}


public class Square : IShape, IPrintable
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double GetArea()
    {
        return Side * Side;
    }

    public double GetPerimeter()
    {
        return 4 * Side;
    }

    public void Print()
    {
        Console.WriteLine($"Square with side length {Side}");
        Console.WriteLine($"Area: {GetArea()}");
        Console.WriteLine($"Perimeter: {GetPerimeter()}");
    }
}

[TestFixture]
public class InterfaceTests
{

    [Test]
    public void Circle_GetArea_ReturnsCorrectValue()
    {
        // Arrange
        double radius = 5;
        Circle circle = new Circle(radius);
        double expectedArea = Math.PI * radius * radius;

        // Act
        double area = circle.GetArea();

        // Assert
        Assert.That(area, Is.EqualTo(expectedArea).Within(0.0001));
    }

    [Test]
    public void Circle_GetPerimeter_ReturnsCorrectValue()
    {
        // Arrange
        double radius = 5;
        Circle circle = new Circle(radius);
        double expectedPerimeter = 2 * Math.PI * radius;

        // Act
        double perimeter = circle.GetPerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(expectedPerimeter).Within(0.0001));
    }

    [Test]
    public void Rectangle_GetArea_ReturnsCorrectValue()
    {
        // Arrange
        double width = 4;
        double height = 5;
        Rectangle rectangle = new Rectangle(width, height);
        double expectedArea = width * height;

        // Act
        double area = rectangle.GetArea();

        // Assert
        Assert.That(area, Is.EqualTo(expectedArea));
    }

    [Test]
    public void Rectangle_GetPerimeter_ReturnsCorrectValue()
    {
        // Arrange
        double width = 4;
        double height = 5;
        Rectangle rectangle = new Rectangle(width, height);
        double expectedPerimeter = 2 * (width + height);

        // Act
        double perimeter = rectangle.GetPerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(expectedPerimeter));
    }

    [Test]
    public void Square_GetArea_ReturnsCorrectValue()
    {
        // Arrange
        double side = 4;
        Square square = new Square(side);
        double expectedArea = side * side;

        // Act
        double area = square.GetArea();

        // Assert
        Assert.That(area, Is.EqualTo(expectedArea));
    }

    [Test]
    public void Square_GetPerimeter_ReturnsCorrectValue()
    {
        // Arrange
        double side = 4;
        Square square = new Square(side);
        double expectedPerimeter = 4 * side;

        // Act
        double perimeter = square.GetPerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(expectedPerimeter));
    }

    [Test]
    public void Square_Print_PrintsCorrectly()
    {
        // Arrange
        double side = 4;
        Square square = new Square(side);

        // Act and Assert
        using (var sw = new System.IO.StringWriter())
        {
            Console.SetOut(sw);
            square.Print();
            string expectedOutput = $"Square with side length {side}\r\nArea: {square.GetArea()}\r\nPerimeter: {square.GetPerimeter()}\r\n";
            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }
    }
}
