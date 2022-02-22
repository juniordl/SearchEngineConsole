using SearchEngine.Core.Entities;
using SearchEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchEngine.Infrastructure
{
    public class HighlightsOutput : IHighlightsOutput
    {

        private readonly IConfigService _configService;

        public HighlightsOutput(IConfigService configService) {
            this._configService = configService;
        }

        public Task WriteOutput(List<Result> results)
        {
            return Task.Run(() =>
            {
                if (results.Count == 0) {
                    Console.WriteLine("Not found results, verify search engine providers and try again.");
                    return;
                }
                   
                foreach (var result in results)
                {
                    Console.WriteLine(String.Format("find word {0} in {1} , total results {2} ", result.Query, result.SearcherName, result.TotalResult.ToString("#,#", CultureInfo.InvariantCulture)));
                }

                var searchers = _configService.ConfigSearchers();
                foreach (var searcher in searchers)
                {
                    var maxBySearcher = results.OrderByDescending(o => o.TotalResult).Where(s => s.SearcherName == searcher.SearcherName).Select(x => x.Query).FirstOrDefault();
                    Console.WriteLine(String.Format("Winner in {0} : {1} ", searcher.SearcherName, maxBySearcher));
                }

                var listGroup = results.GroupBy(item => item.Query).Select(c => new { query = c.Key, Total = c.Sum(p => p.TotalResult) });
                var maxTotal = listGroup.OrderByDescending(x => x.Total).Select(y => y.query).First();

                Console.WriteLine(String.Format("Total Winner: {0} ", maxTotal));

            });
        }
    }
}
