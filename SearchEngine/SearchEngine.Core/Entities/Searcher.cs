using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Core.Entities
{
    public class Searcher
    {
        public string BaseUri { get; set; }
        public string SearcherName { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string[] UriParameters { get; set; }
        public Dictionary<string, string> NodesResult { get; set; }



        public string BuildUri() {

            string parameters = "";

            foreach (string values in this.UriParameters)
            {
                parameters += values;
            }

            return String.Format("{0}{1}", this.BaseUri, parameters);

        }
    }
}
