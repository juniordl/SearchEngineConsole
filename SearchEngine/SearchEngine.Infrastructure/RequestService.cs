using SearchEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Infrastructure
{
    public class RequestService : IRequestService
    {
        public async Task<HttpResponseMessage> RequestAsync(string request, Dictionary<string, string> headers)
        {
            var client = new HttpClient();
            if (headers != null && headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            return (await client.GetAsync(request));
        }
    }
}
