using System;

abstract class Product
{
	// Abstract properties
	public abstract string Name { get; set; }
	public abstract decimal Price { get; set; }

	// Abstract method to calculate discount
	public abstract decimal CalculateDiscount();
}

class ElectronicsProduct : Product
{
	public override string Name { get; set; }
	public override decimal Price { get; set; }
	public int WarrantyPeriod { get; set; } // Warranty period in months

	public override decimal CalculateDiscount()
	{
		if (WarrantyPeriod > 12)
			return Price * 0.2m; // 20% discount
		else
			return Price * 0.1m; // 10% discount
	}
}

class ClothingProduct : Product
{
	public override string Name { get; set; }
	public override decimal Price { get; set; }
	public string Size { get; set; } // Sizes: S, M, L, XL, XXL

	public override decimal CalculateDiscount()
	{
		if (Size == "S" || Size == "M" || Size == "L")
			return Price * 0.15m; // 15% discount
		else if (Size == "XL" || Size == "XXL")
			return Price * 0.1m; // 10% discount
		else
			return 0; // No discount for invalid size
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Input details for ElectronicsProduct
		Console.WriteLine("Enter details for Electronics Product:");
		ElectronicsProduct electronics = new ElectronicsProduct();
		Console.Write("Name: ");
		electronics.Name = Console.ReadLine();
		Console.Write("Price: $");
		electronics.Price = decimal.Parse(Console.ReadLine());
		Console.Write("Warranty Period (months): ");
		electronics.WarrantyPeriod = int.Parse(Console.ReadLine());
		decimal electronicsDiscount = electronics.CalculateDiscount();
		Console.WriteLine($"Discount for {electronics.Name}: ${electronicsDiscount}");

		// Input details for ClothingProduct
		Console.WriteLine("\nEnter details for Clothing Product:");
		ClothingProduct clothing = new ClothingProduct();
		Console.Write("Name: ");
		clothing.Name = Console.ReadLine();
		Console.Write("Price: $");
		clothing.Price = decimal.Parse(Console.ReadLine());
		Console.Write("Size (S/M/L/XL/XXL): ");
		clothing.Size = Console.ReadLine();
		decimal clothingDiscount = clothing.CalculateDiscount();
		Console.WriteLine($"Discount for {clothing.Name}: ${clothingDiscount}");
	}
}
