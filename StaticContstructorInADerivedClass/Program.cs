using System;

namespace StaticContstructorInADerivedClass
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Static fields are class-wise. The Static constructor in the derived class does\nnever set the static field of the base class.\nCountry is: \"{0}\"", Car.Country);

			var car = new Car(200, "manual");
			Console.WriteLine(string.Join(" ", new[] { car.MaxSpeed.ToString(), Car.Country }));
			Console.ReadKey();
		}
	}
}
