using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;

using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;



namespace CnbCurrencyReader
{
	static class Program
	{
		static void Main(string[] args)
		{
			var exchangeYear = ConfigurationManager.AppSettings["ExchangeYear"];

			int year;
			if (!int.TryParse(exchangeYear, out year) || year < MinAvailableYear || year > DateTime.Now.Year)
			{
				Console.WriteLine("Invalid year \"{0}\". Foreign exchange market rates available from {1} up to the present.", exchangeYear, MinAvailableYear);
			}

			using (var webClient = new WebClient())
			{
				var data = webClient.DownloadData($"{ConfigurationManager.AppSettings["CnbYearExchangeRateUrl"]}{year}");

				using (var ms = new MemoryStream(data))
				{
					using (var reader = new StreamReader(ms))
					{
						var repository = new Repository<ExchangeRate>(
							new CnbExchangeRatesContext(ConfigurationManager.ConnectionStrings["ExchangeRateConnection"].ConnectionString));
						ExchangeInfo[] header = null;
						var exchangeRates = new List<ExchangeRate>();

						while (!reader.EndOfStream)
						{
							var line = reader.ReadLine();
							if (!string.IsNullOrEmpty(line))
							{
								if (line.StartsWith("Date"))
								{
									header = line
										.Split('|')
										.Skip(1)
										.Select(x => x.Split(' '))
										.Select(
											x => new ExchangeInfo
											{
												Amount = int.Parse(x[0]),
												CurrencyCode = x[1]
											})
										.ToArray();
								}
								else
								{
									var items = line.Split('|');

									var date = DateTime.ParseExact(items[0], "dd.MMM yyyy", CultureInfo.InvariantCulture);
									for (int i = 1; i < items.Length; i++)
									{
										var exchangeInfo = header[i - 1];

										exchangeRates.Add(new ExchangeRate
										{
											CurrencyCode = exchangeInfo.CurrencyCode,
											Amount = exchangeInfo.Amount,
											Date = date,
											Rate = decimal.Parse(items[i], CultureInfo.InvariantCulture)
										});
									}
								}
							}
						}

						repository.AddRange(exchangeRates.ToArray());
					}
				}
			}

			Console.WriteLine("Exchange rates successfully imported.");
		}

		private static readonly int MinAvailableYear = 1991;
	}
}
