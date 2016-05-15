using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DataAccess.Entities
{
	public class ExchangeRate
	{
		public long Id { get; set; }

		[Required]
		[MaxLength(3)]
		[Index("UX_CurrencyCode_Date", 1, IsUnique = true)]
		public string CurrencyCode { get; set; }

		public int Amount { get; set; }

		public decimal Rate { get; set; }

		[Index("UX_CurrencyCode_Date", 2, IsUnique = true)]
		public DateTime Date { get; set; }
	}
}
