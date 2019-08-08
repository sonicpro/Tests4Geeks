using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassBy
{
	class Program
	{
		private static void ChangeNumber(ref int number)
		{
			number = 100;
		}

		private static void ChangeNumber(int? number)
		{
			// Reference variable pointers are passed by value!
			// You won't see 200 as soon as this function scope finishes.
			number = 200;
		}

		static void Main(string[] args)
		{
			//int number1;
			//ChangeNumber(ref number1); // incorrect, use out instead of ref. C# insist on local variables initialization.

			// Correctly initialize local variable to satisfy the compiler restriction.
			int? number2Nullable = null;
			ChangeNumber(number2Nullable);

			int number50 = 50;
			ChangeNumber(ref number50);

			Console.WriteLine(string.Join("; ", new[]
												{
													//string.Format("number1: {0}", number1),
													string.Format("number2Nullable: {0}", number2Nullable),
													string.Format("number50: {0}", number50)
												})
				);
			Console.ReadKey();
		}
	}
}
