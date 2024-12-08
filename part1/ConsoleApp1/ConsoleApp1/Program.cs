using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main(string[] args)
	{
		Console.Write("Input a phone number: ");
		string input = Console.ReadLine();

		// Regular expression to match the phone number format
		string pattern = @"(\d{4})(\d{3})(\d{3})";

		// Replacement pattern to format the phone number
		string replacement = "($1) $2-$3";

		// Validate and format the phone number
		if (Regex.IsMatch(input, @"^\d{10}$")) // Ensure the input is a valid 10-digit number
		{
			string formattedNumber = Regex.Replace(input, pattern, replacement);
			Console.WriteLine($"Formatted phone number: {formattedNumber}");
		}
		else
		{
			Console.WriteLine("Invalid phone number. Please enter a 10-digit number.");
		}
	}
}
