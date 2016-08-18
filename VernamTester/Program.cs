using System;

namespace VernamTester
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKey end;

			do
			{
				Console.WriteLine("Key 1: Generate vernam from string.");
				Console.WriteLine("Key 2: Return string from vernam.");

				var key = "";

				while (key != "1" && key != "2")
				{
					Console.Write(">>>");
					key = Console.ReadLine();
				}

				if (key == "1")
				{
					Console.WriteLine("Enter string to generate vernam.");
					Console.Write(">>>");
					var str = Console.ReadLine();

					Console.WriteLine("Enter the row of the random number table to use.");
					Console.Write(">>>");
					var row = int.Parse(Console.ReadLine());

					Console.WriteLine("Result: {0}", Vernam.ToVernam(str, row));
				}

				else if (key == "2")
				{
					Console.WriteLine("Enter vernam to return string.");
					Console.Write(">>>");
					var str = Console.ReadLine();

					Console.WriteLine("Enter the used row of the random number table.");
					Console.Write(">>>");
					var row = int.Parse(Console.ReadLine());

					Console.WriteLine("Result: {0}", Vernam.FromVernam(str, row));
				}

				end = Console.ReadKey().Key;
			}
			while (end != ConsoleKey.Escape);			
		}
	}
}
