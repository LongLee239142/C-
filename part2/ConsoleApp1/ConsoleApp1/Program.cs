using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.WriteLine("=== Email Validation Application ===");
			Console.Write("Enter an email address (or type 'exit' to quit): ");
			string email = Console.ReadLine();

			// Exit condition
			if (email.ToLower() == "exit")
			{
				Console.WriteLine("Exiting the application. Goodbye!");
				break;
			}

			// Handle empty input
			if (string.IsNullOrWhiteSpace(email))
			{
				Console.WriteLine("Input cannot be empty. Please try again.");
				continue;
			}

			// Regex for validating email
			string emailPattern = @"^[a-zA-Z][a-zA-Z0-9._]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$";

			if (Regex.IsMatch(email, emailPattern))
			{
				Console.WriteLine($"{email}");
				Console.WriteLine("\nThe email is valid.");
			}
			else
			{
				Console.WriteLine($"{email}");
				Console.WriteLine("\nThe email is invalid.");
			}
		}
	}
}
