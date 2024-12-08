using System;
using System.Collections.Generic;
using System.Linq;

// Abstract Teacher class
abstract class Teacher
{
	public string Code { get; set; }
	public string Name { get; set; }

	// Constructors
	public Teacher() { }
	public Teacher(string code, string name)
	{
		Code = code;
		Name = name;
	}

	// Abstract method to calculate salary
	public abstract double GetSalary();

	// Show information
	public virtual void Show()
	{
		Console.WriteLine($"Code: {Code}, Name: {Name}");
	}
}

// FulltimeTeacher class
class FulltimeTeacher : Teacher
{
	public double SalaryCoefficient { get; set; }

	// Constructors
	public FulltimeTeacher() { }
	public FulltimeTeacher(string code, string name, double salaryCoefficient) : base(code, name)
	{
		SalaryCoefficient = salaryCoefficient;
	}

	// Get salary
	public override double GetSalary()
	{
		return SalaryCoefficient * 2000000;
	}

	// Show information
	public override void Show()
	{
		base.Show();
		Console.WriteLine($"Salary Coefficient: {SalaryCoefficient}, Salary: {GetSalary()}");
	}
}

// ParttimeTeacher class
class ParttimeTeacher : Teacher
{
	public int NumberOfHours { get; set; }

	// Constructors
	public ParttimeTeacher() { }
	public ParttimeTeacher(string code, string name, int numberOfHours) : base(code, name)
	{
		NumberOfHours = numberOfHours;
	}

	// Get salary
	public override double GetSalary()
	{
		return NumberOfHours * 180000;
	}

	// Show information
	public override void Show()
	{
		base.Show();
		Console.WriteLine($"Number of Hours: {NumberOfHours}, Salary: {GetSalary()}");
	}
}

// Main Program
class Program
{
	static void Main(string[] args)
	{
		// Create a list of teachers
		List<Teacher> teachers = new List<Teacher>
		{
			new FulltimeTeacher("FT01", "Alice", 3.5),
			new FulltimeTeacher("FT02", "Bob", 4.0),
			new FulltimeTeacher("FT03", "Charlie", 2.8),
			new ParttimeTeacher("PT01", "David", 25),
			new ParttimeTeacher("PT02", "Eve", 15),
			new ParttimeTeacher("PT03", "Frank", 22),
			new FulltimeTeacher("FT04", "Grace", 3.2),
			new ParttimeTeacher("PT04", "Hank", 18),
			new ParttimeTeacher("PT05", "Ivy", 30),
			new FulltimeTeacher("FT05", "Jack", 4.5)
		};

		// a. Display all teachers
		Console.WriteLine("=== All Teachers ===");
		foreach (var teacher in teachers)
		{
			teacher.Show();
			Console.WriteLine();
		}

		// b. Show teachers with the highest salary
		double maxSalary = teachers.Max(t => t.GetSalary());
		Console.WriteLine("\n=== Teachers with the Highest Salary ===");
		foreach (var teacher in teachers.Where(t => t.GetSalary() == maxSalary))
		{
			teacher.Show();
			Console.WriteLine();
		}

		// c. Count part-time teachers with hours > 20
		int parttimeOver20Hours = teachers.OfType<ParttimeTeacher>().Count(pt => pt.NumberOfHours > 20);
		Console.WriteLine($"\nNumber of part-time teachers with hours > 20: {parttimeOver20Hours}");

		// d. Calculate total hours of part-time teachers
		int totalParttimeHours = teachers.OfType<ParttimeTeacher>().Sum(pt => pt.NumberOfHours);
		Console.WriteLine($"Total number of hours for part-time teachers: {totalParttimeHours}");
	}
}
