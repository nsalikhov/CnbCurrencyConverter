using DataAccess.Entities;
using DataAccess.Repositories;

using Microsoft.Practices.Unity;



namespace DataAccess
{
	public static class CnbExchangeRatesRegistrar
	{
		public static void Register(IUnityContainer container, string connectionString)
		{
			container.RegisterType<IRepository<ExchangeRate>>(
				new InjectionFactory(c => new Repository<ExchangeRate>(new CnbExchangeRatesContext(connectionString))));
		}
	}
}
