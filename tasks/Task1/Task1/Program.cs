using System;
using System.Collections.Generic;

namespace Task1
{

	// A person.
	class Person
	{
		public string Name { get; }
		public DateTime DateOfBirth { get; }
		public bool HasBirthday
		{
			get
			{
				return DateTime.Now.Month == DateOfBirth.Month
					&& DateTime.Now.Day == DateOfBirth.Day;
			}
		}

		// Constructor.
		public Person(string name, DateTime dateOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
		}

	}

	// Customer is derived from Person.
	// It has a Name, a DateOfBirth and a HasBirthday property.
	// Additionally to the inherited properties, it also has a CustomerId.
	class Customer : Person
	{
		public int CustomerId { get; }

		// Customer constructor calls inherited Person constructor via ': base(...)' ...
		public Customer(string name, DateTime dateOfBirth, int customerId)
			: base(name, dateOfBirth)
		{
			// ... and initializes remaining members not inherited from base class
			CustomerId = customerId;

		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{
			Person x = new Person("Alice", new DateTime(1984, 2, 23));
			Customer y = new Customer("Bob", new DateTime(1993, 5, 17), 999123);

			Console.WriteLine("C_ID of y= {0}", y.CustomerId);
			//Console.WriteLine("Hello World\n!" +x);
		}
	}
}