using System;
namespace IncorrectAbstractClass
{
	abstract class Vehicle
	{
		public abstract int MaxSpeed { get; set; }

		// public abstract void Drive() - This is incorrect! It causes "Drive() cannot declare a body because it is marked abstract" compile-time error.
		public virtual void Drive()
		{
			Console.WriteLine("I'm drivind a vehicle.");
		}

		// This method has implementation.
		public string ConcreteMethod()
		{
			return "I'm the oldest!";
		}
	}
}
