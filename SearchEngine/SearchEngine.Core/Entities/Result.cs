using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Core.Entities
{
    public class Result
    {
        public string Query { get; set; }
        public string SearcherName { get; set; }
        public decimal TotalResult { get; set; }

        public Result(string query, string searcherName, decimal totalResult) {
            this.Query = query;
            this.SearcherName = searcherName;
            this.TotalResult = totalResult;
        }
    }
}
