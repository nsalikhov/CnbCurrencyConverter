using System.Web.Optimization;



namespace ExchangeRates
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(
				new ScriptBundle("~/js").Include(
					"~/Scripts/jquery-{version}.js",
					"~/Scripts/bootstrap.js",
					"~/Scripts/knockout-{version}.js",
					"~/Scripts/jquery.datetimepicker.full.min.js"));

			bundles.Add(
				new StyleBundle("~/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/jquery.datetimepicker.min.css",
					"~/Content/site.css"));
		}
	}
}
