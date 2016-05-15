using System;



namespace DataAccess.Entities
{
	public class ExchangeRate
	{
		public string CurrencyCode { get; set; }

		public int Amount { get; set; }

		public decimal Rate { get; set; }

		public DateTime Date { get; set; }
	}
}
