using System;
using System.Linq;
using System.Web.Mvc;

using DataAccess.Entities;
using DataAccess.Repositories;



namespace CnbExchangeMarket.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(IRepository<ExchangeRate> exchangeRatesRepository)
		{
			_exchangeRatesRepository = exchangeRatesRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult ExchangeRates(DateTime exchangeDate)
		{
			var existingDate = _exchangeRatesRepository
				.All()
				.Where(x => x.Date <= exchangeDate)
				.OrderByDescending(x => x.Date)
				.Select(x => x.Date)
				.FirstOrDefault();

			if (existingDate != default(DateTime))
			{
				var exchangeRates = _exchangeRatesRepository
					.All()
					.Where(x => x.Date == existingDate)
					.ToArray();

				return Json(exchangeRates, JsonRequestBehavior.AllowGet);
			}

			return Json(null, JsonRequestBehavior.AllowGet);
		}

		private readonly IRepository<ExchangeRate> _exchangeRatesRepository;
	}
}
