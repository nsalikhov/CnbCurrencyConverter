using System.Data.Entity;

using DataAccess.Entities;



namespace DataAccess
{
	public class CnbExchangeRatesContext : DbContext
	{
		public CnbExchangeRatesContext(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<ExchangeRate> ExchangeRates { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ExchangeRate>().Property(x => x.Rate).HasPrecision(18, 3);
		}
	}
}
