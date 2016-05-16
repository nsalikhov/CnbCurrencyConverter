using System;
using System.Linq;
using System.Web.Mvc;

using DataAccess.Entities;
using DataAccess.Repositories;



namespace ExchangeRates.Controllers
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
			var exchangeRates = from exchangeRate in _exchangeRatesRepository.All
								let existingDate = from t in _exchangeRatesRepository.All
													where t.Date <= exchangeDate
													orderby t.Date descending
													select new { t.Date }
								where exchangeRate.Date == existingDate.FirstOrDefault().Date
								select exchangeRate;

			return Json(exchangeRates.ToArray(), JsonRequestBehavior.AllowGet);
		}

		private readonly IRepository<ExchangeRate> _exchangeRatesRepository;
	}
}
