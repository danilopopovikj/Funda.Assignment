using Funda.Assignment.Danilo.Application.UseCases.Reports.Listings;
using Funda.Assignment.Danilo.Console;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = DependencyInjection.BuildServiceProvider();

var rankingService = serviceProvider.GetRequiredService<IRealEstateAgentRankingService>();

var rankListForSale = await rankingService.RankByNumberOfListingsForSaleAsync(10);

var rankListForSaleWithGarden = await rankingService.RankByNumberOfListingsForSaleWithGardenAsync(10);

Console.WriteLine($"Top 10 Real Estate Agents by number of listings for sale:");

Printer.PrintRankList(rankListForSale);

Console.WriteLine("Top 10 Real Estate Agents by number of listings for sale with a garden: ");

Printer.PrintRankList(rankListForSaleWithGarden);
