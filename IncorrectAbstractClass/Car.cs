using System;

namespace IncorrectAbstractClass
{
	class Car : Vehicle
	{
		// Both get {} and set {} must be implemented in the first non-abstract descendant of an abstract class.
		public override int MaxSpeed { get; set; }

		public override void Drive()
		{
			Console.WriteLine("I'm driving the car.");
		}
	}
}
