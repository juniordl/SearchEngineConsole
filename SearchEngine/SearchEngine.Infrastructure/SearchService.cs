using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SearchEngine.Core.Entities;
using SearchEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchEngine.Infrastructure 
{ 
    public class SearchService: ISearchService
    {
        private readonly IConfigService _configSearcher;
        private readonly IRequestService _request;
        private readonly ILogger<SearchService> _logger;
        public SearchService(IConfigService configSearcher, IRequestService request, ILogger<SearchService> logger) 
        {
            this._configSearcher = configSearcher;
            this._request = request;
            this._logger = logger;
        }

        public async Task<List<Result>> SearchInWeb(List<string> words)
        {
            try
            {
                List<Result> results = new List<Result>();
                List<Searcher> searchers = _configSearcher.ConfigSearchers();

                foreach (var word in words)
                {
                    foreach (var searcher in searchers)
                    {

                        string uri = searcher.BuildUri().Replace("{query}", word);
                        HttpResponseMessage response = await _request.RequestAsync(uri, searcher.Headers);

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            results.Add(new Result(word, searcher.SearcherName, GetTotalMatches(content, searcher.NodesResult)));
                        }
                        else {
                            this._logger.LogWarning($"[{response.StatusCode}] The search engine: {searcher.SearcherName} not response");
                        }
                    }
                }
                return results;
            }
            catch (Exception ex) {
                this._logger.LogError($"{ex.Message} => {ex.StackTrace}");
                return new List<Result>();
            }
        }

        private decimal GetTotalMatches(string contentString, Dictionary<string, string> nodes)
        {
            decimal totalresults;

            Dictionary<string, object> searchResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(contentString);
            Dictionary<string, object> parent = JsonSerializer.Deserialize<Dictionary<string, object>>(searchResponse[nodes.ElementAt(0).Key].ToString());
            var child = parent[nodes.ElementAt(0).Value];
            totalresults = Convert.ToDecimal(child.ToString());

            return totalresults;
        }
    }
}
