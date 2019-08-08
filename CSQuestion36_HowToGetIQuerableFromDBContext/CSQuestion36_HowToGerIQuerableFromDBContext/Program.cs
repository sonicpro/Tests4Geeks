using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;

namespace CSQuestion36_HowToGerIQuerableFromDBContext
{
	class Program
	{
		// The good explanation material to the topic is Mark Michaelis, Eric Lippert "Essential C# 6.0"; "Delegates vs Expression trees" chapter.
		static void Main(string[] args)
		{
			Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());

			using (NinjaContext dc = new NinjaContext())
			{
				dc.Database.Log = Console.WriteLine;

				// Data source matters - after translating the query expression to expression containing extenstion methods 
				// and lambdas, compiler choses whether to use extension methods from Enumerable or from Queryable.
				// If the latter is chosen, lambdas converted to expression trees in the form of Expression<delegate> rather than
				// plain delegates.

				// Standard query operator Where returns IEnumerable<Ninja> being provided with delegate argument,
				// but it returns IQueryable<Ninja> bing provided with expression tree argument.
				IQueryable<Ninja> onlyMikesQuery = from n in dc.Ninjas.Where(GetOnlyMikes())
													select n;

				var MikeNinjas = onlyMikesQuery.ToList();
			}

			// The following computes the delegate in-memory rather than pass it to IQueryProvider (possibly through
			// Provider property of IQueryable implementation). Delegate is required here rather than expression tree.
			var ninja = new Ninja { Name = "Mike" };
			var verifyIfPersonIsMike = GetVerifyingDelegate();
			bool personIsMike = verifyIfPersonIsMike(ninja); // If verifyIfPersonIsMike is an expression tree,
			// the following error occurs: "'verifyIfPersonIsMike' is a 'variable' but used like a 'method'".

			Console.WriteLine(personIsMike);

			Console.ReadKey();
		}


		private static Expression<Func<Ninja, bool>> GetOnlyMikes()
		{
			return n => n.Name == "Mike";
		}

		private static Func<Ninja, bool> GetVerifyingDelegate()
		{
			return n => n.Name == "Mike";
		}
	}
}
