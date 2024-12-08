using System;
using System.Collections.Generic;

// Interface IStudentManager
interface IStudentManager
{
	void AddStudent(Student student); // Thêm sinh viên mới
	void DisplayAllStudents(); // Hiển thị tất cả sinh viên
	double CalculateGPA(string studentID); // Tính GPA theo ID
}

// Class Student (Model)
class Student
{
	public string StudentID { get; set; }
	public string StudentName { get; set; }
	public double MathGrade { get; set; }
	public double PhysicsGrade { get; set; }
	public double ChemistryGrade { get; set; }

	// Constructor
	public Student(string studentID, string studentName, double mathGrade, double physicsGrade, double chemistryGrade)
	{
		StudentID = studentID;
		StudentName = studentName;
		MathGrade = mathGrade;
		PhysicsGrade = physicsGrade;
		ChemistryGrade = chemistryGrade;
	}

	// Display student information
	public override string ToString()
	{
		return $"ID: {StudentID}, Name: {StudentName}, Math: {MathGrade}, Physics: {PhysicsGrade}, Chemistry: {ChemistryGrade}";
	}
}

// Class StudentManager (Implements IStudentManager)
class StudentManager : IStudentManager
{
	private List<Student> students = new List<Student>();

	// Add a new student to the list
	public void AddStudent(Student student)
	{
		students.Add(student);
		Console.WriteLine("Student added successfully.");
	}

	// Display all students
	public void DisplayAllStudents()
	{
		if (students.Count == 0)
		{
			Console.WriteLine("No students found.");
			return;
		}

		Console.WriteLine("Student List:");
		foreach (var student in students)
		{
			Console.WriteLine(student.ToString());
		}
	}

	// Calculate GPA of a student based on their ID
	public double CalculateGPA(string studentID)
	{
		var student = students.Find(s => s.StudentID == studentID);
		if (student == null)
		{
			Console.WriteLine("Student not found.");
			return -1;
		}

		double gpa = (student.MathGrade + student.PhysicsGrade + student.ChemistryGrade) / 3;
		return Math.Round(gpa, 2);
	}
}

// Main Program
class Program
{
	static void Main(string[] args)
	{
		StudentManager studentManager = new StudentManager();

		while (true)
		{
			Console.WriteLine("\nStudent Grade Management System:");
			Console.WriteLine("1. Add Student");
			Console.WriteLine("2. Display All Students");
			Console.WriteLine("3. Calculate GPA");
			Console.WriteLine("4. Exit");
			Console.Write("Enter your choice: ");
			int choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					Console.Write("Enter Student ID: ");
					string id = Console.ReadLine();
					Console.Write("Enter Student Name: ");
					string name = Console.ReadLine();
					Console.Write("Enter Math Grade: ");
					double math = double.Parse(Console.ReadLine());
					Console.Write("Enter Physics Grade: ");
					double physics = double.Parse(Console.ReadLine());
					Console.Write("Enter Chemistry Grade: ");
					double chemistry = double.Parse(Console.ReadLine());

					Student newStudent = new Student(id, name, math, physics, chemistry);
					studentManager.AddStudent(newStudent);
					break;

				case 2:
					studentManager.DisplayAllStudents();
					break;

				case 3:
					Console.Write("Enter Student ID to calculate GPA: ");
					string studentID = Console.ReadLine();
					double gpa = studentManager.CalculateGPA(studentID);
					if (gpa != -1)
						Console.WriteLine($"GPA of Student {studentID}: {gpa}");
					break;

				case 4:
					Console.WriteLine("Exiting...");
					return;

				default:
					Console.WriteLine("Invalid choice. Please try again.");
					break;
			}
		}
	}
}
