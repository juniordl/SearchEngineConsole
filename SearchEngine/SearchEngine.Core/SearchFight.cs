using Microsoft.Extensions.Configuration;
using SearchEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Core.Entities;

namespace SearchEngine.Core
{
    public class SearchFight
    {
        private readonly ISearchService _searchService;
        private readonly IHighlightsOutput _highlights;

        public SearchFight(ISearchService searchService, IHighlightsOutput highlights) {
            this._searchService = searchService;
            this._highlights = highlights;
        }

        public async Task Search(string[] words) {

            List<Result> results = await _searchService.SearchInWeb(new List<string>(words));
            await _highlights.WriteOutput(results);
        }
    }
}
