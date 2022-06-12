using Funda.Assignment.Danilo.Domain;

namespace Funda.Assignment.Danilo.Application.Repositories
{
    public interface IListingRepository
    {
        public Task<IEnumerable<Listing>> GetListingsForSaleAsync();
        public Task<IEnumerable<Listing>> GetListingsForSaleWithGardenAsync();
    }
}
