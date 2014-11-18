using System;
using System.Linq;

namespace RichDomain
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			using (var context = new MyContext()) {
				var person = context.Personer.Create();
				person.PersonNummer = new PersonNummer("11077941012");
				context.SaveChanges();
			}


			using (var context = new MyContext()) {
				var person = context.Personer.First(p => p.PersonNummer == "11077941012");
				Console.WriteLine(person.Name);
			}

			Console.ReadKey();
		}
	}
}
