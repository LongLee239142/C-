using System;

abstract class Shape
{
	// Abstract property to identify the shape name
	public abstract string Name { get; }

	// Abstract methods to calculate area and perimeter
	public abstract double CalculateArea();
	public abstract double CalculatePerimeter();
}

class Circle : Shape
{
	public override string Name { get; } = "Circle";
	public double Radius { get; set; }

	public Circle(double radius)
	{
		Radius = radius;
	}

	public override double CalculateArea()
	{
		return Math.PI * Radius * Radius;
	}

	public override double CalculatePerimeter()
	{
		return 2 * Math.PI * Radius;
	}
}

class Rectangle : Shape
{
	public override string Name { get; } = "Rectangle";
	public double Length { get; set; }
	public double Width { get; set; }

	public Rectangle(double length, double width)
	{
		Length = length;
		Width = width;
	}

	public override double CalculateArea()
	{
		return Length * Width;
	}

	public override double CalculatePerimeter()
	{
		return 2 * (Length + Width);
	}
}

class Triangle : Shape
{
	public override string Name { get; } = "Triangle";
	public double SideA { get; set; }
	public double SideB { get; set; }
	public double SideC { get; set; }

	public Triangle(double sideA, double sideB, double sideC)
	{
		SideA = sideA;
		SideB = sideB;
		SideC = sideC;
	}

	public override double CalculateArea()
	{
		double s = (SideA + SideB + SideC) / 2; // Semi-perimeter
		return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
	}

	public override double CalculatePerimeter()
	{
		return SideA + SideB + SideC;
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Circle
		Console.WriteLine("Enter the details for the Circle:");
		Console.Write("Radius: ");
		double radius = double.Parse(Console.ReadLine());
		Circle circle = new Circle(radius);
		Console.WriteLine($"Area of {circle.Name} is: {circle.CalculateArea()}");
		Console.WriteLine($"Perimeter of {circle.Name} is: {circle.CalculatePerimeter()}");

		// Rectangle
		Console.WriteLine("\nEnter the details for the Rectangle:");
		Console.Write("Length: ");
		double length = double.Parse(Console.ReadLine());
		Console.Write("Width: ");
		double width = double.Parse(Console.ReadLine());
		Rectangle rectangle = new Rectangle(length, width);
		Console.WriteLine($"Area of {rectangle.Name} is: {rectangle.CalculateArea()}");
		Console.WriteLine($"Perimeter of {rectangle.Name} is: {rectangle.CalculatePerimeter()}");

		// Triangle
		Console.WriteLine("\nEnter the details for the Triangle:");
		Console.Write("Side A: ");
		double sideA = double.Parse(Console.ReadLine());
		Console.Write("Side B: ");
		double sideB = double.Parse(Console.ReadLine());
		Console.Write("Side C: ");
		double sideC = double.Parse(Console.ReadLine());
		Triangle triangle = new Triangle(sideA, sideB, sideC);
		Console.WriteLine($"Area of {triangle.Name} is: {triangle.CalculateArea()}");
		Console.WriteLine($"Perimeter of {triangle.Name} is: {triangle.CalculatePerimeter()}");
	}
}
