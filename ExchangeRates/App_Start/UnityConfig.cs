using System.Configuration;
using System.Linq;
using System.Web.Mvc;

using DataAccess;

using ExchangeRates.Controllers;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;



namespace ExchangeRates
{
	public static class UnityConfig
	{
		public static void Initialize()
		{
			var container = new UnityContainer();

			RegisterTypes(container);

			FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
			FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}

		private static void RegisterTypes(IUnityContainer container)
		{
			ExchangeRatesDbRegistrar.Register(container, ConfigurationManager.ConnectionStrings["ExchangeRateConnection"].ConnectionString);

			container.RegisterType<HomeController>();
		}
	}
}
