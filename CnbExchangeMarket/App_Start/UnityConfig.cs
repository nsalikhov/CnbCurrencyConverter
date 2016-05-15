using System.Linq;
using System.Web.Mvc;

using CnbExchangeMarket.Controllers;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;



namespace CnbExchangeMarket
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
			container.RegisterType<HomeController>();
		}
	}
}
