﻿using System.Web.Optimization;



namespace CnbExchangeMarket
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(
				new ScriptBundle("~/js").Include(
					"~/Scripts/jquery-{version}.js",
					"~/Scripts/bootstrap.js",
					"~/Scripts/knockout-{version}.js"));

			bundles.Add(
				new StyleBundle("~/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/site.css"));
		}
	}
}
