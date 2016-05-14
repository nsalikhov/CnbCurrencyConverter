using System;
using System.Configuration;
using System.IO;
using System.Net;



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
						while (!reader.EndOfStream)
						{
							var line = reader.ReadLine();
							if (!string.IsNullOrEmpty(line))
							{
								if (line.StartsWith("Date"))
								{
									// read n split currencies codes
								}
								else
								{
									// read n split currencies values
								}
							}
						}
					}
				}
			}
		}

		private static readonly int MinAvailableYear = 1991;
	}
}
