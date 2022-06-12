using Funda.Assignment.Danilo.Application.UseCases.Reports.RealEstateAgents.Dtos;
using Microsoft.Extensions.Logging;

namespace Funda.Assignment.Danilo.Console
{
    public static class Printer
    {
        public static void PrintRankList(IEnumerable<RealEstateAgentRankDto> rankList)
        {
            System.Console.WriteLine("--------------------------------------------");
            foreach (var rank in rankList.Select((value, i) => (value, i)))
            {
                System.Console.WriteLine($"{rank.i + 1} | {rank.value.Name} | {rank.value.NumberOfListings}");
            }
            System.Console.WriteLine("--------------------------------------------");
        }
    }
}
