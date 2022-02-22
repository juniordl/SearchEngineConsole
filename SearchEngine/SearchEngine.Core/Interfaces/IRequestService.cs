using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Interfaces
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> RequestAsync(string request, Dictionary<string, string> headers);
    }
}
