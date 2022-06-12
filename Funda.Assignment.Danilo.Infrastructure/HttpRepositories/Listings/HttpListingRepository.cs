using Funda.Assignment.Danilo.Application.Repositories;
using Funda.Assignment.Danilo.Domain;
using Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings
{
    public class HttpListingRepository : IListingRepository
    {
        private const int HTTPCLIENT_TIMEOUT_IN_SECONDS = 300;

        private readonly HttpClient _httpClient;
        private readonly ListingApiConfig _listingApiConfig;
        private readonly ILogger _logger;
        public HttpListingRepository(IHttpClientFactory httpClientFactory, ListingApiConfig listingApiConfig, ILogger<HttpListingRepository> logger)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(HttpListingRepository));
            _httpClient.Timeout = TimeSpan.FromSeconds(HTTPCLIENT_TIMEOUT_IN_SECONDS);

            _listingApiConfig = listingApiConfig;
            _logger = logger;
        }

        public async Task<IEnumerable<Listing>> GetListingsForSaleAsync()
        {
            return await GetListingsInParallel(false);
        }

        public async Task<IEnumerable<Listing>> GetListingsForSaleWithGardenAsync()
        {
            return await GetListingsSequentially(true);
        }

        private async Task<IEnumerable<Listing>> GetListingsSequentially(bool withGarden)
        {
            var uriBuilder = new UriBuilder(_listingApiConfig.BaseUrl +
                _listingApiConfig.Paths.Listings + "/json/" +
                _listingApiConfig.ApiKey + "/");

            var moreDataExists = true;
            var apiListings = new List<ApiListing>();

            var pageNumber = 1;
            // The API has an issue, only returns 25 objects, even though some other pageSize is sent.
            // Otherwise, we can make this configurable and "play" with it to optimize
            var pageSize = 25;

            // Logging purpose only
            var totalObjects = 0;

            while (moreDataExists)
            {
                uriBuilder.Query = GetQueryString(withGarden, pageNumber, pageSize);
                var response = await _httpClient.GetAsync(uriBuilder.ToString());
                var responseJson = await response.Content.ReadAsStringAsync();
                var listingsResponse = JsonConvert.DeserializeObject<GetListingsResponse>(responseJson);

                // Logging purpose only
                if (pageNumber == 1)
                    totalObjects = listingsResponse!.TotaalAantalObjecten;

                apiListings.AddRange(listingsResponse!.Objects);

                if (listingsResponse.TotaalAantalObjecten == apiListings.Count)
                {
                    moreDataExists = false;
                    break;
                }
                pageNumber++;
            }

            _logger.Log(LogLevel.Information, $"Total objects found: {totalObjects}");
            _logger.Log(LogLevel.Information, $"Total objects fetched: {apiListings.Count}");

            return apiListings
                .Select(x => new Listing
                {
                    MakelaarId = x.MakelaarId,
                    MakelaarNaam = x.MakelaarNaam
                });
        }

        private async Task<IEnumerable<Listing>> GetListingsInParallel(bool withGarden)
        {
            var uriBuilder = new UriBuilder(_listingApiConfig.BaseUrl +
                _listingApiConfig.Paths.Listings + "/json/" +
                _listingApiConfig.ApiKey + "/");

            var apiListings = new List<ApiListing>();

            var pageNumber = 1;
            // The API has an issue, only returns 25 objects, even though some other pageSize is sent.
            // Otherwise, we can make this configurable and "play" with it to optimize
            var pageSize = 25;

            uriBuilder.Query = GetQueryString(withGarden, pageNumber, pageSize);
            var response = await _httpClient.GetAsync(uriBuilder.ToString());

            var responseJson = await response.Content.ReadAsStringAsync();
            var listingsResponse = JsonConvert.DeserializeObject<GetListingsResponse>(responseJson);

            apiListings.AddRange(listingsResponse!.Objects.DistinctBy(x => x.Id));

            var totalRequestsNeeded = (int)Math.Ceiling((decimal)listingsResponse!.TotaalAantalObjecten / (decimal)pageSize) - 1;

            pageNumber++;

            // Start all requests
            var requests = new List<Task<HttpResponseMessage>>();
            for (int i = 0; i < totalRequestsNeeded; i++)
            {
                uriBuilder.Query = GetQueryString(withGarden, pageNumber, pageSize);
                requests.Add(_httpClient.GetAsync(uriBuilder.ToString()));
                pageNumber++;
            }
            // Wait for the responses
            var responses = await Task.WhenAll(requests);

            foreach (var resonse in responses)
            {
                var json = await response.Content.ReadAsStringAsync();
                var responseList = JsonConvert.DeserializeObject<GetListingsResponse>(responseJson);

                apiListings.AddRange(responseList!.Objects);
            }


            _logger.Log(LogLevel.Information, $"Total objects found: {listingsResponse!.TotaalAantalObjecten}");
            _logger.Log(LogLevel.Information, $"Total objects fetched: {apiListings.Count}");

            return apiListings
                .Select(x => new Listing { MakelaarId = x.MakelaarId, MakelaarNaam = x.MakelaarNaam });


        }

        private string GetQueryString(bool withGarden, int pageNumber, int pageSize)
        {
            var queryString = "?type=koop&zo=/amsterdam/";
            var paging = $"&page={pageNumber}&pagesize={pageSize}";

            if (withGarden)
                queryString += $"tuin/";

            queryString += paging;

            return queryString;
        }

    }
}
