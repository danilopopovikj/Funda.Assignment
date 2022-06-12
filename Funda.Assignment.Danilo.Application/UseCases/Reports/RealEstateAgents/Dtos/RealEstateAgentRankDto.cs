using Funda.Assignment.Danilo.Domain;

namespace Funda.Assignment.Danilo.Application.UseCases.Reports.RealEstateAgents.Dtos
{
    public class RealEstateAgentRankDto : RealEstateAgent
    {
        public int NumberOfListings { get; set; }
    }
}
