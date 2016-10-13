using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using ThePeopleSearchApplication.Models;

namespace ThePeopleSearchApplication.DataAccessLayer
{
	public class PeopleSearchContext : DbContext
	{
		#region Properties

		/* Each property represents a DB table */
		public DbSet<Person> Persons { get; set; }
		public DbSet<Address> Addresses { get; set; }

		#endregion Properties

		#region Constructors

		public PeopleSearchContext() : base("PeopleSearchContext") /* Setting connection string (default is class name) */
		{

		}

		#endregion Constructors

		#region Methods

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); /* Use singular table names */
		}

		#endregion Methods


	}
}