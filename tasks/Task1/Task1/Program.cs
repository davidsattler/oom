using System;
using System.Collections.Generic;

namespace Task1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int a = 5;
			int b = 6;
			int c = a * b;

			try
			{
				Console.WriteLine("Hello");
				throw new Exception("Something happened!");
				Console.WriteLine("World");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error now this: " + e.Message);
			}

			//Console.WriteLine("Hello World\n!" +x);
		}
	}
}
