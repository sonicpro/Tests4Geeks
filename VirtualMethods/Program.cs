using System;

namespace VirtualMethods
{
	public class Shape
	{
		public string GetName()
		{
			return "shape";
		}
	}

	public class Ball : Shape
	{
		public new string GetName()
		{
			return "ball";
		}
	}

	public class Pet
	{
		public virtual string GetName()
		{
			return "pet";
		}
	}

	public class Cat : Pet
	{
		public override string GetName()
		{
			return "cat";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Pet myPet = new Cat();
			Cat johnsCat = new Cat();
			Shape shape = new Ball();

			Console.WriteLine(string.Format("My {0} is playing with a {1}. Jonh's {2} is sleeping.",
				myPet.GetName(),
				shape.GetName(), // Compile-time variable type is used to resolve the method.
				johnsCat.GetName()));

			Console.ReadKey();
		}
	}
}
