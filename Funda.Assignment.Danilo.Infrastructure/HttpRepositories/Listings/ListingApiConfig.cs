namespace Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings
{
    public class ListingApiConfig
    {
        public string BaseUrl { get; set; } = default!;
        public string ApiKey { get; set; } = default!;
        public ListingsApiPaths Paths { get; set; } = default!;
    }
    public class ListingsApiPaths
    {
        public string Listings { get; set; } = default!;
    }
}
