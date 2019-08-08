using System;

namespace IncorrectAbstractClass
{
	class Program
	{
		static void Main(string[] args)
		{
			var car = new Car();
			car.MaxSpeed = 200;
			Console.WriteLine(car.ConcreteMethod());
			car.Drive();
			Console.ReadKey();
		}
	}
}
