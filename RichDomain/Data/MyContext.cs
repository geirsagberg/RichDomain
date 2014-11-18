using System;
using System.Data.Entity;

namespace RichDomain
{
	public class MyContext : DbContext
	{
		public MyContext ()
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<Person> Personer { get; set; }

	}

	public class Person
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public PersonNummer PersonNummer { get; set; }
	}

	public class PersonNummer
	{

		public string Value { get; private set; }

		private PersonNummer ()
		{
		}

		public PersonNummer (string value) : this ()
		{
			if (value.Length != 11)
				throw new ArgumentException ("PersonNummer must be 11 chars");
			this.Value = value;
		}

		public static implicit operator string (PersonNummer personNummer)
		{
			return personNummer.Value;
		}

		public static implicit operator PersonNummer (string str)
		{
			return new PersonNummer (str);
		}
	}
}

